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
                if(card==Card.Cards.SW_090// 纳斯雷兹姆之触 Touch of the Nathrezim ID：SW_090
                ){ if(!CardsToKeep.Contains(Card.Cards.SW_090))
                    {
                        Keep(card,"纳斯雷兹姆之触");
                    }
                }
                if(card==Card.Cards.CORE_EX1_302// 死亡缠绕 Mortal Coil ID：CORE_EX1_302 
                ){ if(!CardsToKeep.Contains(Card.Cards.CORE_EX1_302))
                    {
                        Keep(card,"死亡缠绕");
                    }
                }
                if(card==Card.Cards.CORE_CFM_120// 亡灵药剂师 Mistress of Mixtures ID：CORE_CFM_120
                ){ if(!CardsToKeep.Contains(Card.Cards.CORE_CFM_120))
                    {
                        Keep(card,"亡灵药剂师");
                    }
                }
                if(card==Card.Cards.CORE_ICC_055// 吸取灵魂 Drain Soul ID：CORE_ICC_055
                ){ if(!CardsToKeep.Contains(Card.Cards.CORE_ICC_055))
                    {
                        Keep(card,"吸取灵魂");
                    }
                }
                if(card==Card.Cards.TSC_956// 拖入深渊 Dragged Below ID：TSC_956
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_956))
                    {
                        Keep(card,"拖入深渊");
                    }
                }
                if(card==Card.Cards.TSC_955// 希拉柯丝教徒 Sira'kess Cultist ID：TSC_955 
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_955))
                    {
                        Keep(card,"希拉柯丝教徒");
                    }
                }
                if(card==Card.Cards.TSC_938// 宝藏守卫 Treasure Guard ID：TSC_938
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_938))
                    {
                        Keep(card,"宝藏守卫");
                    }
                }
                if(card==Card.Cards.TSC_032// 剑圣奥卡尼 Blademaster Okani ID：TSC_032 
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_032))
                    {
                        Keep(card,"剑圣奥卡尼");
                    }
                }
                if(card==Card.Cards.AV_316// 恐惧巫妖塔姆辛 Dreadlich Tamsin ID：AV_316
                ){ if(!CardsToKeep.Contains(Card.Cards.AV_316))
                    {
                        Keep(card,"恐惧巫妖塔姆辛");
                    }
                }
                if(card==Card.Cards.SW_062// 闪金镇豺狼人 Goldshire Gnoll ID：SW_062
                ){ if(!CardsToKeep.Contains(Card.Cards.SW_062))
                    {
                        Keep(card,"闪金镇豺狼人");
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