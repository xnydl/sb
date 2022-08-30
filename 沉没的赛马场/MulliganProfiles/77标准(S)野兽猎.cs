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
                if(card==Card.Cards.TSC_827// 凶恶的滑矛纳迦 TSC_827 
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_827))
                    {
                        Keep(card,"凶恶的滑矛纳迦");
                    }
                }
                  if(card==Card.Cards.AV_137// 深铁穴居人  AV_137 
                ){ 
                        Keep(card,"深铁穴居人");
                    
                }
                if(card==Card.Cards.TID_099// K9-0型机械狗 K9-0tron ID：TID_099 
                ){ if(!CardsToKeep.Contains(Card.Cards.TID_099))
                    {
                        Keep(card,"K9-0型机械狗");
                    }
                }
                if(card==Card.Cards.CORE_DS1_184// 追踪术 CORE_DS1_184
                ){ if(!CardsToKeep.Contains(Card.Cards.CORE_DS1_184))
                    {
                        Keep(card,"凶恶的滑矛纳迦");
                    }
                }
                if(card==Card.Cards.CS3_015// 选种饲养员 CS3_015 
                ){ if(!CardsToKeep.Contains(Card.Cards.CS3_015))
                    {
                        Keep(card,"选种饲养员");
                    }
                }
                if(card==Card.Cards.TSC_947// 纳迦的鱼群 TSC_947
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_947))
                    {
                        Keep(card,"纳迦的鱼群");
                    }
                }
                if(card==Card.Cards.TSC_070// 鱼叉炮 TSC_070
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_070))
                    {
                        Keep(card,"鱼叉炮");
                    }
                }
                if(card==Card.Cards.SW_319// 农夫 Peasant ID：SW_319 
                ){ if(!CardsToKeep.Contains(Card.Cards.SW_319))
                    {
                        Keep(card,"农夫");
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