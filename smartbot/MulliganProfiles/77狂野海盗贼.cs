using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;
// ### 潜行者
// # 职业：潜行者
// # 模式：狂野模式
// #
// # 2x (1) 南海船工
// # 2x (1) 奖品掠夺者
// # 2x (1) 影袭
// # 1x (1) 海盗帕奇斯
// # 2x (1) 秘密通道 SCH_305 
// # 2x (1) 致命药膏
// # 2x (1) 锈水海盗 CORE_AT_029 
// # 2x (1) 鱼排斗士 TSC_963
// # 2x (2) 洞穴探宝者 LOOT_033
// # 2x (2) 空降歹徒 DRG_056
// # 2x (2) 船载火炮 GVG_075 
// # 2x (2) 雾帆劫掠者
// # 2x (3) 剑鱼 TSC_086
// # 2x (4) 恐怖海盗 VAN_NEW1_022
// # 2x (5) 劈砍课程 SCH_623
// # 1x (6) 重拳先生
// # 
// AAEBAbfyBAKRvAK/gAQO1AXuBvsP5dEC6bADqssD99QD890DpooEkp8ElJ8EiskE/dMEmtsEAA==
// # 
// # 想要使用这副套牌，请先复制到剪贴板，然后在游戏中点击“新套牌”进行粘贴。
// ### Rogue
// # 职业：潜行者
// # 模式：狂野模式
// #
// # 2x (0) 伺机待发 CORE_EX1_145 
// # 2x (1) 鱼排斗士 TSC_963
// # 2x (1) 锈水海盗 CORE_AT_029
// # 2x (1) 致命药膏
// # 2x (1) 秘密通道
// # 1x (1) 海盗帕奇斯
// # 2x (1) 奖品掠夺者
// # 2x (1) 南海船工 CS2_146
// # 2x (2) 船载火炮 GVG_075
// # 2x (2) 空降歹徒 DRG_056
// # 2x (3) 团伙劫掠 TRL_124 
// # 2x (3) 南海船长
// # 2x (3) 剑鱼 TSC_086
// # 2x (4) 恐怖海盗
// # 2x (5) 劈砍课程
// # 1x (6) 重拳先生
// #
// AAEBAaIHApG8Ar+ABA7UBe4G+w/VjAPpsAOqywP31APz3QOSnwT3nwSvoASKyQT90wSa2wQA
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/C5hcMC35SdKwjPXifdsNse/

namespace SmartBot.Mulligan
{
    [Serializable]
    public class DefaultMulliganProfile : MulliganProfile
    {
        List<Card.Cards> CardsToKeep = new List<Card.Cards>();

        private readonly List<Card.Cards> WorthySpells = new List<Card.Cards>
        {
            
        };

        public List<Card.Cards> HandleMulligan(List<Card.Cards> choices, Card.CClass opponentClass,
            Card.CClass ownClass)
        {
            bool HasCoin = choices.Count >= 4;

            int flag1=0;//剑鱼 TSC_086
            int flag2=0;//团伙劫掠 TRL_124 
            
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.TSC_086//剑鱼 TSC_086
                ){flag1+=1;}
                if(card==Card.Cards.LOOT_033//洞穴探宝者 LOOT_033
                ){flag1+=1;}
                if(card==Card.Cards.TRL_124//团伙劫掠 TRL_124  
                ){flag2+=1;}
            }

            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.CORE_AT_029// 锈水海盗 CORE_AT_029
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CORE_AT_029))
                    {
                        Keep(card,"锈水海盗");
                    } 
                }
                if(card==Card.Cards.TSC_963// 鱼排斗士 TSC_963
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_963))
                    {
                        Keep(card,"鱼排斗士");
                    } 
                }
                if(card==Card.Cards.CORE_EX1_145&&flag2>0// 伺机待发 CORE_EX1_145 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CORE_EX1_145))
                    {
                        Keep(card,"伺机待发");
                    } 
                }
                if(card==Card.Cards.CS2_146// 南海船工 CS2_146
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CS2_146))
                    {
                        Keep(card,"南海船工");
                    } 
                }
                if(card==Card.Cards.LOOT_033// 洞穴探宝者 LOOT_033
                ){
                    if(!CardsToKeep.Contains(Card.Cards.LOOT_033))
                    {
                        Keep(card,"洞穴探宝者");
                    } 
                }
                if(card==Card.Cards.DRG_056// 空降歹徒 DRG_056
                ){
                    if(!CardsToKeep.Contains(Card.Cards.DRG_056))
                    {
                        Keep(card,"空降歹徒");
                    } 
                }
                if(card==Card.Cards.GVG_075// 船载火炮 GVG_075
                ){
                    if(!CardsToKeep.Contains(Card.Cards.GVG_075))
                    {
                        Keep(card,"船载火炮");
                    } 
                }
                if(card==Card.Cards.CORE_AT_029// 锈水海盗 CORE_AT_029
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CORE_AT_029))
                    {
                        Keep(card,"锈水海盗");
                    } 
                }
                if(card==Card.Cards.TSC_086// 剑鱼 TSC_086
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_086))
                    {
                        Keep(card,"剑鱼");
                    } 
                }
                if(card==Card.Cards.TRL_124// 团伙劫掠 TRL_124 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TRL_124))
                    {
                        Keep(card,"团伙劫掠");
                    } 
                }
                if(card==Card.Cards.VAN_NEW1_022&&flag1>0// 恐怖海盗 VAN_NEW1_022
                ){
                    if(!CardsToKeep.Contains(Card.Cards.VAN_NEW1_022))
                    {
                        Keep(card,"恐怖海盗");
                    } 
                }
                if(card==Card.Cards.SCH_623&&flag1>0// 劈砍课程 SCH_623
                ){
                    if(!CardsToKeep.Contains(Card.Cards.SCH_623))
                    {
                        Keep(card,"劈砍课程");
                    } 
                }
            }
            return CardsToKeep;
        }

        private void Keep(Card.Cards id, string log = "")
        {
            CardsToKeep.Add(id);
            if(log != "")
                Bot.Log(log);
        }

    }
}//德：DRUID 猎：HUNTER 法：MAGE 骑：PALADIN 牧：PRIEST 贼：ROGUE 萨：SHAMAN 术：WARLOCK 战：WARRIOR 瞎：DEMONHUNTER