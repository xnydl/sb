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
            
            {Card.Cards.GVG_038,3},//连环爆裂 Crackle  ID：GVG_038
            {Card.Cards.BT_100, 3},//毒蛇神殿传送门 Serpentshrine Portal  ID：BT_100
            {Card.Cards.TRL_012, 2},//图腾重击 Totemic Smash  ID：TRL_012
            {Card.Cards.CFM_707, 4},//青玉闪电 Jade Lightning  ID：CFM_707
            {Card.Cards.BRM_011, 2},//熔岩震击 Lava Shock  ID：BRM_011
            {Card.Cards.EX1_238, 3},//闪电箭 Lightning Bolt  ID：EX1_238
            {Card.Cards.EX1_241, 5},//熔岩爆裂 Lava Burst  ID：EX1_241
            {Card.Cards.CS2_037, 1},//冰霜震击 Frost Shock  ID：CS2_037
            {Card.Cards.DAL_614, 2},//狗头人跟班 Kobold Lackey  ID：DAL_614


        };


        //攻击模式
        public ProfileParameters GetParameters(Board board)
        {


            var p = new ProfileParameters(BaseProfile.Default);
            p.DiscoverSimulationValueThresholdPercent = 10;

            //具体策略










               
                //当手上有大哥时，增加先祖召唤优先级
                if (board.HasCardInHand(Card.Cards.GVG_029)// Card.Cards.GVG_029,//先祖召唤
                    && board.HasCardInHand(Card.Cards.DAL_047)//Card.Cards.DAL_047,//活动喷泉 
                    || board.HasCardInHand(Card.Cards.ICC_314)//巫妖王 The Lich King  ID：ICC_314
                    || board.HasCardInHand(Card.Cards.OG_042)// Card.Cards.OG_042,//亚煞极
                    || board.HasCardInHand(Card.Cards.ULD_721)// Card.Cards.ULD_721,//月亮巨人守护者
                    || board.HasCardInHand(Card.Cards.BT_155)//  Card.Cards.BT_155,//废料场巨像
                                   )
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.GVG_029, new Modifier(-200));//Card.Cards.GVG_029,//先祖召唤

                }
                
                //当手上有大哥时，增加我找到了优先级
                if (board.HasCardInHand(Card.Cards.BOT_099)//   Card.Cards.BOT_099,//我找到了
                    && board.HasCardInHand(Card.Cards.DAL_047)//Card.Cards.DAL_047,//活动喷泉 
                    || board.HasCardInHand(Card.Cards.ICC_314)//巫妖王 The Lich King  ID：ICC_314
                    || board.HasCardInHand(Card.Cards.OG_042)// Card.Cards.OG_042,//亚煞极
                    || board.HasCardInHand(Card.Cards.ULD_721)// Card.Cards.ULD_721,//月亮巨人守护者
                    || board.HasCardInHand(Card.Cards.BT_155)//  Card.Cards.BT_155,//废料场巨像
                                   )
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BOT_099, new Modifier(-300));// Card.Cards.BOT_099,//我找到了

                }
                

                //当场上有大哥时，增加Card.Cards.CS2_038,//先祖之魂 优先级
                if (board.HasCardInHand(Card.Cards.CS2_038)//   Card.Cards.CS2_038,//先祖之魂 
                    && board.HasCardOnBoard(Card.Cards.DAL_047)//Card.Cards.DAL_047,//活动喷泉 
                    || board.HasCardOnBoard(Card.Cards.ICC_314)//巫妖王 The Lich King  ID：ICC_314
                    || board.HasCardOnBoard(Card.Cards.OG_042)// Card.Cards.OG_042,//亚煞极
                    || board.HasCardOnBoard(Card.Cards.ULD_721)// Card.Cards.ULD_721,//月亮巨人守护者
                    || board.HasCardOnBoard(Card.Cards.BT_155)//  Card.Cards.BT_155,//废料场巨像
                                   )
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.CS2_038, new Modifier(-200));//  Card.Cards.CS2_038,//先祖之魂 

                }
               
                //当场上有大哥时，增加 Card.Cards.LOOT_064,//小型法术蓝宝石
                if (board.HasCardInHand( Card.Cards.LOOT_064)//    Card.Cards.LOOT_064,//小型法术蓝宝石
                    && board.HasCardOnBoard(Card.Cards.DAL_047)//Card.Cards.DAL_047,//活动喷泉 
                    || board.HasCardOnBoard(Card.Cards.ICC_314)//巫妖王 The Lich King  ID：ICC_314
                    || board.HasCardOnBoard(Card.Cards.OG_042)// Card.Cards.OG_042,//亚煞极
                    || board.HasCardOnBoard(Card.Cards.ULD_721)// Card.Cards.ULD_721,//月亮巨人守护者
                    || board.HasCardOnBoard(Card.Cards.BT_155)//  Card.Cards.BT_155,//废料场巨像
                                   )
                {
                    p.CastSpellsModifiers.AddOrUpdate( Card.Cards.LOOT_064, new Modifier(-250));//   Card.Cards.LOOT_064,//小型法术蓝宝石

                }
               

                //当场上有大哥时，增加 Card.Cards.BT_101,//鲜活孢子
                if (board.HasCardInHand( Card.Cards.BT_101)//    Card.Cards.BT_101,//鲜活孢子
                    && board.HasCardOnBoard(Card.Cards.DAL_047)//Card.Cards.DAL_047,//活动喷泉 
                    || board.HasCardOnBoard(Card.Cards.ICC_314)//巫妖王 The Lich King  ID：ICC_314
                    || board.HasCardOnBoard(Card.Cards.OG_042)// Card.Cards.OG_042,//亚煞极
                    || board.HasCardOnBoard(Card.Cards.ULD_721)// Card.Cards.ULD_721,//月亮巨人守护者
                    || board.HasCardOnBoard(Card.Cards.BT_155)//  Card.Cards.BT_155,//废料场巨像
                                   )
                {
                    p.CastSpellsModifiers.AddOrUpdate( Card.Cards.BT_101, new Modifier(-200));//   Card.Cards.BT_101,//鲜活孢子

                }
               


                
                //费用等于3，手上有先祖召唤和大哥，不用毒蛇神殿传送门

                if (board.ManaAvailable ==3
                    && board.HasCardInHand(Card.Cards.GVG_029)// Card.Cards.GVG_029,//先祖召唤
                     && board.HasCardInHand(Card.Cards.BT_100)//  Card.Cards.BT_100,//毒蛇神殿传送门
                    && board.HasCardInHand(Card.Cards.DAL_047)//Card.Cards.DAL_047,//活动喷泉 
                    || board.HasCardInHand(Card.Cards.ICC_314)//巫妖王 The Lich King  ID：ICC_314
                    || board.HasCardInHand(Card.Cards.OG_042)// Card.Cards.OG_042,//亚煞极
                    || board.HasCardInHand(Card.Cards.ULD_721)// Card.Cards.ULD_721,//月亮巨人守护者
                    || board.HasCardInHand(Card.Cards.BT_155)//  Card.Cards.BT_155,//废料场巨像
                    )
            {
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BT_100, new Modifier(200));//Card.Cards.BT_100,//毒蛇神殿传送门
                }

                // 费用等于3，手上有先祖召唤和大哥，不用先祖知识 Ancestral Knowledge  ID：AT_053

                if (board.ManaAvailable == 3
                    && board.HasCardInHand(Card.Cards.GVG_029)// Card.Cards.GVG_029,//先祖召唤
                     && board.HasCardInHand(Card.Cards.AT_053)//  先祖知识 Ancestral Knowledge  ID：AT_053
                    && board.HasCardInHand(Card.Cards.DAL_047)//Card.Cards.DAL_047,//活动喷泉 
                    || board.HasCardInHand(Card.Cards.ICC_314)//巫妖王 The Lich King  ID：ICC_314
                    || board.HasCardInHand(Card.Cards.OG_042)// Card.Cards.OG_042,//亚煞极
                    || board.HasCardInHand(Card.Cards.ULD_721)// Card.Cards.ULD_721,//月亮巨人守护者
                    || board.HasCardInHand(Card.Cards.BT_155)//  Card.Cards.BT_155,//废料场巨像
                    )
                {
                    p.CastSpellsModifiers.AddOrUpdate(Card.Cards.AT_053, new Modifier(200));//先祖知识 Ancestral Knowledge  ID：AT_053
                }


            //费用等于5，手上有我找到了和大哥，不用毒蛇神殿传送门

            if (board.ManaAvailable ==5
                && board.HasCardInHand(Card.Cards.BOT_099)// Card.Cards.BOT_099,//我找到了
                 && board.HasCardInHand(Card.Cards.BT_100)//  Card.Cards.BT_100,//毒蛇神殿传送门
                && board.HasCardInHand(Card.Cards.DAL_047)//Card.Cards.DAL_047,//活动喷泉 
                || board.HasCardInHand(Card.Cards.ICC_314)//巫妖王 The Lich King  ID：ICC_314
                || board.HasCardInHand(Card.Cards.OG_042)// Card.Cards.OG_042,//亚煞极
                || board.HasCardInHand(Card.Cards.ULD_721)// Card.Cards.ULD_721,//月亮巨人守护者
                || board.HasCardInHand(Card.Cards.BT_155)//  Card.Cards.BT_155,//废料场巨像
                )
            {
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.BT_100, new Modifier(200));//Card.Cards.BT_100,//毒蛇神殿传送门
            }

            // 费用等于5，手上有我找到了和大哥，不用先祖知识 Ancestral Knowledge  ID：AT_053

            if (board.ManaAvailable == 5
                && board.HasCardInHand(Card.Cards.BOT_099)// Card.Cards.BOT_099,//我找到了
                 && board.HasCardInHand(Card.Cards.AT_053)//  先祖知识 Ancestral Knowledge  ID：AT_053
                && board.HasCardInHand(Card.Cards.DAL_047)//Card.Cards.DAL_047,//活动喷泉 
                || board.HasCardInHand(Card.Cards.ICC_314)//巫妖王 The Lich King  ID：ICC_314
                || board.HasCardInHand(Card.Cards.OG_042)// Card.Cards.OG_042,//亚煞极
                || board.HasCardInHand(Card.Cards.ULD_721)// Card.Cards.ULD_721,//月亮巨人守护者
                || board.HasCardInHand(Card.Cards.BT_155)//  Card.Cards.BT_155,//废料场巨像
                )
            {
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.AT_053, new Modifier(200));//先祖知识 Ancestral Knowledge  ID：AT_053
            }

            //武器优先值
            // p.CastWeaponsModifiers.AddOrUpdate(Card.Cards.DRG_025, new Modifier(-80));//海盗之锚 Ancharrr  ID：DRG_025
             p.CastWeaponsModifiers.AddOrUpdate(Card.Cards.YOD_042, new Modifier(-80));//Card.Cards.YOD_042,//莱登之拳



            //武器攻击保守性
            //  p.WeaponsAttackModifiers.AddOrUpdate(Card.Cards.OG_058, new Modifier(-20));//锈蚀铁钩 Rusty Hook  ID：OG_058
            p.WeaponsAttackModifiers.AddOrUpdate(Card.Cards.YOD_042, new Modifier(200));//Card.Cards.YOD_042,//莱登之拳



                //法术

                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.GAME_005, new Modifier(50));//幸运币 The Coin  ID：GAME_005
                                                                                     
               // p.CastSpellsModifiers.AddOrUpdate(Card.Cards.GVG_038, new Modifier(100));//连环爆裂 Crackle  ID：GVG_038
                p.CastSpellsModifiers.AddOrUpdate(Card.Cards.AT_053, new Modifier(-60));//先祖知识 Ancestral Knowledge  ID：AT_053




                //随从优先值


               // p.CastMinionsModifiers.AddOrUpdate(Card.Cards.ULD_177, new Modifier(-60)); //八爪巨怪 Octosari  ID：ULD_177提高优先级
                                                               
                


                //随从优先解
              




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
