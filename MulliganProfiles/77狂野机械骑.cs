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
// ### 自定义 圣骑士2
// # 职业：圣骑士
// # 模式：狂野模式
// #
// # 2x (1) 机械袋鼠
// # 2x (1) 格洛顿 BOT_906
// # 2x (1) 械钳虾 TSC_632
// # 1x (1) 水晶学 BOT_909 
// # 2x (1) 滑板机器人
// # 2x (2) 安保自动机 TSC_928
// # 1x (2) 护盾机器人
// # 2x (2) 机械跃迁者 GVG_006
// # 2x (2) 海床救生员
// # 2x (2) 深海融合怪
// # 2x (2) 通电机器人 BOT_907
// # 2x (2) 雷达探测 TSC_079
// # 1x (3) 大铡蟹
// # 2x (3) 石炉守备官 AV_343 
// # 2x (3) 空中飞爪
// # 2x (4) 泡泡机器人 TSC_059 
// # 1x (5) 奇利亚斯
// # 
// AAEBAaToAgTqD9n+AqCAA5+3Aw2UD5/1Avb9Atb+Atf+AoeuA/mkBJK1BOG1BNS9BLLBBNrTBNrZBAA=
// # 
// # 想要使用这副套牌，请先复制到剪贴板，然后在游戏中点击“新套牌”进行粘贴。


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
                if(card==Card.Cards.BOT_906// 格洛顿 BOT_906
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BOT_906))
                    {
                        Keep(card,"格洛顿");
                    } 
                }

                if(card==Card.Cards.BOT_909// 水晶学 BOT_909 
                ){   
                    if(!CardsToKeep.Contains(Card.Cards.BOT_909))
                    {
                        Keep(card,"水晶学");
                    } 
                }
                if(card==Card.Cards.TSC_632// 械钳虾 TSC_632
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_632))
                    {
                        Keep(card,"械钳虾");
                    }
                }
                if(card==Card.Cards.TSC_079// 雷达探测 TSC_079
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_079))
                    {
                        Keep(card,"雷达探测");
                    }
                }
                if(card==Card.Cards.TSC_928// 安保自动机 TSC_928
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_928))
                    {
                        Keep(card,"安保自动机");
                    }
                }
                if(card==Card.Cards.BOT_907// 通电机器人 BOT_907
                ){ if(!CardsToKeep.Contains(Card.Cards.BOT_907))
                    {
                        Keep(card,"通电机器人");
                    }
                }
                if(card==Card.Cards.GVG_006// 机械跃迁者 GVG_006
                ){ if(!CardsToKeep.Contains(Card.Cards.GVG_006))
                    {
                        Keep(card,"机械跃迁者");
                    }
                }
                if(card==Card.Cards.AV_343// 石炉守备官 AV_343
                ){ if(!CardsToKeep.Contains(Card.Cards.AV_343))
                    {
                        Keep(card,"石炉守备官");
                    }
                }
                if(card==Card.Cards.GVG_013// 齿轮大师 Cogmaster ID：GVG_013 
                ){ if(!CardsToKeep.Contains(Card.Cards.GVG_013))
                    {
                        Keep(card,"齿轮大师");
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