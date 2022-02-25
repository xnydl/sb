using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;
using SmartBotAPI.Plugins.API;

/* Explanation on profiles :
 * 
 * 配置文件中定义的所有值都是百分比修饰符，这意味着它将影响基本配置文件的默认值。
 * 
 * 修饰符值可以在[-10000;范围内设置。 10000]（负修饰符有相反的效果）
 * 您可以为非全局修改器指定目标，这些目标特定修改器将添加到卡的全局修改器+修改器之上（无目标）
 * 
 * 应用的总修改器=全局修改器+无目标修改器+目标特定修改器
 * 
 * GlobalDrawModifier --->修改器应用于卡片绘制值
 * GlobalWeaponsAttackModifier --->修改器适用于武器攻击的价值，它越高，人工智能攻击武器的可能性就越小
 * 
 * GlobalCastSpellsModifier --->修改器适用于所有法术，无论它们是什么。修饰符越高，AI玩法术的可能性就越小
 * GlobalCastMinionsModifier --->修改器适用于所有仆从，无论它们是什么。修饰符越高，AI玩仆从的可能性就越小
 * 
 * GlobalAggroModifier --->修改器适用于敌人的健康值，越高越好，人工智能就越激进
 * GlobalDefenseModifier --->修饰符应用于友方的健康值，越高，hp保守的将是AI
 * 
 * CastSpellsModifiers --->你可以为每个法术设置个别修饰符，修饰符越高，AI玩法术的可能性越小
 * CastMinionsModifiers --->你可以为每个小兵设置单独的修饰符，修饰符越高，AI玩仆从的可能性越小
 * CastHeroPowerModifier --->修饰符应用于heropower，修饰符越高，AI玩它的可能性就越小
 * 
 * WeaponsAttackModifiers --->适用于武器攻击的修饰符，修饰符越高，AI攻击它的可能性越小
 * 
 * OnBoardFriendlyMinionsValuesModifiers --->修改器适用于船上友好的奴才。修饰语越高，AI就越保守。
 * OnBoardBoardEnemyMinionsModifiers --->修改器适用于船上的敌人。修饰符越高，AI就越会将其视为优先目标。
 *
 */

namespace SmartBotProfiles
{
    [Serializable]
    public class WildDemonHunter : Profile
    {
        //幸运币
        private const Card.Cards TheCoin = Card.Cards.GAME_005;

        //猎人
        private const Card.Cards SteadyShot = Card.Cards.HERO_05bp;
        //德鲁伊
        private const Card.Cards Shapeshift = Card.Cards.HERO_06bp;
        //术士
        private const Card.Cards LifeTap = Card.Cards.HERO_07bp;
        //法师
        private const Card.Cards Fireblast = Card.Cards.HERO_08bp;
        //圣骑士
        private const Card.Cards Reinforce = Card.Cards.HERO_04bp;
        //战士
        private const Card.Cards ArmorUp = Card.Cards.HERO_01bp;
        //牧师
        private const Card.Cards LesserHeal = Card.Cards.HERO_09bp;
        //潜行者
        private const Card.Cards DaggerMastery = Card.Cards.HERO_03bp;
        //DH
        private const Card.Cards DemonsBite = Card.Cards.HERO_10bp;
        private const Card.Cards DemonsbiteUp = Card.Cards.HERO_10bp2;
        //萨满
        private const Card.Cards TotemicCall = Card.Cards.HERO_02bp;

        //英雄能力优先级
        private readonly Dictionary<Card.Cards, int> _heroPowersPriorityTable = new Dictionary<Card.Cards, int>
        {
            {SteadyShot, 9},//稳固射击 Steady Shot
            {DemonsbiteUp, 9},
            {LifeTap,9},//生命分流 Life Tap
            {DaggerMastery,4},//匕首精通 Dagger Mastery
            {Reinforce, 7},//援军 Reinforce
            {Shapeshift, 6},//变形 Shapeshift
            {DemonsBite, 8},
            {Fireblast, 5},//火焰冲击 Fireblast
            {ArmorUp, 3},//全副武装” "Armor Up"
            {LesserHeal, 1},//次级治疗术 Lesser Heal
            {TotemicCall, 8},//图腾召唤 Totemic Call

        };

        //直伤卡牌
        private static readonly Dictionary<Card.Cards, int> _spellDamagesTable = new Dictionary<Card.Cards, int>
        {
            
          
            {Card.Cards.BT_100, 3},//毒蛇神殿传送门 Serpentshrine Portal  ID：BT_100
            {Card.Cards.TRL_012, 2},//图腾重击 Totemic Smash  ID：TRL_012
            {Card.Cards.CFM_707, 4},//青玉闪电 Jade Lightning  ID：CFM_707
            {Card.Cards.BRM_011, 2},//熔岩震击 Lava Shock  ID：BRM_011
            {Card.Cards.EX1_238, 3},//闪电箭 Lightning Bolt  ID：EX1_238
            {Card.Cards.EX1_241, 5},//熔岩爆裂 Lava Burst  ID：EX1_241
            {Card.Cards.CS2_037, 1},//冰霜震击 Frost Shock  ID：CS2_037
            {Card.Cards.DAL_614, 2},//狗头人跟班 Kobold Lackey  ID：DAL_614
            {Card.Cards.GIL_530, 2},//阴燃电鳗 Murkspark Eel  ID：GIL_530
            {Card.Cards.GVG_038, 6},//连环爆裂 Crackle ID：GVG_038
            {Card.Cards.EX1_308, 4},//灵魂之火 Soulfire  ID：EX1_308
            {Card.Cards.SCH_248, 1},//甩笔侏儒 Pen Flinger  ID：SCH_248
            {Card.Cards.TRL_512, 1},//调皮的噬踝者 Cheaty Anklebiter  ID：TRL_512
            {Card.Cards.GVG_015, 3},//暗色炸弹 Darkbomb  ID：GVG_015
            {Card.Cards.EX1_316, 4},//力量的代价 Power Overwhelming  ID：EX1_316
            {Card.Cards.EX1_116, 6},//火车王里诺艾 Leeroy Jenkins  ID：EX1_116


        };


        //攻击模式



       
       public ProfileParameters GetParameters(Board board)
        {



            var p = new ProfileParameters(BaseProfile.Rush) { DiscoverSimulationValueThresholdPercent = -10 };
            p.CastSpellsModifiers.AddOrUpdate(TheCoin, new Modifier(85));

            //自定义命名
            int a = (board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) - BoardHelper.GetEnemyHealthAndArmor(board);//敌我血量差





            //攻击模式切换
            if (board.EnemyClass == Card.CClass.DEMONHUNTER
                || board.EnemyClass == Card.CClass.HUNTER
                || board.EnemyClass == Card.CClass.ROGUE
                || board.EnemyClass == Card.CClass.SHAMAN
                || board.EnemyClass == Card.CClass.DRUID
                || board.EnemyClass == Card.CClass.PALADIN
                || board.EnemyClass == Card.CClass.WARRIOR)
            {
                p.GlobalAggroModifier = (int)(a * 0.625 + 96.5);
            }
            else
            {
                p.GlobalAggroModifier = (int)(a * 0.625 + 103.5);
            }
            Bot.Log("攻击性：" + p.GlobalAggroModifier.Value);

            if (!board.MinionEnemy.Any(x => x.IsTaunt) &&
                   (BoardHelper.GetEnemyHealthAndArmor(board) -
                  BoardHelper.GetPotentialMinionDamages(board) -
                BoardHelper.GetPlayableMinionSequenceDamages(BoardHelper.GetPlayableMinionSequence(board), board) <=
                BoardHelper.GetTotalBlastDamagesInHand(board)))
            {
                p.GlobalAggroModifier = 450;
            }//如果下一轮可以斩杀对面，攻击性提高
            

					//判定是否过载
			bool guozai;
			if (board.LockedMana == 0
				&& board.OverloadedMana == 0){
				guozai = false;
			}else{
				guozai = true;
			}
			
            //具体策略
            //图腾体系






            {
                int myAttack = 0;
                int enemyAttack = 0;

                if (board.MinionFriend != null)
                {
                    for (int x = 0; x < board.MinionFriend.Count; x++)
                    {
                        myAttack += board.MinionFriend[x].CurrentAtk;
                    }
                }

                if (board.MinionEnemy != null)
                {
                    for (int x = 0; x < board.MinionEnemy.Count; x++)
                    {
                        enemyAttack += board.MinionEnemy[x].CurrentAtk;
                    }
                }

                if (board.WeaponEnemy != null)
                {
                    enemyAttack += board.WeaponEnemy.CurrentAtk;
                }

                if ((int)board.EnemyClass == 2 || (int)board.EnemyClass == 7 || (int)board.EnemyClass == 8)
                {
                    enemyAttack += 1;
                }
                else if ((int)board.EnemyClass == 6)
                {
                    enemyAttack += 2;
                }







                if (board.HasCardOnBoard(Card.Cards.GVG_107)//强化机器人 Enhance-o Mechano ID：GVG_107
                    && board.MinionFriend.Count >= 2
                    || board.HeroFriend.CurrentHealth < 9
                    && myAttack >= 12)
                {

                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GVG_107, new Modifier(-50)); //强化机器人 Enhance-o Mechano  ID：GVG_107
                }
                else
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GVG_107, new Modifier(350)); //强化机器人 Enhance-o Mechano  ID：GVG_107
                }


                if (board.HasCardOnBoard(Card.Cards.EX1_058)//日怒保卫者 Sunfury Protector  ID：EX1_058
                  && board.HeroFriend.CurrentHealth < 15)
                {

                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_058, new Modifier(-60)); //日怒保卫者 Sunfury Protector  ID：EX1_058
                }
                else
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_058, new Modifier(500)); //日怒保卫者 Sunfury Protector  ID：EX1_058
                }

                //如果下一轮可以斩杀对面提高洛欧塞布 Loatheb  ID：FP1_030
                if (board.HasCardInHand(Card.Cards.FP1_030)//洛欧塞布 Loatheb  ID：FP1_030
                && !board.MinionEnemy.Any(x => x.IsTaunt)
                && (BoardHelper.GetEnemyHealthAndArmor(board) - BoardHelper.GetPotentialMinionDamages(board) - BoardHelper.GetPlayableMinionSequenceDamages(BoardHelper.GetPlayableMinionSequence(board), board) <= BoardHelper.GetTotalBlastDamagesInHand(board))
                || myAttack >= (board.HeroEnemy.CurrentHealth) - 5

                )

                {

                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.FP1_030, new Modifier(-100));//洛欧塞布 Loatheb  ID：FP1_030
                }





                //如果费用=1，手上有后鲨和火炮，提高火炮优先级，降低后鲨优先级
                if (board.ManaAvailable == 1
                    && board.HasCardInHand(Card.Cards.TRL_507)//Card.Cards.TRL_507,//鲨鳍后援
                    && board.HasCardInHand(Card.Cards.GVG_075)//Card.Cards.GVG_075,//船载火炮
                    && board.HasCardInHand(Card.Cards.GAME_005)
                   )
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.TRL_507, new Modifier(80));//Card.Cards.TRL_507,//鲨鳍后援
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GVG_075, new Modifier(-80));////Card.Cards.GVG_075,//船载火炮

                }

                //如果费用=1，手上有芬利·莫格顿爵士 Sir Finley Mrrgglton  ID：LOE_076火炮，提高火炮优先级，降低芬利·莫格顿爵士 Sir Finley Mrrgglton  ID：LOE_076优先级
                if (board.ManaAvailable == 1
                    && board.HasCardInHand(Card.Cards.LOE_076)//芬利·莫格顿爵士 Sir Finley Mrrgglton  ID：LOE_076
                    && board.HasCardInHand(Card.Cards.GVG_075)//Card.Cards.GVG_075,//船载火炮
                    && board.HasCardInHand(Card.Cards.GAME_005)
                   )
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOE_076, new Modifier(80));//芬利·莫格顿爵士 Sir Finley Mrrgglton  ID：LOE_076
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GVG_075, new Modifier(-80));////Card.Cards.GVG_075,//船载火炮

                }



                //如果费用=1，手上有后鲨和火炮，提高火炮优先级，降低后鲨优先级
                if (board.ManaAvailable == 1
                    && board.HasCardInHand(Card.Cards.GVG_075)//Card.Cards.GVG_075,//船载火炮
                    && board.HasCardInHand(Card.Cards.GAME_005)
                    && board.HasCardInHand(Card.Cards.DRG_056)//空降歹徒 Parachute Brigand  ID：DRG_056
                    || board.HasCardInHand(Card.Cards.CS2_146)//南海船工 Southsea Deckhand  ID：CS2_146
                    || board.HasCardInHand(Card.Cards.CFM_637)//海盗帕奇斯 Patches the Pirate  ID：CFM_637
                    || board.HasCardInHand(Card.Cards.NEW1_025)//血帆海盗 Bloodsail Corsair  ID：NEW1_025
                    || board.HasCardInHand(Card.Cards.TRL_507)//鲨鳍后援 Sharkfin Fan  ID：TRL_507
                   
                   )
                {
                    
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GVG_075, new Modifier(-80));////Card.Cards.GVG_075,//船载火炮

                }
              

                //如果手上有其他海盗，降低空降歹徒优先级
                if ( board.HasCardInHand(Card.Cards.DRG_056)//空降歹徒 Parachute Brigand  ID：DRG_056
                    && board.HasCardInHand(Card.Cards.CS2_146)//南海船工 Southsea Deckhand  ID：CS2_146
                    || board.HasCardInHand(Card.Cards.CFM_637)//海盗帕奇斯 Patches the Pirate  ID：CFM_637
                    || board.HasCardInHand(Card.Cards.NEW1_025)//血帆海盗 Bloodsail Corsair  ID：NEW1_025
                    || board.HasCardInHand(Card.Cards.TRL_507)//鲨鳍后援 Sharkfin Fan  ID：TRL_507
                    || board.HasCardInHand(Card.Cards.NEW1_027)//南海船长 Southsea Captain  ID：NEW1_027
                   )
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DRG_056, new Modifier(500));//空降歹徒 Parachute Brigand  ID：DRG_056

                }
                else
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DRG_056, new Modifier(10));//空降歹徒 Parachute Brigand  ID：DRG_056

                }


                //费用小于等于2 不使用异教低阶牧师 Cult Neophyte  ID：SCH_713
                if (board.ManaAvailable <=2
                   && board.HasCardInHand(Card.Cards.SCH_713)//异教低阶牧师 Cult Neophyte  ID：SCH_713
                    )
                {
                  p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_713, new Modifier(500));//异教低阶牧师 Cult Neophyte  ID：SCH_713
                }
                else

                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_713, new Modifier(40));//异教低阶牧师 Cult Neophyte  ID：SCH_713
                }





                if (board.Hand.Count <= 3
                && board.HasCardInHand(Card.Cards.SCH_142)//贪婪的书虫 Voracious Reader  ID：SCH_142
                 )
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_142, new Modifier(-40));//贪婪的书虫 Voracious Reader  ID：SCH_142
                }
                else
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_142, new Modifier(300));//贪婪的书虫 Voracious Reader  ID：SCH_142
                }






                //一费有活体根须和硬币，降低其他海盗和船载火炮优先值
                if (board.ManaAvailable == 1
                    && board.HasCardInHand(Card.Cards.GVG_075)//Card.Cards.GVG_075,//船载火炮
                    && !board.HasCardInHand(Card.Cards.DRG_315)//森然巨化 Embiggen ID：DRG_315 
                    && board.HasCardInHand(Card.Cards.GAME_005)
                    || board.HasCardInHand(Card.Cards.EX1_169)//激活 Innervate ID：EX1_169 
                    && board.HasCardInHand(Card.Cards.CS2_146)//南海船工 Southsea Deckhand  ID：CS2_146
                    || board.HasCardInHand(Card.Cards.CFM_637)//海盗帕奇斯 Patches the Pirate  ID：CFM_637
                    || board.HasCardInHand(Card.Cards.NEW1_025)//血帆海盗 Bloodsail Corsair  ID：NEW1_025
                    && board.HasCardInHand(Card.Cards.AT_037)//活体根须 Living Roots  ID：AT_037
                    || board.HasCardInHand(Card.Cards.DAL_354)//橡果人 Acornbearer  ID：DAL_354
                    
                   )
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DRG_056, new Modifier(500));//南海船工 Southsea Deckhand  ID：CS2_146
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.CFM_637, new Modifier(500));//海盗帕奇斯 Patches the Pirate  ID：CFM_637
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.NEW1_025, new Modifier(500));//血帆海盗 Bloodsail Corsair  ID：NEW1_025
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GVG_075, new Modifier(500));//Card.Cards.GVG_075,//船载火炮
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DAL_354, new Modifier(-40));//橡果人 Acornbearer  ID：DAL_354
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.GAME_005, new Modifier(150));//野蛮咆哮 Savage Roar  ID：CS2_011
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.AT_037, new Modifier(-60));//活体根须 Living Roots  ID：AT_037


                }

               





                //手里有咆哮，随从大于4，可以开咆哮
                if (board.HasCardInHand(Card.Cards.CS2_011)//野蛮咆哮 Savage Roar  ID：CS2_011
                && board.MinionFriend.Count >= 4
                && !board.MinionEnemy.Any(x => x.IsTaunt)
                 )
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CS2_011, new Modifier(-20));//野蛮咆哮 Savage Roar  ID：CS2_011
                }



                //场上有书虫，提高手里硬币优先值
                if ( board.HasCardOnBoard(Card.Cards.SCH_142)//贪婪的书虫 Voracious Reader  ID：SCH_142
                && board.HasCardInHand(Card.Cards.GAME_005)
                 )
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.GAME_005, new Modifier(-10));
                }
                //场上有书虫，提高手里雷霆绽放 Lightning Bloom  ID：SCH_427优先值
                if (board.HasCardOnBoard(Card.Cards.SCH_142)//贪婪的书虫 Voracious Reader  ID：SCH_142
                && board.HasCardInHand(Card.Cards.SCH_427)//雷霆绽放 Lightning Bloom  ID：SCH_427
                 )
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.SCH_427, new Modifier(-10));
                }
                //场上有书虫，提高手里激活 Innervate ID：EX1_169 优先值
                if (board.HasCardOnBoard(Card.Cards.SCH_142)//贪婪的书虫 Voracious Reader  ID：SCH_142
                && board.HasCardInHand(Card.Cards.EX1_169)//激活 Innervate ID：EX1_169 
                 )
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_169, new Modifier(-40));
                }


                //费用为1，手上有法术，提高聒噪怪 Gibberling  ID：SCH_242
                if (board.ManaAvailable == 1
                && board.HasCardInHand(Card.Cards.SCH_142)//聒噪怪 Gibberling  ID：SCH_242
                && board.HasCardInHand(Card.Cards.AT_037)//活体根须 Living Roots  ID：AT_037
                 )
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.AT_037, new Modifier(350));//活体根须 Living Roots  ID：AT_037
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_242, new Modifier(-40));//聒噪怪 Gibberling  ID：SCH_242

                }


                //3费之前，随从大于3，提高印记优先值
                if (board.ManaAvailable <=3
                && board.MinionFriend.Count >= 3
                && board.HasCardInHand(Card.Cards.CFM_614)//玉莲印记 Mark of the Lotus  ID：CFM_614
                 )
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CFM_614, new Modifier(-40));//玉莲印记 Mark of the Lotus  ID：CFM_614
                }
                else{
                      p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CFM_614, new Modifier(150));//玉莲印记 Mark of the Lotus  ID：CFM_614
                }
                 //随从大于3，提高印记优先值
                if (board.ManaAvailable <=3
                && board.MinionFriend.Count >= 3
                && board.HasCardInHand(Card.Cards.CFM_614)//玉莲印记 Mark of the Lotus  ID：CFM_614
                || board.HasCardInHand(Card.Cards.EX1_160)//野性之力 Power of the Wild  ID：EX1_160
                || board.HasCardInHand(Card.Cards.DAL_351)//远古祝福 Blessing of the Ancients ID：DAL_351 
                 )
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CFM_614, new Modifier(-40));//玉莲印记 Mark of the Lotus  ID：CFM_614
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_160, new Modifier(-45));//野性之力 Power of the Wild  ID：EX1_160
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.DAL_351, new Modifier(-50));//远古祝福 Blessing of the Ancients ID：DAL_351 
                }

                //一费有活体根须，提高其优先值
                if (board.ManaAvailable == 1
                   
                    && board.HasCardInHand(Card.Cards.AT_037)//活体根须 Living Roots  ID：AT_037
                    && !board.HasCardInHand(Card.Cards.DRG_315)//森然巨化 Embiggen ID：DRG_315 
                   )
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.AT_037, new Modifier(-40));//活体根须 Living Roots  ID：AT_037
                }



            }


            //武器优先值
            // p.CastWeaponsModifiers.AddOrUpdate(Card.Cards.DRG_025, new Modifier(-80));//海盗之锚 Ancharrr  ID：DRG_025


            //武器攻击保守性
            //  p.WeaponsAttackModifiers.AddOrUpdate(Card.Cards.OG_058, new Modifier(-20));//锈蚀铁钩 Rusty Hook  ID：OG_058

            //法术
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_541t, new Modifier(-80));//国王的赎金 King's Ransom  ID：LOOT_541t
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.AT_037, new Modifier(200, Card.Cards.CS2_101t));//活体根须 Living Roots  ID：AT_037(2000, Card.Cards.LOOT_368))




            //硬币优先级
           p.CastSpellsModifiers.AddOrUpdate(Card.Cards.TB_011, new Modifier(50));   //硬币
            //p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_169, new Modifier(50));   //激活 Innervate ID：EX1_169 

            //直伤法术优先值		
           
           
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.SCH_610, new Modifier(-20));//动物保镖 Guardian Animals  ID：SCH_610
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.SCH_609, new Modifier(-30));//优胜劣汰 Survival of the Fittest  ID：SCH_609

            //提高术士的技能生命分流优先级
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(-10, board.HeroEnemy.Id));

            //随从优先值
           

            //随从优先值
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_242, new Modifier(-50));//聒噪怪 Gibberling  ID：SCH_242
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.FP1_017, new Modifier(-40));//尼鲁巴蛛网领主 Nerub'ar Weblord  ID：FP1_017
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_713, new Modifier(60));//异教低阶牧师 Cult Neophyte  ID：SCH_713
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GVG_075, new Modifier(-40));//船载火炮 Ship's Cannon  ID：GVG_075
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DMF_125, new Modifier(-20));//安全检查员 Safety Inspector ID：DMF_125 
            //不送的怪
            p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.BT_307, new Modifier(150)); //修饰黑眼 Darkglare  ID：BT_307，数值越高越保守，就是不会拿去交换随从
            p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.BT_309, new Modifier(150)); //修饰坎雷萨德·埃伯洛克 Kanrethad Ebonlocke  ID：BT_309
            p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.SCH_242, new Modifier(75)); //修饰聒噪怪 Gibberling  ID：SCH_242
            p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.FP1_017, new Modifier(150)); //修饰尼鲁巴蛛网领主 Nerub'ar Weblord  ID：FP1_017
            p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.GVG_075, new Modifier(75)); //修饰船载火炮 Ship's Cannon  ID：GVG_075
            p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.SCH_182, new Modifier(150)); //修饰演讲者吉德拉 Speaker Gidra  ID：SCH_182
            p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.SCH_142, new Modifier(150)); //修饰贪婪的书虫 Voracious Reader  ID：SCH_142
            //随从打自己
           // p.CastMinionsModifiers.AddOrUpdate(Card.Cards.TRL_512, new Modifier(-50, board.HeroFriend.Id));//提高调皮的噬踝者打自己脸优先度调皮的噬踝者 Cheaty Anklebiter  ID：TRL_512


            //降低价值
            //p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.SCH_312, new Modifier(-20)); //巡游向导 Tour Guide  ID：SCH_312

            p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.ULD_163, new Modifier(-20)); //过期货物专卖商 Expired Merchant ID：ULD_163
            //随从优先解
            //提高战斗邪犬威胁值
            p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.BT_351, new Modifier(200));
           




           

            return p;
        }
        
        //芬利·莫格顿爵士技能选择
        public Card.Cards SirFinleyChoice(List<Card.Cards> choices)
        {
            var filteredTable = _heroPowersPriorityTable.Where(x => choices.Contains(x.Key)).ToList();
            return filteredTable.First(x => x.Value == filteredTable.Max(y => y.Value)).Key;
        }

        //卡扎库斯选择
        public Card.Cards KazakusChoice(List<Card.Cards> choices)
        {
            return choices[0];
        }

        //计算类
        public static class BoardHelper
        {
            //得到敌方的血量和护甲之和
            public static int GetEnemyHealthAndArmor(Board board)
            {
                return board.HeroEnemy.CurrentHealth + board.HeroEnemy.CurrentArmor;
            }

            //得到自己的法强
            public static int GetSpellPower(Board board)
            {
                //计算没有被沉默的随从的法术强度之和
                return board.MinionFriend.FindAll(x => x.IsSilenced == false).Sum(x => x.SpellPower);
            }

            //获得第二轮斩杀血线
            public static int GetSecondTurnLethalRange(Board board)
            {
                //敌方英雄的生命值和护甲之和减去可释放法术的伤害总和
                return GetEnemyHealthAndArmor(board) - GetPlayableSpellSequenceDamages(board);
            }

            //下一轮是否可以斩杀敌方英雄
            public static bool HasPotentialLethalNextTurn(Board board)
            {
                //如果敌方随从没有嘲讽并且造成伤害
                //(敌方生命值和护甲的总和 减去 下回合能生存下来的当前场上随从的总伤害 减去 下回合能攻击的可使用随从伤害总和)
                //后的血量小于总法术伤害
                if (!board.MinionEnemy.Any(x => x.IsTaunt) &&
                    (GetEnemyHealthAndArmor(board) - GetPotentialMinionDamages(board) - GetPlayableMinionSequenceDamages(GetPlayableMinionSequence(board), board))
                        <= GetTotalBlastDamagesInHand(board))
                {
                    return true;
                }
                //法术释放过敌方英雄的血量是否大于等于第二轮斩杀血线
                return GetRemainingBlastDamagesAfterSequence(board) >= GetSecondTurnLethalRange(board);
            }

            //获得下回合能生存下来的当前场上随从的总伤害
            public static int GetPotentialMinionDamages(Board board)
            {
                return GetPotentialMinionAttacker(board).Sum(x => x.CurrentAtk);
            }

            //获得下回合能生存下来的当前场上随从集合
            public static List<Card> GetPotentialMinionAttacker(Board board)
            {
                //下回合能生存下来的当前场上随从集合
                var minionscopy = board.MinionFriend.ToArray().ToList();

                //遍历 以敌方随从攻击力 降序排序 的 场上敌方随从集合
                foreach (var mi in board.MinionEnemy.OrderByDescending(x => x.CurrentAtk))
                {
                    //以友方随从攻击力 降序排序 的 场上的所有友方随从集合，如果该集合存在生命值大于与敌方随从攻击力
                    if (board.MinionFriend.OrderByDescending(x => x.CurrentAtk).Any(x => x.CurrentHealth <= mi.CurrentAtk))
                    {
                        //以友方随从攻击力 降序排序 的 场上的所有友方随从集合,找出该集合中友方随从的生命值小于等于敌方随从的攻击力的随从
                        var tar = board.MinionFriend.OrderByDescending(x => x.CurrentAtk).FirstOrDefault(x => x.CurrentHealth <= mi.CurrentAtk);
                        //将该随从移除掉
                        minionscopy.Remove(tar);
                    }
                }

                return minionscopy;
            }

            //获得下回合能生存下来的对面随从集合
            public static List<Card> GetSurvivalMinionEnemy(Board board)
            {
                //下回合能生存下来的当前对面场上随从集合
                var minionscopy = board.MinionEnemy.ToArray().ToList();

                //遍历 以友方随从攻击力 降序排序 的 场上友方可攻击随从集合
                foreach (var mi in board.MinionFriend.FindAll(x => x.CanAttack).OrderByDescending(x => x.CurrentAtk))
                {
                    //如果存在友方随从攻击力大于等于敌方随从血量
                    if (board.MinionEnemy.OrderByDescending(x => x.CurrentHealth).Any(x => x.CurrentHealth <= mi.CurrentAtk))
                    {
                        //以敌方随从血量降序排序的所有敌方随从集合，找出敌方生命值小于等于友方随从攻击力的随从
                        var tar = board.MinionEnemy.OrderByDescending(x => x.CurrentHealth).FirstOrDefault(x => x.CurrentHealth <= mi.CurrentAtk);
                        //将该随从移除掉
                        minionscopy.Remove(tar);
                    }
                }
                return minionscopy;
            }

            //获取可以使用的随从集合
            public static List<Card.Cards> GetPlayableMinionSequence(Board board)
            {
                //卡片集合
                var ret = new List<Card.Cards>();

                //当前剩余的法力水晶
                var manaAvailable = board.ManaAvailable;

                //遍历以手牌中费用降序排序的集合
                foreach (var card in board.Hand.OrderByDescending(x => x.CurrentCost))
                {
                    //如果当前卡牌不为随从，继续执行
                    if (card.Type != Card.CType.MINION) continue;

                    //当前法力值小于卡牌的费用，继续执行
                    if (manaAvailable < card.CurrentCost) continue;

                    //添加到容器里
                    ret.Add(card.Template.Id);

                    //修改当前使用随从后的法力水晶
                    manaAvailable -= card.CurrentCost;
                }

                return ret;
            }

            //获取可以使用的奥秘集合
            public static List<Card.Cards> GetPlayableSecret(Board board)
            {
                //卡片集合
                var ret = new List<Card.Cards>();

                //遍历手牌中所有奥秘集合
                foreach (var card1 in board.Hand.FindAll(card => card.Template.IsSecret))
                {
                    if (board.Secret.Count > 0)
                    {
                        //遍历头上奥秘集合
                        foreach (var card2 in board.Secret.FindAll(card => CardTemplate.LoadFromId(card).IsSecret))
                        {

                            //如果手里奥秘和头上奥秘不相等
                            if (card1.Template.Id != card2)
                            {
                                //添加到容器里
                                ret.Add(card1.Template.Id);
                            }
                        }
                    }
                    else
                    { ret.Add(card1.Template.Id); }
                }
                return ret;
            }


            //获取下回合能攻击的可使用随从伤害总和
            public static int GetPlayableMinionSequenceDamages(List<Card.Cards> minions, Board board)
            {
                //下回合能攻击的可使用随从集合攻击力相加
                return GetPlayableMinionSequenceAttacker(minions, board).Sum(x => CardTemplate.LoadFromId(x).Atk);
            }

            //获取下回合能攻击的可使用随从集合
            public static List<Card.Cards> GetPlayableMinionSequenceAttacker(List<Card.Cards> minions, Board board)
            {
                //未处理的下回合能攻击的可使用随从集合
                var minionscopy = minions.ToArray().ToList();

                //遍历 以敌方随从攻击力 降序排序 的 场上敌方随从集合
                foreach (var mi in board.MinionEnemy.OrderByDescending(x => x.CurrentAtk))
                {
                    //以友方随从攻击力 降序排序 的 场上的所有友方随从集合，如果该集合存在生命值大于与敌方随从攻击力
                    if (minions.OrderByDescending(x => CardTemplate.LoadFromId(x).Atk).Any(x => CardTemplate.LoadFromId(x).Health <= mi.CurrentAtk))
                    {
                        //以友方随从攻击力 降序排序 的 场上的所有友方随从集合,找出该集合中友方随从的生命值小于等于敌方随从的攻击力的随从
                        var tar = minions.OrderByDescending(x => CardTemplate.LoadFromId(x).Atk).FirstOrDefault(x => CardTemplate.LoadFromId(x).Health <= mi.CurrentAtk);
                        //将该随从移除掉
                        minionscopy.Remove(tar);
                    }
                }

                return minionscopy;
            }

            //获取当前回合手牌中的总法术伤害
            public static int GetTotalBlastDamagesInHand(Board board)
            {
                //从手牌中找出法术伤害表存在的法术的伤害总和(包括法强)
                return
                    board.Hand.FindAll(x => _spellDamagesTable.ContainsKey(x.Template.Id))
                        .Sum(x => _spellDamagesTable[x.Template.Id] + GetSpellPower(board));
            }

            //获取可以使用的法术集合
            public static List<Card.Cards> GetPlayableSpellSequence(Board board)
            {
                //卡片集合
                var ret = new List<Card.Cards>();

                //当前剩余的法力水晶
                var manaAvailable = board.ManaAvailable;

                if (board.Secret.Count > 0)
                {
                    //遍历以手牌中费用降序排序的集合
                    foreach (var card in board.Hand.OrderBy(x => x.CurrentCost))
                    {
                        //如果手牌中又不在法术序列的法术牌，继续执行
                        if (_spellDamagesTable.ContainsKey(card.Template.Id) == false) continue;

                        //当前法力值小于卡牌的费用，继续执行
                        if (manaAvailable < card.CurrentCost) continue;

                        //添加到容器里
                        ret.Add(card.Template.Id);

                        //修改当前使用随从后的法力水晶
                        manaAvailable -= card.CurrentCost;
                    }
                }
                else if (board.Secret.Count == 0)
                {
                    //遍历以手牌中费用降序排序的集合
                    foreach (var card in board.Hand.FindAll(x => x.Type == Card.CType.SPELL).OrderBy(x => x.CurrentCost))
                    {
                        //如果手牌中又不在法术序列的法术牌，继续执行
                        if (_spellDamagesTable.ContainsKey(card.Template.Id) == false) continue;

                        //当前法力值小于卡牌的费用，继续执行
                        if (manaAvailable < card.CurrentCost) continue;

                        //添加到容器里
                        ret.Add(card.Template.Id);

                        //修改当前使用随从后的法力水晶
                        manaAvailable -= card.CurrentCost;
                    }
                }

                return ret;
            }
            
            //获取存在于法术列表中的法术集合的伤害总和(包括法强)
            public static int GetSpellSequenceDamages(List<Card.Cards> sequence, Board board)
            {
                return
                    sequence.FindAll(x => _spellDamagesTable.ContainsKey(x))
                        .Sum(x => _spellDamagesTable[x] + GetSpellPower(board));
            }

            //得到可释放法术的伤害总和
            public static int GetPlayableSpellSequenceDamages(Board board)
            {
                return GetSpellSequenceDamages(GetPlayableSpellSequence(board), board);
            }
            
            //计算在法术释放过敌方英雄的血量
            public static int GetRemainingBlastDamagesAfterSequence(Board board)
            {
                //当前回合总法术伤害减去可释放法术的伤害总和
                return GetTotalBlastDamagesInHand(board) - GetPlayableSpellSequenceDamages(board);
            }

            public static bool IsOutCastCard(Card card, Board board)
            {
                var OutcastLeft = board.Hand.Find(x => x.CurrentCost >= 0);
                var OutcastRight = board.Hand.FindLast(x => x.CurrentCost >= 0);
                if (card.Template.Id == OutcastLeft.Template.Id
                    || card.Template.Id == OutcastRight.Template.Id)
                {
                    return true;
                    
                }
                return false;
            }
            public static bool IsGuldanOutCastCard(Card card, Board board)
            {
                if ((board.FriendGraveyard.Exists(x => CardTemplate.LoadFromId(x).Id == Card.Cards.BT_601)
                    && card.Template.Cost - card.CurrentCost == 3))
                {
                    return true;
                }
                
                return false;
            }
            public static bool  IsOutcast(Card card,Board board)
            {
                if(IsOutCastCard(card,board) || IsGuldanOutCastCard(card,board))
                {
                    return true;
                }
                return false;
            }


            //在没有法术的情况下有潜在致命的下一轮
            public static bool HasPotentialLethalNextTurnWithoutSpells(Board board)
            {
                if (!board.MinionEnemy.Any(x => x.IsTaunt) &&
                    (GetEnemyHealthAndArmor(board) -
                     GetPotentialMinionDamages(board) -
                     GetPlayableMinionSequenceDamages(GetPlayableMinionSequence(board), board) <=
                     0))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
