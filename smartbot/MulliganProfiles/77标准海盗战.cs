using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

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
                if(card==Card.Cards.DED_519// 迪菲亚炮手 DED_519
                ){ if(!CardsToKeep.Contains(Card.Cards.DED_519))
                    {
                        Keep(card,"迪菲亚炮手");
                    }
                }
                if(card==Card.Cards.CORE_NEW1_027// 南海船长 CORE_NEW1_027
                ){ if(!CardsToKeep.Contains(Card.Cards.CORE_NEW1_027))
                    {
                        Keep(card,"南海船长");
                    }
                }
                if(card==Card.Cards.WC_025//砥石战斧 WC_025
                ){ if(!CardsToKeep.Contains(Card.Cards.WC_025))
                    {
                        Keep(card,"砥石战斧");
                    }
                }
                if(card==Card.Cards.CORE_NEW1_018//血帆袭击者 CORE_NEW1_018
                ){ if(!CardsToKeep.Contains(Card.Cards.CORE_NEW1_018))
                    {
                        Keep(card,"血帆袭击者");
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