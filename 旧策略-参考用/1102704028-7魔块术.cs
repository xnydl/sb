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


        //英雄能力优先级
        private readonly Dictionary<Card.Cards, int> _heroPowersPriorityTable = new Dictionary<Card.Cards, int>
        {
            {SteadyShot, 9},
            {DemonsbiteUp, 8},
            {LifeTap, 7},
            {DaggerMastery, 6},
            {Reinforce, 5},
            {Shapeshift, 4},
            {DemonsBite, 4},
            {Fireblast, 3},
            {ArmorUp, 2},
            {LesserHeal, 1}
        };

        //直伤卡牌
        private static readonly Dictionary<Card.Cards, int> _spellDamagesTable = new Dictionary<Card.Cards, int>
        {
            {Card.Cards.LOE_002, 3},//火把
            {Card.Cards.LOE_002t, 6},//炽热的火把
            {Card.Cards.CS2_029, 6},//火球
            {Card.Cards.BT_187, 3},//日怒
            {Card.Cards.BT_429p, 5},//恶魔冲击
            {Card.Cards.BT_429p2, 5},//恶魔冲击
            {Card.Cards.BT_495, 4},//刃缚精锐


        };

        
        //具体策略
        public ProfileParameters GetParameters(Board board)
        {

            Card z = board.Hand.Find(x => x.Template.Id > 0);
            Card y = board.Hand.FindLast(x => x.Template.Id > 0);
            int OutcastCards = board.Hand.Count(x => x.CurrentCost > 0 && BoardHelper.IsOutCastCard(x, board) == true);
                int GuldanOutcastCards= board.Hand.Count(x => x.CurrentCost > 0 && BoardHelper.IsGuldanOutCastCard(x, board) == true);


            Bot.Log("OutcastCards: " + (int)(OutcastCards+GuldanOutcastCards));
            //Bot.Log("玩家信息: " + rank+"/n"+Legend);

            var p = new ProfileParameters(BaseProfile.Rush) { DiscoverSimulationValueThresholdPercent = -10 };
            p.CastSpellsModifiers.AddOrUpdate(TheCoin, new Modifier(85));

            //自定义命名
            int a = (board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) - BoardHelper.GetEnemyHealthAndArmor(board);//敌我血量差
      


           

            //攻击模式切换
            if (board.EnemyClass == Card.CClass.DEMONHUNTER
                || board.EnemyClass == Card.CClass.HUNTER
                || board.EnemyClass == Card.CClass.ROGUE
                || board.EnemyClass == Card.CClass.SHAMAN
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


            {
                

                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CFM_608, new Modifier(150));//修饰爆精药水
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.ICC_206, new Modifier(9000));//修饰变节
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BOT_568, new Modifier(900));
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_017, new Modifier(1000, Card.Cards.NEW1_021));//黑暗契约不吸末日
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_043, new Modifier(100));//修饰紫水晶
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_043, new Modifier(100));//修饰紫水晶
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_043t2, new Modifier(100));//修饰紫水晶
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.OG_118, new Modifier(9999));//不打弃暗投明
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_017, new Modifier(100, Card.Cards.ULD_208));//黑暗契约不吸634
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.UNG_946, new Modifier(70));//修饰紫软
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.CFM_120, new Modifier(150));//修饰奶瓶
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DAL_615, new Modifier(2000, Card.Cards.LOOT_368));//不进化939
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DAL_615, new Modifier(2000, Card.Cards.GVG_021));//不进化马尔噶尼斯
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DAL_615, new Modifier(2000, Card.Cards.LOOT_415));//不进化林恩
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DAL_606, new Modifier(200, Card.Cards.LOOT_368));//不进化939
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DAL_615, new Modifier(200, Card.Cards.FP1_022));//不进化空灵
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DAL_606, new Modifier(2000, Card.Cards.ULD_208));//不进化634
                p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.LOOT_368, new Modifier(150));//不轻易送939
                p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DAL_615, new Modifier(3000, Card.Cards.ULD_208));


                if (!board.MinionEnemy.Any(x => x.IsTaunt) &&
                      (BoardHelper.GetEnemyHealthAndArmor(board) -
                       BoardHelper.GetPotentialMinionDamages(board) -
                       BoardHelper.GetPlayableMinionSequenceDamages(BoardHelper.GetPlayableMinionSequence(board), board) <=
                       BoardHelper.GetTotalBlastDamagesInHand(board)))
                {
                    p.GlobalAggroModifier = 450;
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.CFM_120, new Modifier(300));
                }//如果下一轮可以斩杀对面，攻击性提高

                if (board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.ULD_240))
                {
                    p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.ULD_240, new Modifier(100));
                }//如果对面场上有232，提高攻击优先度

                if (board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.BRM_002))
                {
                    p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.BRM_002, new Modifier(500));
                }//如果对面场上有火妖，提高攻击优先度

                if (board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.EX1_608))
                {
                    p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.EX1_608, new Modifier(100));
                }//如果对面场上有哀绿，提高攻击优先度

                if (board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.ULD_276))
                {
                    p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.ULD_276, new Modifier(100));
                }//如果对面场上有202，提高攻击优先度

                if (board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.GVG_069))
                {
                    p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.GVG_069, new Modifier(100));
                }//如果对面场上有533，提高攻击优先度

                if (board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.GVG_084))
                {
                    p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.GVG_084, new Modifier(300));
                }//如果对面场上有314，提高攻击优先度

                if (board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.GVG_006))
                {
                    p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.GVG_006, new Modifier(200));
                }//如果对面场上有223，提高攻击优先度

                if (board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.ULD_173))
                {
                    p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.ULD_173, new Modifier(300));
                }//如果对面场上有维西纳，提高攻击优先度

                if (board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.BRM_028))
                {
                    p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.BRM_028, new Modifier(100));
                }//如果对面场上有大帝，提高攻击优先度

                if (board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.BOT_103))
                {
                    p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.BOT_103, new Modifier(150));
                }//如果对面场上有露娜，提高攻击优先度

                if (board.EnemyClass == Card.CClass.PALADIN
                    && board.EnemyAbility.CurrentCost == 1
                    && (board.HeroEnemy.CurrentHealth + board.HeroEnemy.CurrentArmor) >= 20
                    && board.MinionEnemy.Count(minion => minion.Template.Id == Card.Cards.CS2_101t) >= 2)
                {
                    p.OnBoardBoardEnemyMinionsModifiers.AddOrUpdate(Card.Cards.CS2_101t, new Modifier(250));
                }//优先解报告兵

                if (board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_291)
                    || board.EnemyClass == Card.CClass.DRUID
                    || board.EnemyClass == Card.CClass.PRIEST
                    || board.EnemyClass == Card.CClass.WARRIOR
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.CFM_621)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_003)
                    && board.ManaAvailable >= 6
                    && board.EnemyDeckCount >= 10)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_415, new Modifier(0));
                }//对面是宇宙/otk卡组，提高林恩优先度

                if (board.MinionFriend.Any(minion => minion.Template.Id == Card.Cards.LOOT_415)
                    && (board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_291)
                    || board.EnemyClass == Card.CClass.DRUID
                    || board.EnemyClass == Card.CClass.PRIEST
                    || board.EnemyClass == Card.CClass.WARRIOR
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.CFM_621)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_003))
                    && board.EnemyDeckCount >= 8)
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_017, new Modifier(-1000, Card.Cards.LOOT_415));
                    p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.LOOT_415, new Modifier(-200));
                }//送掉林恩

                if (board.ManaAvailable == 6
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_415)
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_017)
                    && (board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_291)
                    || board.EnemyClass == Card.CClass.DRUID
                    || board.EnemyClass == Card.CClass.PRIEST
                    || board.EnemyClass == Card.CClass.WARRIOR
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.CFM_621)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_003))
                    && ((board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) - board.MinionEnemy.Sum(x => x.CurrentAtk) + board.MinionFriend.FindAll(x => x.IsTaunt && !x.IsSilenced).Sum(x => x.CurrentHealth) + 9 * board.MinionFriend.Count(x => x.Template.Id == Card.Cards.LOOT_368)) >= 10)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_415, new Modifier(300));
                }//6费不打林恩

                if (board.EnemyDeckCount >= 8
                     && (board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_291)
                    || board.EnemyClass == Card.CClass.DRUID
                    || board.EnemyClass == Card.CClass.PRIEST
                    || board.EnemyClass == Card.CClass.WARRIOR
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.CFM_621)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_003)))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_415t1, new Modifier(280));
                }
                else
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_415t1, new Modifier(300));
                }
                if (board.EnemyDeckCount >= 7
                     && (board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_291)
                    || board.EnemyClass == Card.CClass.DRUID
                    || board.EnemyClass == Card.CClass.PRIEST
                    || board.EnemyClass == Card.CClass.WARRIOR
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.CFM_621)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_003)))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_415t2, new Modifier(280));
                }
                else
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_415t2, new Modifier(300));
                }
                if (board.EnemyDeckCount >= 6
                     && (board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_291)
                    || board.EnemyClass == Card.CClass.DRUID
                    || board.EnemyClass == Card.CClass.PRIEST
                    || board.EnemyClass == Card.CClass.WARRIOR
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.CFM_621)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_003)))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_415t3, new Modifier(280));
                }
                else
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_415t3, new Modifier(300));
                }
                if (board.EnemyDeckCount >= 5
                     && (board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_291)
                    || board.EnemyClass == Card.CClass.DRUID
                    || board.EnemyClass == Card.CClass.PRIEST
                    || board.EnemyClass == Card.CClass.WARRIOR
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.CFM_621)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_003)))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_415t4, new Modifier(280));
                }
                else
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_415t4, new Modifier(300));
                }
                if (board.EnemyDeckCount >= 4
                     && (board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_291)
                    || board.EnemyClass == Card.CClass.DRUID
                    || board.EnemyClass == Card.CClass.PRIEST
                    || board.EnemyClass == Card.CClass.WARRIOR
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.CFM_621)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_003)))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_415t5, new Modifier(280));
                }
                else
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_415t5, new Modifier(300));
                }
                if (board.EnemyDeckCount > 0
                     && (board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_291)
                    || board.EnemyClass == Card.CClass.DRUID
                    || board.EnemyClass == Card.CClass.PRIEST
                    || board.EnemyClass == Card.CClass.WARRIOR
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.CFM_621)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_003)))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_415t6, new Modifier(280));
                }
                else
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_415t6, new Modifier(50));
                }

                if (board.ManaAvailable >= 10
                    && (board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_415t4) || board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_415t5) || board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_415t6))
                    && board.EnemyDeckCount > 0
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.ICC_831)
                    && ((board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) - board.MinionEnemy.Sum(x => x.CurrentAtk) + board.MinionFriend.FindAll(x => x.IsTaunt && !x.IsSilenced).Sum(x => x.CurrentHealth) + 9 * board.MinionFriend.Count(x => x.Template.Id == Card.Cards.LOOT_368)) >= 10)
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.ICC_831, new Modifier(5000));
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.OG_133, new Modifier(1000));
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_415t4, new Modifier(0));
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_415t5, new Modifier(0));
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_415t6, new Modifier(0));
                }//血量健康，优先爆牌库

                if (((board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) - board.MinionEnemy.Sum(x => x.CurrentAtk) + board.MinionFriend.FindAll(x => x.IsTaunt && !x.IsSilenced).Sum(x => x.CurrentHealth) + 9 * board.MinionFriend.Count(x => x.Template.Id == Card.Cards.LOOT_368)) >= 10)
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_312, new Modifier(200));
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GIL_825, new Modifier(600));
                }//血量健康，降低高弗雷、扭曲虚空优先级

                if ((board.MinionFriend.Count(x => x.Race == Card.CRace.DEMON) + board.Hand.Count(x => x.Race == Card.CRace.DEMON) + board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Race == Card.CRace.DEMON) - board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Id == Card.Cards.CS2_065) - board.MinionFriend.Count(x => x.Template.Id == Card.Cards.CS2_065) - 2 * board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Id == Card.Cards.LOOT_161)) >= 5)
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_317, new Modifier(500));
                }//牌库没有恶魔，不打感知恶魔
                else
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_317, new Modifier(-80));
                }
               
                
                if (board.Hand.Exists(x => x.Template.Id == Card.Cards.ICC_206)
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.NEW1_021))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.ICC_206, new Modifier(100, Card.Cards.NEW1_021));
                }

                if ((board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) <= 15
                    && !board.MinionFriend.Any(minion => minion.Template.Id == Card.Cards.GVG_021))
                {
                    p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(350));
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GVG_069, new Modifier(-30));
                }//生命少于15，减少抽牌

                if (board.EnemyClass == Card.CClass.MAGE
                    && ((board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) <= 18 || board.Hand.Count >= 7)
                    && !board.MinionFriend.Any(minion => minion.Template.Id == Card.Cards.GVG_021))
                {
                    p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(1000));
                }//对面是法师，减少抽牌

                if (board.ManaAvailable == 4
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.FP1_022)
                    && (board.Hand.Count(x => x.Race == Card.CRace.DEMON) - board.Hand.Count(x => x.Template.Id == Card.Cards.FP1_022)) > 0)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.FP1_022, new Modifier(-600));
                }//4费优先打空灵

                if (board.Hand.Exists(x => x.Template.Id == Card.Cards.FP1_022)
                    && (board.Hand.Count(x => x.Race == Card.CRace.DEMON) - board.Hand.Count(x => x.Template.Id == Card.Cards.FP1_022)) > 0
                    && board.ManaAvailable < 9)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.FP1_022, new Modifier(-400));
                }//优先打空灵

                if ((board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) <= 13
                    && !board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_043)
                    && !board.MinionFriend.Any(minion => minion.Template.Id == Card.Cards.GVG_021))
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_014, new Modifier(9000));
                }//血量低，不打狗头人管理员

                if (board.ManaAvailable >= 10
                    && board.SecretEnemy
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.ICC_831)
                    && (board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) < 10
                    && board.FriendGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.LOOT_368))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.ICC_831, new Modifier(-1000));
                }//10费对面有奥秘，打dk
                else if (board.ManaAvailable >= 10
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.ICC_831)
                    && ((board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) - board.MinionEnemy.Sum(x => x.CurrentAtk) + board.MinionFriend.FindAll(x => x.IsTaunt && !x.IsSilenced).Sum(x => x.CurrentHealth) + 9 * board.MinionFriend.Count(x => x.Template.Id == Card.Cards.LOOT_368)) <= 10
                    && board.FriendGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.LOOT_368))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.ICC_831, new Modifier(-1000));
                }//10费对面有奥秘，打dk

                if (board.ManaAvailable >= 5
                    && (board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) >= 25
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.GVG_069))
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GVG_069, new Modifier(300));
                }//血量健康，不打老司机

                if ((board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) <= 13)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GVG_069, new Modifier(0));
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_043, new Modifier(-10));
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_043t3, new Modifier(-10));
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_043t2, new Modifier(-10));
                }//血量不健康，打老司机

                if (board.ManaAvailable == 3
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.EX1_317)
                    && board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.NEW1_021))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_317, new Modifier(-200));
                    p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(300));
                }//3费对面有末日，打感知恶魔

                if (board.EnemyGraveyard.Contains(Card.Cards.EX1_050)
                    && board.EnemyClass == Card.CClass.ROGUE)
                {
                    p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(300));
                }//对阵爆牌贼，不抽

                if ((board.ManaAvailable == 3 || board.ManaAvailable == 4)
                    && board.Hand.Count == 9
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.GAME_005)
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.EX1_317))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_317, new Modifier(-500));
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.GAME_005, new Modifier(-5000));
                }//防止感知恶魔爆牌
                else if (board.Hand.Count == 10
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.EX1_317))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_317, new Modifier(200));
                }//防止感知恶魔爆牌

                if (board.ManaAvailable == 3
                   && board.Hand.Exists(x => x.Template.Id == Card.Cards.EX1_317))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.EX1_317, new Modifier(-200));
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.GVG_015, new Modifier(200));
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_014, new Modifier(500));
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.NEW1_021, new Modifier(500));
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.CFM_120, new Modifier(500));
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DAL_606, new Modifier(200));
                }//3费打感知恶魔

                if (board.ManaAvailable == 1
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.GAME_005)
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.NEW1_021)
                    && board.MinionEnemy.Sum(x => x.CurrentAtk) < 3)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.NEW1_021, new Modifier(150));
                }//一费不打末日

                if (board.MinionFriend.Any(minion => minion.Template.Id == Card.Cards.LOOT_368)
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.GVG_021)
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_368)
                    && board.ManaAvailable >= 9
                    && (board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) <= 15)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GVG_021, new Modifier(-20));
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_368, new Modifier(150));
                }
                //生命小于15，优先下玛咖尼斯

                if (board.MinionEnemy.Sum(x => x.CurrentAtk) < 4
                   && ((board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) - board.MinionEnemy.Sum(x => x.CurrentAtk) + board.MinionFriend.FindAll(x => x.IsTaunt && !x.IsSilenced).Sum(x => x.CurrentHealth) + 9 * board.MinionFriend.Count(x => x.Template.Id == Card.Cards.LOOT_368)) >= 15
                    && !board.MinionFriend.Any(minion => minion.Template.Id == Card.Cards.ULD_163))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CS2_062, new Modifier(200));
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.ICC_041, new Modifier(400));
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.LOOT_043, new Modifier(200));
                }//对面怪攻击低,降低亵渎、地狱烈焰、紫水晶优先度

                if (board.Hand.Exists(x => x.Template.Id == Card.Cards.NEW1_021)
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.ICC_206)
                    && board.MinionEnemy.Sum(x => x.CurrentAtk) < 7)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.NEW1_021, new Modifier(600));
                }//手里有变节，降低末日优先度

                if (board.MinionFriend.Any(minion => minion.Template.Id == Card.Cards.NEW1_021))
                {
                    p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.LOOT_368, new Modifier(1000));
                    p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.ULD_208, new Modifier(1000));
                    p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.CS2_065, new Modifier(1000));
                }//下末日，保嘲讽

                if (board.ManaAvailable >= 10
                    && (board.EnemyDeckCount - board.FriendDeckCount) >= 3
                    && board.Hand.Count >= 7)
                {
                    p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(800));
                }//减少抽牌

                if (!board.SecretEnemy)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.OG_254, new Modifier(300));
                }//对面没有奥秘，不下张杰

                if (board.ManaAvailable >= 9
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.ICC_831)
                    && board.FriendGraveyard.Count(card => CardTemplate.LoadFromId(card).Race == Card.CRace.DEMON) <= 2
                    && ((board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) - board.MinionEnemy.Sum(x => x.CurrentAtk) + board.MinionFriend.FindAll(x => x.IsTaunt && !x.IsSilenced).Sum(x => x.CurrentHealth) + 9 * board.MinionFriend.Count(x => x.Template.Id == Card.Cards.LOOT_368)) >= 10)
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.ICC_831, new Modifier(800));
                }//墓地恶魔少，不打dk

                if (((board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) - board.MinionEnemy.Sum(x => x.CurrentAtk)) <= 13
                    && !board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_043)
                    && !board.MinionFriend.Any(minion => minion.Template.Id == Card.Cards.GVG_021))
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_014, new Modifier(9000));
                }//血量低，不打狗头人管理员

                if (board.MinionEnemy.Count == 0
                    && (board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) >= 19)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.NEW1_021, new Modifier(500));
                }//对面没随从，并且血量健康，不下末日

                if (board.MinionFriend.Any(minion => minion.Template.Id == Card.Cards.FP1_022)
                    && (board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_415t6))
                    && board.EnemyDeckCount > 0)
                {
                    p.OnBoardFriendlyMinionsValuesModifiers.AddOrUpdate(Card.Cards.FP1_022, new Modifier(9000));
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_415t6, new Modifier(-50));
                }//手里有阿扎里，场上空灵不送

                if (board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_415t5) || board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_415t4))
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.FP1_022, new Modifier(500));
                }

                if (board.MinionFriend.Any(minion => minion.Template.Id == Card.Cards.LOOT_415)
                    && board.Hand.Count >= 8)
                {
                    p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(1000));
                }//场上有林恩，不抽牌

                if (board.EnemyClass == Card.CClass.MAGE
                    && board.ManaAvailable < 6)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.UNG_946, new Modifier(500));
                }//对阵法师，6费前不下软泥怪

                if (board.EnemyClass == Card.CClass.MAGE
                    && board.WeaponEnemy != null)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.UNG_946, new Modifier(-300));
                }//对阵奥秘法，吃刀


                if (board.EnemyClass == Card.CClass.MAGE
                    && board.WeaponEnemy == null
                    && (board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.CFM_066)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.CFM_066)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.KAR_092)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.LOE_002)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_293)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.FP1_004)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.CS2_029)
                    || board.EnemyGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.CFM_760)))
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.UNG_946, new Modifier(700));
                }//对阵奥秘法，对面没有刀，不下软泥怪

                if (board.Hand.Exists(x => x.Template.Id == Card.Cards.OG_133)
                    && (!board.FriendGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.LOOT_368)
                    && !board.FriendGraveyard.Any(card => CardTemplate.LoadFromId(card).Id == Card.Cards.ULD_208)))
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.OG_133, new Modifier(300));
                }//没有634或者939，不打恩佐斯

                if ((board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) <= 16)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.ULD_208, new Modifier(-50));
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.LOOT_415, new Modifier(80));
                }//血量低，优先634

                if (board.ManaAvailable == 3
                    && board.Hand.Count(x => x.Template.Id == Card.Cards.FP1_022) == 2
                    && board.Hand.Count(x => x.Race == Card.CRace.DEMON) == 2)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.FP1_022, new Modifier(200));
                }//手上只有两个空灵，3费不跳费下

                if (board.ManaAvailable < 10
                    && board.EnemyClass == Card.CClass.WARLOCK
                    && board.WeaponEnemy == null)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.UNG_946, new Modifier(250));
                }//对阵术士，对面没刀不下软泥怪

                if ((board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor) >= 15)
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.NEW1_003, new Modifier(1500, Card.Cards.LOOT_368));
                }//血量健康，不吸939

                if (board.Hand.Count >= 8
                    && board.ManaAvailable == 4
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.DAL_606)
                    && board.MinionFriend.Count >= 0
                    || board.Hand.Count >= 9)
                {
                    p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(1000));
                }//手上有怪盗天才或者手牌10张，防爆牌

                if (board.ManaAvailable == 2
                    && (board.Hand.Exists(x => x.Template.Id == Card.Cards.FP1_007) || board.Hand.Exists(x => x.Template.Id == Card.Cards.ULD_174))
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.DAL_606))
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.FP1_007, new Modifier(50));
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.ULD_174, new Modifier(50));
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DAL_606, new Modifier(200));

                }//两费，先下蛋

                if (board.MinionEnemy.Count == 0
                    || board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.NEW1_021)
                    || board.MinionEnemy.Sum(x => x.CurrentAtk) <= 5)
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.ULD_717, new Modifier(5000));
                }//对面没随从，或者随从伤害低，不打1费法术

                if (board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_415t1)
                    || board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_415t2)
                    || board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_415t3)
                    || board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_415t4)
                    || board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_415t5))
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BOT_548, new Modifier(150));
                }//手里有任务，降低奇利亚斯优先度

                if (board.ManaAvailable <= 3)
                {
                    p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DAL_606, new Modifier(300, Card.Cards.CFM_120));
                }//4费前怪盗天才不吃奶瓶

                if (board.MinionEnemy.Sum(x => x.CurrentAtk) <= 2)
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BRM_005, new Modifier(500));
                }//降低恶魔之怒优先度

                if (board.Hand.Count >= 8
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.LOOT_415)
                    && board.ManaAvailable >= 8)
                {
                    p.CastHeroPowerModifier.AddOrUpdate(Card.Cards.CS2_056_H1, new Modifier(300));
                }//减少抽牌

                if (board.EnemyClass == Card.CClass.MAGE
                    && board.SecretEnemy
                    && board.Hand.Exists(x => x.Template.Id == Card.Cards.GAME_005)
                    && board.TurnCount >= 3)
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.GAME_005, new Modifier(-500));
                }//对面法师有奥秘，先打硬币

                if (board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.FP1_022)
                    && !board.MinionFriend.Any(minion => minion.Template.Id == Card.Cards.FP1_022))
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.NEW1_003, new Modifier(9000, Card.Cards.FP1_022));
                }//不吸对面空灵

                if (board.MinionEnemy.Any(minion => minion.Template.Id == Card.Cards.FP1_022)
                    && board.MinionFriend.Any(minion => minion.Template.Id == Card.Cards.FP1_022)
                    && (board.Hand.Count(x => x.Race == Card.CRace.DEMON) - board.Hand.Count(x => x.Template.Id == Card.Cards.FP1_022)) == 0)
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.NEW1_003, new Modifier(9000, Card.Cards.FP1_022));
                }//不吸对面空灵


            }




            //法术优先值

            p.CastSpellsModifiers.AddOrUpdate(Card.Cards.TB_011, new Modifier(50));   //硬币
          
           
//随从优先值
            //降低玛维优先级
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BT_737, new Modifier(80));
              //焦油爬行者
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.UNG_928, new Modifier(-40));
            //萨特监工
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.BT_352, new Modifier(-10));
            //荆棘帮暴徒Card.Cards.GIL_534,//荆棘帮暴徒
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.GIL_534, new Modifier(-80));
            //喷灯破坏者
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.DRG_403, new Modifier(-70));
            //异种群居蝎 
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.OG_034, new Modifier(-40));
            //南海船工
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.CS2_146, new Modifier(-40));
            //南海船长
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.NEW1_027, new Modifier(-40));
            //血帆海盗 Bloodsail Corsair  ID：NEW1_025
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.NEW1_025, new Modifier(-60));
            //贪食软泥怪 Gluttonous Ooze  ID：UNG_946
            p.CastMinionsModifiers.AddOrUpdate(Card.Cards.UNG_946, new Modifier(100));




            //武器优先值
            //提高蛋刀优先级
            p.CastWeaponsModifiers.AddOrUpdate(Card.Cards.BT_430, new Modifier(-80));//  Card.Cards.BT_430,//埃辛诺斯战刃
           


            //武器攻击保守性
            //  p.WeaponsAttackModifiers.AddOrUpdate(Card.Cards.OG_058, new Modifier(-20));//锈蚀铁钩 Rusty Hook  ID：OG_058



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
