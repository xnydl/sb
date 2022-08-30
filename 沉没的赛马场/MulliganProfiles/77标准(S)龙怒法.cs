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

            int flag1=0;//艾露恩神谕者 Oracle of Elune      SW_419
            int DRUID=0;
            int HUNTER=0;
            int MAGE=0;
            int PALADIN=0;
            int PRIEST=0;
            int ROGUE=0;
            int SHAMAN=0;
            int WARLOCK=0;
            int WARRIOR=0;
            int DEMONHUNTER=0;
              Bot.Log("对阵职业"+opponentClass);

            if(opponentClass==Card.CClass.PALADIN){
            PALADIN+=1;
            }
            if(opponentClass==Card.CClass.DRUID){
            DRUID+=1;
            }
            if(opponentClass==Card.CClass.HUNTER){
            HUNTER+=1;
            }
            if(opponentClass==Card.CClass.MAGE){
            MAGE+=1;
            }
            if(opponentClass==Card.CClass.PRIEST){
            PRIEST+=1;
            }
            if(opponentClass==Card.CClass.ROGUE){
            ROGUE+=1;
            }
            if(opponentClass==Card.CClass.SHAMAN){
            SHAMAN+=1;
            }
            if(opponentClass==Card.CClass.WARLOCK){
            WARLOCK+=1;
            }
            if(opponentClass==Card.CClass.WARRIOR){
            WARRIOR+=1;
            }
            if(opponentClass==Card.CClass.DEMONHUNTER){
            DEMONHUNTER+=1;
            }
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.SW_419//艾露恩神谕者 Oracle of Elune      SW_419  
                ){flag1+=1;}
            }

            foreach (Card.Cards card in choices)
            {
                 if((card==Card.Cards.TSC_647//潜水俯冲鹈鹕 TSC_647
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.TSC_647))
                    {
                        Keep(card,"潜水俯冲鹈鹕");
                    }
                    }   
                }
                 if((card==Card.Cards.BAR_074//前沿哨所 BAR_074 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.BAR_074))
                    {
                        Keep(card,"前沿哨所");
                    }
                    }   
                }
                 if((card==Card.Cards.SW_070//邮箱舞者 SW_070 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SW_070))
                    {
                        Keep(card,"邮箱舞者");
                    }
                    }   
                }
                 if((card==Card.Cards.AV_115//风雪增幅体 AV_115 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.AV_115))
                    {
                        Keep(card,"风雪增幅体");
                    }
                    }   
                }
                 if((card==Card.Cards.TSC_938//宝藏守卫 TSC_938
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.TSC_938))
                    {
                        Keep(card,"宝藏守卫");
                    }
                    }   
                }
                 if((card==Card.Cards.DED_516//深水唤醒师 DED_516 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.DED_516))
                    {
                        Keep(card,"深水唤醒师");
                    }
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