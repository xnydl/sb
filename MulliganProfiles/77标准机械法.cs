using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;
// ### Buff骑
// # 职业：圣骑士
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (1) 正义保护者 CORE_ICC_038 
// # 2x (1) 棱彩珠宝工具 SW_048
// # 2x (1) 械钳虾 TSC_632
// # 2x (2) 雷达探测 TSC_079
// # 2x (2) 深海融合怪 TSC_069
// # 2x (2) 海床救生员 TSC_083
// # 2x (2) 安保自动机 TSC_928
// # 2x (2) 吵吵机器人 BOT_270t 
// # 2x (3) 艾萨拉的观月仪 TSC_644 
// # 2x (3) 联盟旗手 SW_315
// # 2x (3) 石炉守备官 AV_343
// # 2x (3) A3型机械金刚
// # 2x (4) 泡泡机器人
// # 2x (6) 母舰
// # 1x (7) 海兽号
// # 1x (7) 光铸凯瑞尔
// #
// AAECAZ8FAuCLBLCyBA7w9gOq+APJoATWoAT5pASStQThtQTeuQTjuQTUvQSywQTa0wTa2QSUpAUA
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/NcprLgn8dYXNpwLcNfjOOd/
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

                if(card==Card.Cards.SW_059// 矿道工程师 SW_059
                ){   
                    if(!CardsToKeep.Contains(Card.Cards.SW_059))
                    {
                        Keep(card,"矿道工程师");
                    } 
                }
                if(card==Card.Cards.TSC_642// 海沟勘测机 TSC_642
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_642))
                    {
                        Keep(card,"海沟勘测机");
                    }
                }
                if(card==Card.Cards.TSC_776// 艾萨拉的清道夫 TSC_776 
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_776))
                    {
                        Keep(card,"艾萨拉的清道夫");
                    }
                }
                if(card==Card.Cards.TSC_055// 海床传送口 TSC_055
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_055))
                    {
                        Keep(card,"海床传送口");
                    }
                }
                if(card==Card.Cards.TSC_054// 机械鲨鱼 TSC_054
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_054))
                    {
                        Keep(card,"机械鲨鱼");
                    }
                }
                if(card==Card.Cards.TSC_928// 安保自动机 TSC_928
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_928))
                    {
                        Keep(card,"安保自动机");
                    }
                }
                if(card==Card.Cards.BOT_270t// 吵吵机器人 BOT_270t
                ){ if(!CardsToKeep.Contains(Card.Cards.BOT_270t))
                    {
                        Keep(card,"吵吵机器人");
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