using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;
// ### 法师
// # 职业：法师
// # 模式：狂野模式
// #
// # 2x (1) 可靠的灯泡
// # 2x (1) 机械袋鼠 BOT_445 
// # 2x (1) 械钳虾 TSC_632
// # 2x (1) 滑板机器人
// # 2x (2) 安保自动机 TSC_928
// # 2x (2) 怨灵之书 GIL_548
// # 2x (2) 星占师 BT_014 
// # 2x (2) 机械跃迁者 GVG_006 
// # 2x (2) 海沟勘测机
// # 2x (2) 深海融合怪
// # 2x (2) 通电机器人 BOT_907
// # 2x (3) A3型机械金刚
// # 2x (3) 机械鲨鱼
// # 2x (3) 海床传送口
// # 2x (3) 艾萨拉的清道夫
// # 
// AAEBAcz6AwAPlA/O7wKf9QKZ9wL2/QLX/gL3uAOStQThtQTJtwTKtwTduQSywQTY2QSUpAUA
// # 
// # 想要使用这副套牌，请先复制到剪贴板，然后在游戏中点击“新套牌”进行粘贴。

// ### 机械法
// # 职业：法师
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (1) 械钳虾 TSC_632 
// # 2x (2) 矿道工程师 SW_059
// # 2x (2) 深海融合怪
// # 2x (2) 海沟勘测机 TSC_642
// # 2x (2) 安保自动机 TSC_928
// # 2x (2) 吵吵机器人 BOT_270t
// # 2x (3) 艾萨拉的清道夫 TSC_776 
// # 2x (3) 海底侦察兵
// # 2x (3) 海床传送口 TSC_055 
// # 2x (3) 机械鲨鱼 TSC_054 
// # 2x (3) 奥术智慧
// # 2x (3) A3型机械金刚
// # 2x (4) 火球术
// # 1x (5) 伊妮·积雷
// # 2x (6) 母舰
// # 1x (8) 盖亚，巨力机甲
// #
// AAECAf0EAqGxBOy6BA7D+QP8ngT9ngTWoASStQThtQTJtwTKtwTduQTjuQTkuQSywQTY2QSUpAUA
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/fqCuwdBruEUYhO4dIoDYf/


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

            int flag1=0;//港口匪徒 SW_029
            int flag2=0;//血帆桨手 CS3_008
            
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.SW_029//港口匪徒 SW_029
                ){flag1+=1;}
                if(card==Card.Cards.CS3_008//血帆桨手 CS3_008
                ){flag2+=1;}
            }

            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.TSC_632// 械钳虾 TSC_632 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_632))
                    {
                        Keep(card,"械钳虾");
                    } 
                }
                if(card==Card.Cards.TSC_928// 安保自动机 TSC_928
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_928))
                    {
                        Keep(card,"安保自动机");
                    } 
                }
                // if(card==Card.Cards.GIL_548// 怨灵之书 GIL_548 
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.GIL_548))
                //     {
                //         Keep(card,"怨灵之书");
                //     } 
                // }
                if(card==Card.Cards.GVG_006// 机械跃迁者 GVG_006 
                ){  if(!CardsToKeep.Contains(Card.Cards.GVG_006))
                    {
                        Keep(card,"机械跃迁者");
                    }
                        }
                if(card==Card.Cards.BOT_907// 通电机器人 BOT_907
                ){
                   if(!CardsToKeep.Contains(Card.Cards.BOT_907))
                    {
                        Keep(card,"通电机器人");
                    } 
                       }
                if(card==Card.Cards.BOT_445// 机械袋鼠 BOT_445
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BOT_445))
                    {
                        Keep(card,"机械袋鼠");
                    } 
                }
                if(card==Card.Cards.TSC_642// 海沟勘测机 TSC_642
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_642))
                    {
                        Keep(card,"海沟勘测机");
                    } 
                }
                // if(card==Card.Cards.BT_014// 星占师 BT_014
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.BT_014))
                //     {
                //         Keep(card,"星占师");
                //     } 
                // }
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