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

            int flag1=0;//t1
            int flag2=0;//t2
            int flag3=0;//t3
            
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.SW_029){flag1+=1;}
                if(card==Card.Cards.CS3_008){flag1+=1;}
                if(card==Card.Cards.CORE_LOE_076){flag1+=1;}
                if(card==Card.Cards.BAR_040){flag2+=1;}
                if(card==Card.Cards.BAR_063){flag2+=1;}
                if(card==Card.Cards.BAR_062){flag2+=1;}
                if(card==Card.Cards.BAR_860){flag2+=1;}
                if(card==Card.Cards.TSC_069){flag2+=1;}
            }

            foreach (Card.Cards card in choices)
            {
                // t1
                if(card==Card.Cards.CORE_EX1_509// 鱼人招潮者 CORE_EX1_509
                ){ if(!CardsToKeep.Contains(Card.Cards.CORE_EX1_509))
                    {
                        Keep(card,"鱼人招潮者");
                    }
                }
                if(card==Card.Cards.SW_115//  伯尔纳·锤喙 SW_115
                ){ if(!CardsToKeep.Contains(Card.Cards.SW_115))
                    {
                        Keep(card,"伯尔纳·锤喙");
                    }
                }
                if(card==Card.Cards.BAR_751//  孵化池觅食者 BAR_751 
                ){ if(!CardsToKeep.Contains(Card.Cards.BAR_751))
                    {
                        Keep(card,"孵化池觅食者");
                    }
                }
                if(card==Card.Cards.TID_004//  小丑鱼 TID_004 
                ){ 
                    Keep(card,"小丑鱼");
                }
                 if(card==Card.Cards.CORE_LOE_076//  芬利·莫格顿爵士 Sir Finley Mrrgglton ID：CORE_LOE_076 
                ){ if(!CardsToKeep.Contains(Card.Cards.CORE_LOE_076))
                    {
                        Keep(card,"芬利·莫格顿爵士");
                    }
                }
                // t2
                    if(card==Card.Cards.BAR_063&&flag1>0//  甜水鱼人斥候 BAR_063 
                    ){ if(!CardsToKeep.Contains(Card.Cards.BAR_063))
                        {
                            Keep(card,"甜水鱼人斥候");
                        }
                    }
                    
                    if(card==Card.Cards.BAR_062&&flag1>0//  甜水鱼人佣兵 BAR_062
                    ){ if(!CardsToKeep.Contains(Card.Cards.BAR_062))
                        {
                            Keep(card,"甜水鱼人佣兵");
                        }
                    }
                    
                    if(card==Card.Cards.BAR_860&&flag1>0//  火焰术士弗洛格尔 BAR_860 
                    ){ if(!CardsToKeep.Contains(Card.Cards.BAR_860))
                        {
                            Keep(card,"火焰术士弗洛格尔");
                        }
                    }
                    if(card==Card.Cards.TSC_069&&flag1>0//  深海融合怪 TSC_069 
                    ){ if(!CardsToKeep.Contains(Card.Cards.TSC_069))
                        {
                            Keep(card,"深海融合怪");
                        }
                    }
                    if(card==Card.Cards.BAR_040&&flag1>0//  南海岸酋长 BAR_040 
                    ){ if(!CardsToKeep.Contains(Card.Cards.BAR_040))
                        {
                            Keep(card,"南海岸酋长");
                        }
                    }
                    // T3
                    if(card==Card.Cards.BAR_041&&flag1>0&&flag2>0//   鱼勇可贾 BAR_041
                    ){ if(!CardsToKeep.Contains(Card.Cards.BAR_041))
                        {
                            Keep(card,"鱼勇可贾");
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