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

            int flag1=0;//t1 头等大奖 Jackpot! ID：TID_931 
            int flag2=0;//t2
            int flag3=0;//t3
            
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.TID_931){flag1+=1;}
            }

            foreach (Card.Cards card in choices)
            {
                // t1
                if(card==Card.Cards.DED_004// 黑水弯刀 Blackwater Cutlass ID：DED_004 
                ){ if(!CardsToKeep.Contains(Card.Cards.DED_004))
                    {
                        Keep(card,"黑水弯刀");
                    }
                }
                if(card==Card.Cards.ONY_032// 奈法利安的牙 Tooth of Nefarian ID：ONY_032 
                ){ if(!CardsToKeep.Contains(Card.Cards.ONY_032))
                    {
                        Keep(card,"奈法利安的牙");
                    }
                }
                if(card==Card.Cards.TID_931// 头等大奖 Jackpot! ID：TID_931 
                ){ if(!CardsToKeep.Contains(Card.Cards.TID_931))
                    {
                        Keep(card,"头等大奖");
                    }
                }
                if(card==Card.Cards.AV_710// 侦察 Reconnaissance ID：AV_710 
                ){ if(!CardsToKeep.Contains(Card.Cards.AV_710))
                    {
                        Keep(card,"侦察");
                    }
                }
                if(card==Card.Cards.TSC_936&&flag1>0// 迅鳞欺诈者 Swiftscale Trickster ID：TSC_936 
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_936))
                    {
                        Keep(card,"迅鳞欺诈者");
                    }
                }
                if(card==Card.Cards.AV_298//蛮爪豺狼人 Wildpaw Gnoll ID：AV_298 
                ){ if(!CardsToKeep.Contains(Card.Cards.AV_298))
                    {
                        Keep(card,"蛮爪豺狼人");
                    }
                }
                if(card==Card.Cards.TSC_641//艾萨拉女王 Queen Azshara ID：TSC_641 
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_641))
                    {
                        Keep(card,"艾萨拉女王");
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