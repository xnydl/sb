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
            //德：DRUID 猎：HUNTER 法：MAGE 骑：PALADIN 牧：PRIEST 贼：ROGUE 萨：SHAMAN 术：WARLOCK 战：WARRIOR 瞎：DEMONHUNTER
            bool HasCoin = choices.Count >= 4;
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
            int kuaigong=0;
            int mansu=0;
            int flag1=0;//赤红深渊 REV_990
            int flag2=0;//凶恶的滑矛纳迦 TSC_827
            
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.REV_990||card==Card.Cards.REV_332||card==Card.Cards.REV_933//赤红深渊 REV_990
                ){flag1+=1;}
            }
            Bot.Log("对阵职业"+opponentClass);

            if(opponentClass==Card.CClass.PALADIN){
            PALADIN+=1;
            kuaigong+=1;
            }
            if(opponentClass==Card.CClass.DRUID){
            DRUID+=1;
            mansu+=1;
            }
            if(opponentClass==Card.CClass.HUNTER){
            HUNTER+=1;
            kuaigong+=1;
            }
            if(opponentClass==Card.CClass.MAGE){
            MAGE+=1;
            mansu+=1;
            }
            if(opponentClass==Card.CClass.PRIEST){
            PRIEST+=1;
            kuaigong+=1;
            }
            if(opponentClass==Card.CClass.ROGUE){
            ROGUE+=1;
            kuaigong+=1;
            }
            if(opponentClass==Card.CClass.SHAMAN){
            SHAMAN+=1;
            mansu+=1;
            }
            if(opponentClass==Card.CClass.WARLOCK){
            WARLOCK+=1;
            }
            if(opponentClass==Card.CClass.WARRIOR){
            WARRIOR+=1;
            kuaigong+=1;
            }
            if(opponentClass==Card.CClass.DEMONHUNTER){
            DEMONHUNTER+=1;
            kuaigong+=1;
            }
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.TSC_654// 水栖形态 TSC_654
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_654))
                    {
                        Keep(card,"水栖形态");
                    } 
                }
                if(card==Card.Cards.TSC_657// 嗜睡的藻农 TSC_657
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_657))
                    {
                        Keep(card,"嗜睡的藻农");
                    } 
                }
                if(card==Card.Cards.DED_001// 暗礁德鲁伊 DED_001
                ){
                    if(!CardsToKeep.Contains(Card.Cards.DED_001))
                    {
                        Keep(card,"暗礁德鲁伊");
                    } 
                }
                 if(card==Card.Cards.DED_001// 暗礁德鲁伊 DED_001
                ){
                    if(!CardsToKeep.Contains(Card.Cards.DED_001))
                    {
                        Keep(card,"暗礁德鲁伊");
                    } 
                }
                 if(card==Card.Cards.REV_313// 安插证据 REV_313
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_313))
                    {
                        Keep(card,"安插证据");
                    } 
                }
                 if(card==Card.Cards.DED_002// 月光指引 DED_002 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.DED_002))
                    {
                        Keep(card,"月光指引");
                    } 
                }
                 if(card==Card.Cards.DED_003// 应急木工 DED_003 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.DED_003))
                    {
                        Keep(card,"应急木工");
                    } 
                }
                 if(card==Card.Cards.CORE_CS2_013// 野性成长 CORE_CS2_013
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CORE_CS2_013))
                    {
                        Keep(card,"野性成长");
                    } 
                }
                 if(card==Card.Cards.REV_318// 孀花播种者 REV_318
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_318))
                    {
                        Keep(card,"孀花播种者");
                    } 
                }
                 if(card==Card.Cards.AV_205// 野性之心古夫 AV_205
                ){
                    if(!CardsToKeep.Contains(Card.Cards.AV_205))
                    {
                        Keep(card,"野性之心古夫");
                    } 
                }
                 if(card==Card.Cards.REV_906//德纳修斯大帝 REV_906
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_906))
                    {
                        Keep(card,"德纳修斯大帝");
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
}