using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;
// ### 任务战
// # 职业：战士
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (1) 血帆桨手 CS3_008
// # 2x (1) 砥石战斧
// # 2x (1) 海上威胁
// # 1x (1) 开进码头 SW_028
// # 2x (2) 黑曜石铸匠 TSC_942 
// # 2x (2) 雾帆劫掠者
// # 2x (2) 血帆袭击者
// # 2x (2) 港口匪徒 SW_029
// # 2x (2) 深海融合怪 TSC_069
// # 1x (2) 拖网海象人 TSC_909
// # 2x (3) 迪菲亚炮手
// # 2x (3) 货物保镖
// # 2x (3) 暴风城海盗
// # 2x (3) 南海船长
// # 2x (3) 刺豚拳手
// # 1x (6) 重拳先生
// # 1x (7) 奈利，超巨蛇颈龙
// #
// AAECAQcEmPYDv4AEqbMEjskEDf7nA47vA5X2A5b2A5f2A8/7A5yBBKaKBK2gBK+gBIqwBJC3BLLBBAA=
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/ensF5iRMHiIGkRQmuRYI0c/

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
                 if((card==Card.Cards.SW_028//开进码头 SW_028
                )){
                    
                        Keep(card,"开进码头");
                    
                }

                if(card==Card.Cards.SW_029// 港口匪徒 SW_029
                ){
                       if(!CardsToKeep.Contains(Card.Cards.SW_029))
                    {
                        Keep(card,"港口匪徒");
                    } 
                }

                if(card==Card.Cards.CS3_008// 血帆桨手 CS3_008
                ){   
                    if(!CardsToKeep.Contains(Card.Cards.CS3_008))
                    {
                        Keep(card,"血帆桨手");
                    } 
                }
                if(card==Card.Cards.TSC_069// 深海融合怪 TSC_069
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_069))
                    {
                        Keep(card,"深海融合怪");
                    }
                }
                if(card==Card.Cards.TSC_909// 拖网海象人 TSC_909 
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_909))
                    {
                        Keep(card,"拖网海象人");
                    }
                }
                if(card==Card.Cards.TSC_942// 黑曜石铸匠 TSC_942
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_942))
                    {
                        Keep(card,"黑曜石铸匠");
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