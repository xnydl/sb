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
            int flag1=0;//凶恶的滑矛纳迦 TSC_827
            
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.TSC_827//凶恶的滑矛纳迦 TSC_827
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
            kuaigong+=1;
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
            mansu+=1;
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
                if(card==Card.Cards.REV_356// 狂蝠来宾 REV_356 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_356))
                    {
                        Keep(card,"狂蝠来宾");
                    } 
                }
                if(card==Card.Cards.TSC_632// 械钳虾 TSC_632 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_632))
                    {
                        Keep(card,"械钳虾");
                    } 
                }
                if(card==Card.Cards.TSC_827// 凶恶的滑矛纳迦 TSC_827
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_827))
                    {
                        Keep(card,"凶恶的滑矛纳迦");
                    } 
                }
                if(card==Card.Cards.REV_360// 灵体偷猎者 REV_360
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_360))
                    {
                        Keep(card,"灵体偷猎者");
                    } 
                }
                if(card==Card.Cards.TID_099// K9-0型机械狗 TID_099
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TID_099))
                    {
                        Keep(card,"K9-0型机械狗");
                    } 
                }
                if(card==Card.Cards.REV_364// 雄鹿冲锋 REV_364
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_364))
                    {
                        Keep(card,"雄鹿冲锋");
                    } 
                }
                if(card==Card.Cards.REV_361// 野性之魂 REV_361
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_361))
                    {
                        Keep(card,"野性之魂");
                    } 
                }
                if(card==Card.Cards.AV_137// 深铁穴居人 AV_137
                ){
                    if(!CardsToKeep.Contains(Card.Cards.AV_137))
                    {
                        Keep(card,"深铁穴居人");
                    } 
                }
                if(card==Card.Cards.SW_319// 农夫 SW_319
                ){
                    if(!CardsToKeep.Contains(Card.Cards.SW_319))
                    {
                        Keep(card,"农夫");
                    } 
                }
                if(card==Card.Cards.REV_350// 狂暴利齿 REV_350 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_350))
                    {
                        Keep(card,"狂暴利齿");
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