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
                    if(card==Card.Cards.BAR_873&&(DRUID+DEMONHUNTER+PRIEST+MAGE+WARRIOR+WARLOCK+HUNTER+ROGUE+PALADIN+SHAMAN>0)// 圣礼骑士 BAR_873
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BAR_873))
                    {
                        Keep(card,"圣礼骑士");
                    } 
                }
                    if(card==Card.Cards.CORE_NEW1_020&&(DRUID+DEMONHUNTER+MAGE+WARRIOR+HUNTER+ROGUE>0)// 狂野炎术师 CORE_NEW1_020
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CORE_NEW1_020))
                    {
                        Keep(card,"狂野炎术师");
                    } 
                }
                    if(card==Card.Cards.SW_046&&(DRUID+DEMONHUNTER+MAGE+WARRIOR+HUNTER+ROGUE>0)// 城建税 SW_046
                ){
                    if(!CardsToKeep.Contains(Card.Cards.SW_046))
                    {
                        Keep(card,"城建税");
                    } 
                }
                    if(card==Card.Cards.CORE_EX1_619&&(DRUID+DEMONHUNTER+MAGE+WARRIOR+HUNTER+ROGUE>0)// 生而平等 CORE_EX1_619
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CORE_EX1_619))
                    {
                        Keep(card,"生而平等");
                    } 
                }
                    if(card==Card.Cards.TSC_060&&(DRUID+DEMONHUNTER+PRIEST+WARRIOR+WARLOCK+HUNTER+ROGUE>0)// 闪光翻车鱼 TSC_060 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_060))
                    {
                        Keep(card,"闪光翻车鱼");
                    } 
                }
                    if(card==Card.Cards.ONY_022&&(DRUID+DEMONHUNTER+PRIEST+MAGE+WARRIOR+WARLOCK+HUNTER+ROGUE>0)// 武装教士 ONY_022 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.ONY_022))
                    {
                        Keep(card,"武装教士");
                    } 
                }
                    if(card==Card.Cards.AV_206&&(DRUID+DEMONHUNTER+PRIEST+MAGE+WARRIOR+WARLOCK+HUNTER+ROGUE+PALADIN+SHAMAN>0)// 光铸凯瑞尔 AV_206 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.AV_206))
                    {
                        Keep(card,"光铸凯瑞尔");
                    } 
                }
                    if(card==Card.Cards.TSC_032&&(DRUID+DEMONHUNTER+PRIEST+WARRIOR+HUNTER>0)// 剑圣奥卡尼 TSC_032
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_032))
                    {
                        Keep(card,"剑圣奥卡尼");
                    } 
                }
                    if(card==Card.Cards.BAR_902&&(DRUID+PRIEST+WARRIOR+WARLOCK+HUNTER+ROGUE>0)// 凯瑞尔·罗姆 BAR_902
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BAR_902))
                    {
                        Keep(card,"凯瑞尔·罗姆");
                    } 
                }
                    if(card==Card.Cards.TSC_641&&((DRUID+WARRIOR+WARLOCK>0&&HasCoin)||PRIEST+SHAMAN>0)// 艾萨拉女王 TSC_641
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_641))
                    {
                        Keep(card,"艾萨拉女王");
                    } 
                }
                    if(card==Card.Cards.SW_315// 联盟旗手 SW_315
                ){
                    if(!CardsToKeep.Contains(Card.Cards.SW_315))
                    {
                        Keep(card,"联盟旗手");
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