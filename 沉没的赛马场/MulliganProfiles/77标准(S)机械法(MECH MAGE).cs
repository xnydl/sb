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
                // if(card==Card.Cards.TSC_776// 艾萨拉的清道夫 TSC_776 
                // ){ if(!CardsToKeep.Contains(Card.Cards.TSC_776))
                //     {
                //         Keep(card,"艾萨拉的清道夫");
                //     }
                // }
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
                if(card==Card.Cards.CORE_GVG_085// 吵吵机器人 CORE_GVG_085
                ){ if(!CardsToKeep.Contains(Card.Cards.CORE_GVG_085))
                    {
                        Keep(card,"吵吵机器人");
                    }
                }
                if(card==Card.Cards.TSC_069// 深海融合怪 Amalgam of the Deep ID：TSC_069 
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_069))
                    {
                        Keep(card,"深海融合怪");
                    }
                }
                if(card==Card.Cards.SW_319//农夫 Peasant      SW_319
                ){ if(!CardsToKeep.Contains(Card.Cards.SW_319))
                    {
                        Keep(card,"农夫");
                    }
                }
                if(card==Card.Cards.AV_114//战栗的女巫 Shivering Sorceress ID：AV_114 
                ){ if(!CardsToKeep.Contains(Card.Cards.AV_114))
                    {
                        Keep(card,"战栗的女巫");
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