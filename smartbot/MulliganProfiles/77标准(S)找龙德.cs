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
                 if((card==Card.Cards.AV_205//野性之心古夫 AV_205
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.AV_205))
                    {
                        Keep(card,"野性之心古夫");
                    }
                    }   
                }
                 if((card==Card.Cards.SW_078//普瑞斯托女士 SW_078
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SW_078))
                    {
                        Keep(card,"普瑞斯托女士");
                    }
                    }   
                }
                 if((card==Card.Cards.AV_137//深铁穴居人 AV_137 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.AV_137))
                    {
                        Keep(card,"深铁穴居人");
                    }
                    }   
                }
                 if((card==Card.Cards.SW_439//活泼的松鼠 SW_439 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SW_439))
                    {
                        Keep(card,"活泼的松鼠");
                    }
                    }   
                }
                 if((card==Card.Cards.SW_319//农夫 SW_319
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SW_319))
                    {
                        Keep(card,"农夫");
                    }
                    }   
                }
                 if((card==Card.Cards.DED_003//应急木工 DED_003 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.DED_003))
                    {
                        Keep(card,"应急木工");
                    }
                    }   
                }
                 if((card==Card.Cards.AV_295//占领冷齿矿洞 AV_295 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.AV_295))
                    {
                        Keep(card,"占领冷齿矿洞");
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