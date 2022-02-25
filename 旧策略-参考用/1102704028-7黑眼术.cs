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
 
 /* 
 * 
 * https://github.com/Waldo-Schaeffer
 * https://gitee.com/m586
 * Copyleft 2016 - 2020 SunGuanqi. All Rights Reserved
 * Attribution 4.0 International (Attribution 4.0 International (CC BY 4.0)
 * 使用时请遵守知识共享署名 4.0 国际许可协议，且不可删除本版权信息
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


        //英雄能力优先级
        private readonly Dictionary<Card.Cards, int> _heroPowersPriorityTable = new Dictionary<Card.Cards, int>
        {
            {SteadyShot, 9},//稳固射击 Steady Shot
            {DemonsbiteUp, 9},
            {LifeTap,9},//生命分流 Life Tap
            {DaggerMastery,6},//匕首精通 Dagger Mastery
            {Reinforce, 2},//援军 Reinforce
            {Shapeshift, 6},//变形 Shapeshift
            {DemonsBite, 4},
            {Fireblast, 8},//火焰冲击 Fireblast
            {ArmorUp, 3},//全副武装” "Armor Up"
            {LesserHeal, 1},//次级治疗术 Lesser Heal
        };

        //直伤卡牌
        private static readonly Dictionary<Card.Cards, int> _spellDamagesTable = new Dictionary<Card.Cards, int>
        {
            {Card.Cards.EX1_116, 6},//火车王里诺艾 Leeroy Jenkins  ID：EX1_116
            {Card.Cards.CS2_087, 3},//力量祝福 Blessing of Might  ID：CS2_087
            {Card.Cards.SCH_248, 1},//甩笔侏儒 Pen Flinger  ID：SCH_248
            {Card.Cards.EX1_308, 4},//灵魂之火 Soulfire  ID：EX1_308
            {Card.Cards.EX1_316, 4},//力量的代价 Power Overwhelming  ID：EX1_316
        };
        //攻击模式
        public ProfileParameters GetParameters(Board board)
        {
            var p = new ProfileParameters(BaseProfile.Rush) { DiscoverSimulationValueThresholdPercent = -10 };
            p.CastSpellsModifiers.AddOrUpdate(TheCoin, new Modifier(85));
//todo判定手上是否有自残怪或者法术
				bool hert1;
				//亡者复生，巡游向导，晶化师 ，灵魂炸弹，烈焰小鬼,狗头人图书管理员,粗俗的矮劣魔 ,调皮的噬踝者,翡翠掠夺者,火焰之雨,甩笔侏儒
				if (board.HasCardInHand(Card.Cards.SCH_514)//亡者复生 Raise Dead  ID：SCH_514
				|| board.HasCardInHand(Card.Cards.SCH_312)//巡游向导 Tour Guide  ID：SCH_312
				|| board.HasCardInHand(Card.Cards.BOT_447)//晶化师 Crystallizer  ID：BOT_447
				|| board.HasCardInHand(Card.Cards.BOT_222)//灵魂炸弹 Spirit Bomb  ID：BOT_222
				|| board.HasCardInHand(Card.Cards.EX1_319)//烈焰小鬼 Flame Imp  ID：EX1_319
				|| board.HasCardInHand(Card.Cards.LOOT_014)//狗头人图书管理员 Kobold Librarian  ID：LOOT_014
				|| board.HasCardInHand(Card.Cards.LOOT_013)//粗俗的矮劣魔 Vulgar Homunculus  ID：LOOT_013
				|| board.HasCardInHand(Card.Cards.TRL_512)//调皮的噬踝者 Cheaty Anklebiter  ID：TRL_512
				|| board.HasCardInHand(Card.Cards.UNG_803)//翡翠掠夺者 Emerald Reaver  ID：UNG_803
				|| board.HasCardInHand(Card.Cards.DRG_206)//火焰之雨 Rain of Fire  ID：DRG_206
				|| board.HasCardInHand(Card.Cards.SCH_248)//甩笔侏儒 Pen Flinger  ID：SCH_248
				|| board.HasCardInHand(Card.Cards.YOP_033)//赛车回火 Backfire ID：YOP_033
				){
					hert1 = true;
				}else{
					hert1 = false;
				}
//todo判定手上是否有一费自残怪
				bool hert2;
				if (board.HasCardInHand(Card.Cards.SCH_312)//巡游向导 Tour Guide  ID：SCH_312
				|| board.HasCardInHand(Card.Cards.BOT_447)//晶化师 Crystallizer  ID：BOT_447
				|| board.HasCardInHand(Card.Cards.EX1_319)//烈焰小鬼 Flame Imp  ID：EX1_319
				|| board.HasCardInHand(Card.Cards.LOOT_014)//狗头人图书管理员 Kobold Librarian  ID：LOOT_014
				|| board.HasCardInHand(Card.Cards.UNG_803)//翡翠掠夺者 Emerald Reaver  ID：UNG_803
				|| board.HasCardInHand(Card.Cards.DRG_206)//火焰之雨 Rain of Fire  ID：DRG_206
				|| board.HasCardInHand(Card.Cards.SCH_514)//亡者复生 Raise Dead  ID：SCH_514
				){
					hert2 = true;
				}else{
					hert2 = false;
				}
//todo坟场
//todo 针对各职业
//todo一费相关
            //如果一费有狗头人和小鬼和巡游向导,提高狗头人优先级
            if( board.ManaAvailable ==1
            && board.HasCardInHand(Card.Cards.LOOT_014)//狗头人图书管理员 Kobold Librarian  ID：LOOT_014
            )
            {
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_014, new Modifier(-200));//狗头人图书管理员 Kobold Librarian  ID：LOOT_014
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_312, new Modifier(9999));//巡游向导 Tour Guide  ID：SCH_312
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.KAR_089, new Modifier(9999));//玛克扎尔的小鬼 Malchezaar's Imp  ID：KAR_089
            }
//todo牧师
            //如果对面是牧师,7费之前提高塞布优先级
             if ( board.HasCardInHand(Card.Cards.FP1_030)//洛欧塞布 Loatheb  ID：FP1_030
               && board.EnemyClass == Card.CClass.PRIEST
               && board.ManaAvailable <= 8
                )
            {
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.FP1_030, new Modifier(-40));//洛欧塞布 Loatheb  ID：FP1_030
            }

            //对面是牧师，火车王随便下
			if (board.EnemyClass == Card.CClass.PRIEST
            &&  board.HasCardInHand(Card.Cards.EX1_116)//火车王里诺艾 Leeroy Jenkins  ID：EX1_116
            )
			{
				p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_116, new Modifier(-50));//修改火车王的优先级
			}
//todo骑士
            //对面是骑士 随从小于4不用亵渎
          if ( board.EnemyClass == Card.CClass.PALADIN
            && board.MaxMana <= 3
            && board.MinionEnemy.Count <= 4
            && board.HasCardInHand(Card.Cards.ICC_041)//亵渎 Defile  ID：ICC_041
            )
			{
				p.CastSpellsModifiers.AddOrUpdate(Card.Cards.ICC_041, new Modifier(300));
			}
//todo小德            
            //如果对面是德，随从大于等于4，优先解场
			if (board.EnemyAbility.Template.Id == Card.Cards.HERO_06bp
               && board.MinionEnemy.Count >= 4
            )
            {
				p.GlobalAggroModifier = 40;
			}
//todo法师
//todo盗贼
            //如果对面是贼，需要提高狐人老千的威胁值
			if (board.EnemyClass == Card.CClass.ROGUE
			&& board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.DMF_511)
			){
				p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.DMF_511, new Modifier(199));//狐人老千 Foxy Fraud ID：DMF_511
				//Bot.Log("对面是潜行者要优先解掉狐人老千");
			}
//todo武器攻击力计算            
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
//-------------------------------------------------------------------------
//todo黑眼术策略
//todo 小鬼
//todo风怒机器人相关
                 if (board.HasCardOnBoard(Card.Cards.GVG_107)//强化机器人 Enhance-o Mechano ID：GVG_107
                    && !board.MinionEnemy.Any(x => x.IsTaunt)
                    && (BoardHelper.GetEnemyHealthAndArmor(board) - BoardHelper.GetPotentialMinionDamages(board) - BoardHelper.GetPlayableMinionSequenceDamages(BoardHelper.GetPlayableMinionSequence(board), board) <= BoardHelper.GetTotalBlastDamagesInHand(board))
                    || myAttack >= (board.HeroEnemy.CurrentHealth) /2
                    )
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GVG_107, new Modifier(-9999)); //强化机器人 Enhance-o Mechano  ID：GVG_107
                }
                else
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GVG_107, new Modifier(999)); //强化机器人 Enhance-o Mechano  ID：GVG_107
                }

//todo日怒保卫者相关
            //血量不低,降低日怒保卫者 Sunfury Protector  ID：EX1_058优先级
            //日怒保卫者 Sunfury Protector  ID：EX1_058
                if (board.HasCardInHand(Card.Cards.EX1_058)//日怒保卫者 Sunfury Protector  ID：EX1_058
                && board.HeroFriend.CurrentHealth <=13)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_058, new Modifier(-50)); //日怒保卫者 Sunfury Protector  ID：EX1_058
                }
                else
                {
                     p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_058, new Modifier(500)); //日怒保卫者 Sunfury Protector  ID：EX1_058
                }	
//todo紫水晶相关
                //血量小于13开始提高紫水晶优先值大型法术紫水晶 Greater Amethyst Spellstone  ID：LOOT_043t3
                if (board.HeroFriend.CurrentHealth < 10
                && board.HasCardInHand(Card.Cards.LOOT_043t3)
                || board.HasCardInHand(Card.Cards.LOOT_043)//小型法术紫水晶 Lesser Amethyst Spellstone  ID：LOOT_043
                || board.HasCardInHand(Card.Cards.LOOT_043t2)//法术紫水晶 Amethyst Spellstone  ID：LOOT_043t2
                )
                {
                    // 20血 优先级 1000 0
                    // 15血 优先级 350 -350
                    // 11血 优先级 100 -900
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_043t3, new Modifier(-120));//大型法术紫水晶 Greater Amethyst Spellstone  ID：LOOT_043t3
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_043t2, new Modifier(-100));//法术紫水晶 Amethyst Spellstone  ID：LOOT_043t2      
                    // p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_043, new Modifier(-20));//小型法术紫水晶 Lesser Amethyst Spellstone  ID：LOOT_043
                }  else{
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_043t3, new Modifier(500));//大型法术紫水晶 Greater Amethyst Spellstone  ID：LOOT_043t3
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_043t2, new Modifier(500));//法术紫水晶 Amethyst Spellstone  ID：LOOT_043t2     
                     p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_043, new Modifier(500));//小型法术紫水晶 Lesser Amethyst Spellstone  ID：LOOT_043 
                }
                // 如果手上有紫水晶，且血量大于15点，提高自残的优先级
            if (board.HasCardInHand(Card.Cards.LOOT_043)
                || board.HasCardInHand(Card.Cards.LOOT_043t2)
                && board.HeroFriend.CurrentHealth > 16
                && hert1 == true
              )
            {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_319, new Modifier(90));//烈焰小鬼
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_319, new Modifier(80));//狗头人图书管理员
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_013, new Modifier(100));//粗俗的矮劣魔
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DRG_206, new Modifier(120));//火焰之雨
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BOT_222, new Modifier(110));//灵魂炸弹
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.UNG_803, new Modifier(50));//翡翠掠夺者
            }
//todo晶化师相关
             //总血量不少于15不下晶化师
            if (((board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) < 16)
                && board.HasCardInHand(Card.Cards.BOT_447)
                )
            {
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BOT_447, new Modifier(-200));//晶化师
            }
			else
			{
				p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BOT_447, new Modifier(999));//晶化师
			}
//todo2费相关
            	//费用为2时，必定抽一口
			if (board.ManaAvailable == 2)
			{
				p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(-999, board.HeroEnemy.Id));
                p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(-999));
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.HERO_07bp, new Modifier(-800));
                p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.HERO_07bp, new Modifier(-800));
				// p.CastSpellsModifiers.AddOrUpdate(Card.Cards.TB_011, new Modifier(999));   //硬币
				  //?法术
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.GAME_005, new Modifier(500));   //硬币
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.DRG_206, new Modifier(500));//火焰之雨 Rain of Fire  ID：DRG_206
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BOT_222, new Modifier(999));//灵魂炸弹 Spirit Bomb  ID：BOT_222
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.SCH_514, new Modifier(9999));//亡者复生 Raise Dead  ID：SCH_514
                 p.CastSpellsModifiers.AddOrUpdate(Card.Cards.YOP_033, new Modifier(-9999));//赛车回火 Backfire ID：YOP_033
                //?随从
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_312, new Modifier(9999));//巡游向导 Tour Guide  ID：SCH_312
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_319, new Modifier(500));//烈焰小鬼 Flame Imp  ID：EX1_319
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_319, new Modifier(500));//狗头人图书管理员 Kobold Librarian  ID：LOOT_014
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_013, new Modifier(500));//粗俗的矮劣魔 Vulgar Homunculus  ID：LOOT_013
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.TRL_512, new Modifier(500));//调皮的噬踝者 Cheaty Anklebiter  ID：TRL_512
                 p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_312, new Modifier(500));//巡游向导 Tour Guide  ID：SCH_312
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.UNG_803, new Modifier(500));//翡翠掠夺者
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_248, new Modifier(500));//甩笔侏儒 Pen Flinger  ID：SCH_248
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BT_307, new Modifier(9999));//黑眼 Darkglare  ID：BT_307
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.KAR_089, new Modifier(999));//玛克扎尔的小鬼 Malchezaar's Imp  IDKAR_089：KAR_089
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BT_309, new Modifier(9999));//坎雷萨德·埃伯洛克 Kanrethad Ebonlocke  ID：BT_309
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_700, new Modifier(999));//精魂狱卒 Spirit Jailer ID：SCH_700 
			}
//todo三费相关
//todo硬币相关
            //如果有黑眼，则1费不用硬币
           if ( board.HasCardInHand(Card.Cards.GAME_005)
               && board.ManaAvailable ==1
               )
            {
               p.CastSpellsModifiers.AddOrUpdate(Card.Cards.GAME_005, new Modifier(9999));
            }else{
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.GAME_005, new Modifier(80));
            }
           
//todo玛维影歌            
            //空场不下玛维·影歌 Maiev Shadowsong  ID：BT_737
			if (board.MinionEnemy.Count == 0
			&& board.MinionFriend.Count == 0)
			{
				p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BT_737, new Modifier(999));//玛维·影歌
			}
//todo铁钩			
            //血量不少于15不下铁钩（不算护甲）
            if ((board.HeroFriend.CurrentHealth < 16)
                && board.HasCardInHand(Card.Cards.LOOT_018)
                )
            {
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_018, new Modifier(-200));//铁钩掠夺者
            }
			else
			{
				p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_018, new Modifier(999));//铁钩掠夺者
			}

             //对面有随从，手上有法术紫水晶 Amethyst Spellstone  ID：LOOT_043t2和铁钩掠夺者 Hooked Reaver  ID：LOOT_018，且血量小于10，降低铁钩 提高法力紫水晶
            if (board.MinionEnemy.Count >=3  //对面有怪在场上
               && board.HasCardInHand(Card.Cards.LOOT_043t2)//法术紫水晶 Amethyst Spellstone  ID：LOOT_043t2
               && board.HasCardInHand(Card.Cards.LOOT_018)//铁钩掠夺者 Hooked Reaver  ID：LOOT_018
               && board.HeroFriend.CurrentHealth <= 13//自己英雄的健康
                )
            {
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_018, new Modifier(350));//铁钩掠夺者 Hooked Reaver  ID：LOOT_018
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_043t2, new Modifier(-40));//法术紫水晶 Amethyst Spellstone  ID：LOOT_043t2
            }
//todo黑眼相关
            //3费有黑眼且有1费自残牌
            if (board.ManaAvailable ==3
                && board.HasCardInHand(Card.Cards.BT_307)
                && hert2==true
                )
            {
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BT_307, new Modifier(-900));//黑眼
            }else{
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BT_307, new Modifier(999));//黑眼
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(9999, board.HeroEnemy.Id));
                p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(9999));
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.HERO_07bp, new Modifier(800));
                p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.HERO_07bp, new Modifier(800));
				p.CastSpellsModifiers.AddOrUpdate(Card.Cards.TB_011, new Modifier(999));   //硬币
				  //?法术
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.GAME_005, new Modifier(500));   //硬币
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.DRG_206, new Modifier(500));//火焰之雨 Rain of Fire  ID：DRG_206
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BOT_222, new Modifier(999));//灵魂炸弹 Spirit Bomb  ID：BOT_222
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.SCH_514, new Modifier(9999));//亡者复生 Raise Dead  ID：SCH_514
                 p.CastSpellsModifiers.AddOrUpdate(Card.Cards.YOP_033, new Modifier(-100));//赛车回火 Backfire ID：YOP_033
                //?随从
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_312, new Modifier(9999));//巡游向导 Tour Guide  ID：SCH_312
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_319, new Modifier(500));//烈焰小鬼 Flame Imp  ID：EX1_319
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_319, new Modifier(500));//狗头人图书管理员 Kobold Librarian  ID：LOOT_014
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_013, new Modifier(500));//粗俗的矮劣魔 Vulgar Homunculus  ID：LOOT_013
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.TRL_512, new Modifier(500));//调皮的噬踝者 Cheaty Anklebiter  ID：TRL_512
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.UNG_803, new Modifier(500));//翡翠掠夺者
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_248, new Modifier(500));//甩笔侏儒 Pen Flinger  ID：SCH_248
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.KAR_089, new Modifier(999));//玛克扎尔的小鬼 Malchezaar's Imp  IDKAR_089：KAR_089
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BT_309, new Modifier(9999));//坎雷萨德·埃伯洛克 Kanrethad Ebonlocke  ID：BT_309
            }
           
            //没有3费不拍黑眼且有自残牌
            if (board.ManaAvailable >3
                && board.HasCardInHand(Card.Cards.BT_307)
                && hert1==true
                )
            {
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BT_307, new Modifier(-900));//黑眼
            }
            //场上有黑眼或者兀鹫，血量大于10点，直接自残
            if (board.HeroFriend.CurrentHealth > 3
                && board.HasCardOnBoard(Card.Cards.BT_307)
                || board.HasCardOnBoard(Card.Cards.ULD_167)
                && hert1 == true

                )
            {
                //?法术
                // p.CastSpellsModifiers.AddOrUpdate(Card.Cards.GAME_005, new Modifier(-10));   //硬币
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.DRG_206, new Modifier(-50));//火焰之雨 Rain of Fire  ID：DRG_206
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BOT_222, new Modifier(50));//灵魂炸弹 Spirit Bomb  ID：BOT_222
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.SCH_514, new Modifier(-40));//亡者复生 Raise Dead  ID：SCH_514
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.YOP_033, new Modifier(-100));//赛车回火 Backfire ID：YOP_033
                //?随从
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_319, new Modifier(-30));//烈焰小鬼 Flame Imp  ID：EX1_319
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_319, new Modifier(-200));//狗头人图书管理员 Kobold Librarian  ID：LOOT_014
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_013, new Modifier(-50));//粗俗的矮劣魔 Vulgar Homunculus  ID：LOOT_013
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.TRL_512, new Modifier(-50));//调皮的噬踝者 Cheaty Anklebiter  ID：TRL_512
                 p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_312, new Modifier(-300));//巡游向导 Tour Guide  ID：SCH_312
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.UNG_803, new Modifier(-100));//翡翠掠夺者
                // p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_248, new Modifier(-100));//甩笔侏儒 Pen Flinger  ID：SCH_248
                // p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BT_307, new Modifier(-200));//甩笔侏儒 Pen Flinger  ID：SCH_248
                //?
                 p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(-40, board.HeroEnemy.Id));
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.HERO_07bp, new Modifier(-40));
                p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.HERO_07bp, new Modifier(-40));
            }
//todo灵界相关
            //场上没有黑眼且费用小于10，不拍灵界(测试）
            if (board.ManaAvailable >=4
             && board.HasCardOnBoard(Card.Cards.BT_307)//黑眼 Darkglare  ID：BT_307
             && board.HasCardInHand(Card.Cards.BOT_568)//莫瑞甘的灵界 The Soularium ID：BOT_568
             && board.Hand.Count <= 7
            )
            { 
                   p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BOT_568, new Modifier(-9999));//莫瑞甘的灵界莫瑞甘的灵界 The Soularium  ID：BOT_568
            }
            else
            {
                if (board.ManaAvailable>=5
                    && board.Hand.Count <= 7
                 )
                {
                 p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BOT_568, new Modifier(-9999));//莫瑞甘的灵界莫瑞甘的灵界 The Soularium  ID：BOT_568
             }
                else
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BOT_568, new Modifier(999));//莫瑞甘的灵界
                }
            }
//todo火车相关
            //大于2费 有回火
            if (board.HasCardInHand(Card.Cards.YOP_033)//赛车回火 Backfire ID：YOP_033
             && board.Hand.Count <= 7
            )
            { 
             p.CastSpellsModifiers.AddOrUpdate(Card.Cards.YOP_033, new Modifier(-9999));//赛车回火 Backfire ID：YOP_033
           }
//todo亡者复生相关
            //如果坟场有黑眼或者巨人提高亡者复生 Raise Dead  ID：SCH_514
             if (board.HasCardInHand(Card.Cards.SCH_514)//亡者复生 Raise Dead  ID：SCH_514
               && board.ManaAvailable >=3
               && board.FriendGraveyard.Contains(Card.Cards.BT_307)//自己坟场有黑眼 Darkglare  ID：BT_307
               || board.FriendGraveyard.Contains(Card.Cards.SCH_140)//自己坟场有血肉巨人 Flesh Giant  ID：SCH_140
               || board.FriendGraveyard.Contains(Card.Cards.SCH_514) //自己坟场有熔核巨人 Molten Giant  ID：EX1_620
               || board.FriendGraveyard.Contains(Card.Cards.ICC_851) //自己坟场有凯雷塞斯王子 Prince Keleseth  ID：ICC_851
                 )
               {
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.SCH_514, new Modifier(-900));//亡者复生 Raise Dead  ID：SCH_514
               }
            // 场上有狗头人图书管理员，手上有亡者复生，送掉狗头人管理员
            if (board.HasCardOnBoard(Card.Cards.LOOT_014)//狗头人图书管理员 Kobold Librarian  ID：LOOT_014
                && board.HasCardInHand(Card.Cards.SCH_514)//亡者复生 Raise Dead  ID：SCH_514
                &&  board.HasCardOnBoard(Card.Cards.BT_307)//黑眼 Darkglare  ID：BT_307
                && !board.FriendGraveyard.Contains(Card.Cards.LOOT_014) 

               )
            {
                p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.LOOT_014, new Modifier(-30)); //狗头人图书管理员 Kobold Librarian  ID：LOOT_014
            }
             //坟场怪数量==0,不用亡者复生
            if (board.HasCardInHand(Card.Cards.SCH_514)//亡者复生 Raise Dead  ID：SCH_514
            && board.FriendGraveyard.Count ==0
                )
              {
              p.CastSpellsModifiers.AddOrUpdate(Card.Cards.SCH_514, new Modifier(9999));//亡者复生 Raise Dead  ID：SCH_514
              }
   //手上有亡者复生,场上有狗头人,增加狗头人送掉的优先值
            if (board.HasCardInHand(Card.Cards.SCH_514)//亡者复生 Raise Dead  ID：SCH_514
            && board.HasCardOnBoard(Card.Cards.LOOT_014)//狗头人图书管理员 Kobold Librarian  ID：LOOT_014
            && !board.FriendGraveyard.Contains(Card.Cards.LOOT_014)
                )
              {
              p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.LOOT_014, new Modifier(-20)); //狗头人图书管理员 Kobold Librarian  ID：LOOT_014
              }
//todo 甩笔侏儒相关
//todo 自伤自己怪
            //场上有黑眼，增加死缠打自己怪的优先度
            if ( board.HasCardOnBoard(Card.Cards.BT_307)//黑眼
               && board.HasCardInHand(Card.Cards.EX1_302)//死亡缠绕 Mortal Coil  ID：EX1_302
               && board.MinionEnemy.Count == 0
               || board.MinionFriend.Count ==7
                || board.HasCardInHand(Card.Cards.SCH_514)//亡者复生 Raise Dead  ID：SCH_514                
               )
            {
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_302, new Modifier(-60, Card.Cards.SCH_312)); //巡游向导 Tour Guide  ID：SCH_312死亡缠绕 Mortal Coil  ID：EX1_302
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_302, new Modifier(-9999, Card.Cards.LOOT_014)); //狗头人图书管理员 Kobold Librarian  ID：LOOT_014死亡缠绕 Mortal Coil  ID：EX1_302
            }

            //场上有黑眼，增加灵魂炸弹打自己怪的优先度
            if (board.HasCardOnBoard(Card.Cards.BT_307)//黑眼
               && board.HasCardInHand(Card.Cards.BOT_222)//灵魂炸弹 Spirit Bomb  ID：BOT_222
               && board.MinionEnemy.Count == 0
               || board.MinionFriend.Count == 7
                || board.HasCardInHand(Card.Cards.SCH_514)//亡者复生 Raise Dead  ID：SCH_514
               )
            {
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BOT_222, new Modifier(-60, Card.Cards.SCH_312)); //巡游向导 Tour Guide  ID：SCH_312灵魂炸弹 Spirit Bomb  ID：BOT_222
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BOT_222, new Modifier(-60, Card.Cards.BOT_447)); //晶化师 Crystallizer  ID：BOT_447灵魂炸弹 Spirit Bomb  ID：BOT_222
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BOT_222, new Modifier(-999, Card.Cards.LOOT_014)); //狗头人图书管理员 Kobold Librarian  ID：LOOT_014灵魂炸弹 Spirit Bomb  ID：BOT_222
                
            }
            //甩笔侏儒打脸
            if (board.HasCardOnBoard(Card.Cards.BT_307)//
               && board.HasCardInHand(Card.Cards.LOOT_043t2)//
               && board.HasCardInHand(Card.Cards.LOOT_043)//
               && board.ManaAvailable >=4
               )
            {
                 p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_248, new Modifier(-999, Card.Cards.LOOT_014));//提高甩笔侏儒 Pen Flinger  ID：SCH_248打自己脸优先度甩笔侏儒 Pen Flinger  ID：SCH_248
            }
//todo 矮劣魔相关
            //血量小于等于8 不用粗俗的矮劣魔粗俗的矮劣魔 Vulgar Homunculus  ID：LOOT_013
            if ( board.HasCardInHand(Card.Cards.LOOT_013)//粗俗的矮劣魔 Vulgar Homunculus  ID：LOOT_013
               && board.HeroFriend.CurrentHealth <= 8//自己英雄的健康
                )
            {
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_013, new Modifier(500));//粗俗的矮劣魔 Vulgar Homunculus  ID：LOOT_013
            }
//todo 深潜炸弹
            //如果对面场上有深潜炸弹 Depth Charge ID：DRG_078，不下黑眼 Darkglare ID：BT_307
            if (board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.DRG_078) //深潜炸弹 Depth Charge ID：DRG_078
               && board.HasCardInHand(Card.Cards.BT_307)//黑眼 Darkglare ID：BT_307
                )
            {
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BT_307, new Modifier(500));//黑眼 Darkglare ID：BT_307
            }
//todo 巨人相关
            //如果手上有熔核巨人，降低巨人，提高抽一口
            if (board.HasCardInHand(Card.Cards.EX1_620)//熔核巨人 Molten Giant  ID：EX1_620
                )
            {
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.HERO_07bp, new Modifier(-800));
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(-60, board.HeroEnemy.Id));
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_620, new Modifier(20)); //熔核巨人 Molten Giant  ID：EX1_620
            }
            //血量不少于15不下熔核巨人（不算护甲）
            if ((board.HeroFriend.CurrentHealth > 15)
                && board.HasCardInHand(Card.Cards.EX1_620)
                )
            {
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_620, new Modifier(999));//熔核巨人
            }
			else
			{
		//根据血量提高熔核巨人的优先级
				
			//血量小于等于10直接拍巨人
				if ((board.HeroFriend.CurrentHealth < 11)
                && board.HasCardInHand(Card.Cards.EX1_620))
				{
					p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_620, new Modifier(-999));//熔核巨人
				}
				else
				{
					int waldo =  (board.HeroFriend.CurrentHealth - 16) * 20;
					// 20血 优先级 1000 0
					// 15血 优先级 500 -500
					// 11血 优先级 100 -900
				p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_620, new Modifier(waldo));//熔核巨人
				}
			}
//todo洛欧塞布相关
            //如果下一轮可以斩杀对面提高洛欧塞布 Loatheb  ID：FP1_030
                if (board.HasCardInHand(Card.Cards.FP1_030)//洛欧塞布 Loatheb  ID：FP1_030
                && !board.MinionEnemy.Any(x => x.IsTaunt)
                && (BoardHelper.GetEnemyHealthAndArmor(board) - BoardHelper.GetPotentialMinionDamages(board) - BoardHelper.GetPlayableMinionSequenceDamages(BoardHelper.GetPlayableMinionSequence(board), board) <= BoardHelper.GetTotalBlastDamagesInHand(board))
                || myAttack >= (board.HeroEnemy.CurrentHealth) /2
                ){
					p.CastMinionsModifiers.AddOrUpdate(Card.Cards.FP1_030, new Modifier(-999));//洛欧塞布 Loatheb  ID：FP1_030
                }
           
            //如果场上多过4个怪，而且手上有洛欧塞布，提高洛欧塞布的优先级
			if (board.MinionFriend.Count >= 4
               && board.ManaAvailable >= 5
               && board.HasCardInHand(Card.Cards.FP1_030)
               )
            {
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.FP1_030 , new Modifier(-40));
            }
			//如果费用大于9，而且对面是德鲁伊，提高洛欧塞布的优先级
            if ((board.ManaAvailable >= 9)
               && (board.Hand.Exists(x => x.Template.Id == Card.Cards.FP1_030 ))
               && (board.EnemyClass == Card.CClass.DRUID)
               )
            {
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.FP1_030 , new Modifier(-50));
            }
			

//todo扫帚         
            //对面没随从,降低扫帚和巴罗夫优先级
			if (board.MinionEnemy.Count ==0
            && board.HasCardInHand(Card.Cards.SCH_311)//活化扫帚 Animated Broomstick  ID：SCH_311
            || board.HasCardInHand(Card.Cards.SCH_526)//巴罗夫领主 Lord Barov  ID：SCH_526
            )
			{
			p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_311, new Modifier(500)); //活化扫帚 Animated Broomstick  ID：SCH_311
			p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_526, new Modifier(500)); //巴罗夫领主 Lord Barov  ID：SCH_526
			}
//todo亵渎
              if (board.ManaAvailable <= 3
                 && board.HasCardInHand(Card.Cards.ICC_041)//亵渎 Defile  ID：ICC_041
                 && board.MinionEnemy.Sum(x => x.CurrentAtk) <6
                 
                 )

                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.ICC_041, new Modifier(999)); //亵渎 Defile  ID：ICC_041
                }//对面没随从，或者随从伤害低，不打亵渎
               
//todo 技能相关          
           //如果技能为0,用
           if (board.Ability.CurrentCost == 0
            )
               {
             p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(-800));
             p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.HERO_07bp, new Modifier(-800));
              }
// //todo沉默
           p.CastMinionsModifiers.AddOrUpdate(Card.Cards.CS2_203, new Modifier(-80, Card.Cards.BT_025));//优先使用猫头鹰沉默圣骑士的圣契
           p.CastMinionsModifiers.AddOrUpdate(Card.Cards.CS2_203, new Modifier(-80, Card.Cards.DMF_709e));//优先使用猫头鹰沉默埃索尔之力（萨满的大眼）  
           p.CastMinionsModifiers.AddOrUpdate(Card.Cards.CFM_696, new Modifier(-80, Card.Cards.BT_025));//优先使用衰变正义圣契
 
//todo随从相关
            // p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DMF_240, new Modifier(-350));//救赎者洛萨克森 Lothraxion the Redeemed ID：DMF_240
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_620, new Modifier(20)); //粗俗的矮劣魔 Vulgar Homunculus  ID：LOOT_013
            //p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_620, new Modifier(-25)); //熔核巨人 Molten Giant  ID：EX1_620
           //p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_248, new Modifier(200)); //甩笔侏儒 Pen Flinger  ID：SCH_248
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.ICC_700, new Modifier(100)); //开心的食尸鬼 Happy Ghoul  ID：ICC_700
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_415, new Modifier(-200)); //首席门徒林恩 Rin, the First Disciple  ID：LOOT_415
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DRG_209, new Modifier(-20)); //扭曲巨龙泽拉库 Zzeraku the Warped  ID：DRG_209
            //p.CastMinionsModifiers.AddOrUpdate(Card.Cards.ULD_163, new Modifier(-40)); //过期货物专卖商 Expired Merchant ID：ULD_163
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BT_301, new Modifier(20)); //夜影主母 Nightshade Matron  ID：BT_301
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_140, new Modifier(-20)); //血肉巨人 Flesh Giant  ID：SCH_140
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.ICC_701, new Modifier(-200)); //游荡恶鬼 Skulking Geist  ID：ICC_701
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BT_309, new Modifier(-40)); //坎雷萨德·埃伯洛克 Kanrethad Ebonlocke  ID：BT_309
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_713, new Modifier(-40));//异教低阶牧师 Cult Neophyte  ID：SCH_713
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_312, new Modifier(-40));//巡游向导 Tour Guide  ID：SCH_312
            // p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_312, new Modifier(999));//提克特斯 Tickatus ID：DMF_118 
            // p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DMF_118t, new Modifier(-999));//提克特斯 Tickatus ID：DMF_118t 
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_014, new Modifier(-500));//狗头人图书管理员 Kobold Librarian  ID：LOOT_014
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.KAR_089, new Modifier(-5));//玛克扎尔的小鬼 Malchezaar's Imp  ID：KAR_089
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.YOP_004, new Modifier(-40));//铁锈特使拉斯维克斯 Envoy Rustwix ID：YOP_004 
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.EX1_105, new Modifier(-40));//山岭巨人 Mountain Giant ID：EX1_105 

                    

//todo武器优先值
            // p.CastWeaponsModifiers.AddOrUpdate(Card.Cards.DRG_025, new Modifier(-80));//海盗之锚 Ancharrr  ID：DRG_025
//todo武器攻击保守性
            //  p.WeaponsAttackModifiers.AddOrUpdate(Card.Cards.OG_058, new Modifier(-20));//锈蚀铁钩 Rusty Hook  ID：OG_058
//todo法术
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_308, new Modifier(150));//灵魂之火 Soulfire  ID：EX1_308
             p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BT_300, new Modifier(200));//古尔丹之手 Hand of Gul'dan  ID：BT_300
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.SCH_307, new Modifier(-20));//校园精魂 School Spirits  ID：SCH_307
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.TRL_097, new Modifier(-80));//灵媒术 Seance  ID：TRL_097
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.DAL_602, new Modifier(-40));//情势反转 Plot Twist  ID：DAL_602
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_316, new Modifier(150));//力量的代价 Power Overwhelming  ID：EX1_316
//todo直伤法术优先值		
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BOT_222, new Modifier(250));//灵魂炸弹 Spirit Bomb  ID：BOT_222
            // p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_308, new Modifier(200));//灵魂之火
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CS2_062, new Modifier(300));//地狱烈焰
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.DRG_206, new Modifier(120));//火焰之雨
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.DMF_119, new Modifier(200));//邪恶低语 Wicked Whispers ID：DMF_119 
//todo提高术士的技能生命分流优先级
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(-20, board.HeroEnemy.Id));
             //提高术士的技能生命分流优先级
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(-20, board.HeroEnemy.Id));
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.HERO_07bp, new Modifier(-20, board.HeroEnemy.Id));
            p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(-20));
            p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.HERO_07bp, new Modifier(-20));
            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.HERO_07bp, new Modifier(-20));
            
           
//todo不送的怪
            p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.BT_307, new Modifier(150)); //修饰黑眼 Darkglare  ID：BT_307，数值越高越保守，就是不会拿去交换随从
            p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.BT_309, new Modifier(150)); //修饰坎雷萨德·埃伯洛克 Kanrethad Ebonlocke  ID：BT_309
            p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.KAR_089, new Modifier(150)); //修饰玛克扎尔的小鬼 Malchezaar's Imp  ID：KAR_089
 //todo 主动送的怪
            // p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.LOOT_014, new Modifier(-20)); //狗头人图书管理员 Kobold Librarian  ID：LOOT_014
            // p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.SCH_312, new Modifier(-5)); //巡游向导 Tour Guide  ID：SCH_312
            p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.ULD_163, new Modifier(-20)); //过期货物专卖商 Expired Merchant ID：ULD_163
            p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.YOP_004, new Modifier(-10)); //铁锈特使拉斯维克斯 Envoy Rustwix ID：YOP_004 
//todo坟场相关 
            //如果坟场没有狗头人,提高狗头人送的值
                      
            if(!board.FriendGraveyard.Contains(Card.Cards.DAL_570))
            {
            p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.LOOT_014, new Modifier(-20)); //狗头人图书管理员 Kobold 
            }
//todo随从打自己
           p.CastMinionsModifiers.AddOrUpdate(Card.Cards.TRL_512, new Modifier(-9999, board.HeroFriend.Id));//提高调皮的噬踝者打自己脸优先度调皮的噬踝者 Cheaty Anklebiter  ID：TRL_512
        //    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_248, new Modifier(-9999, board.HeroFriend.Id));//提高甩笔侏儒 Pen Flinger  ID：SCH_248打自己脸优先度甩笔侏儒 Pen Flinger  ID：SCH_248
           
//todo 詹迪斯·巴罗夫相关
			//场上有5个及以上的随从就不要用詹迪斯·巴罗夫 Jandice Barov ID：SCH_351
			if (board.MinionFriend.Count >= 5
			&& board.HasCardInHand(Card.Cards.SCH_351)
			){
				p.CastMinionsModifiers.AddOrUpdate(Card.Cards.SCH_351, new Modifier(600));//詹迪斯·巴罗夫 Jandice Barov ID：SCH_351
				Bot.Log("随从太多不用詹迪斯·巴罗夫");
			}
//todo 优先解得怪			
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
