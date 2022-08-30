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
                if(card==Card.Cards.BAR_546// 野火 BAR_546
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BAR_546))
                    {
                        Keep(card,"野火");
                    } 
                }
                if(card==Card.Cards.SW_070// 邮箱舞者 SW_070
                ){
                    if(!CardsToKeep.Contains(Card.Cards.SW_070))
                    {
                        Keep(card,"邮箱舞者");
                    } 
                }
                if(card==Card.Cards.BAR_074// 前沿哨所 BAR_074
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BAR_074))
                    {
                        Keep(card,"前沿哨所");
                    } 
                }
                if(card==Card.Cards.AV_284// 巴琳达·斯通赫尔斯 AV_284
                ){
                    if(!CardsToKeep.Contains(Card.Cards.AV_284))
                    {
                        Keep(card,"巴琳达·斯通赫尔斯");
                    } 
                }
                if(card==Card.Cards.REV_378// 涂粉取证师 REV_378
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_378))
                    {
                        Keep(card,"涂粉取证师");
                    } 
                }
                if(card==Card.Cards.REV_000// 可疑的炼金师 REV_000
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_000))
                    {
                        Keep(card,"可疑的炼金师");
                    } 
                }
                if(card==Card.Cards.SW_108// 初始之火 SW_108
                ){
                    if(!CardsToKeep.Contains(Card.Cards.SW_108))
                    {
                        Keep(card,"初始之火");
                    } 
                }
                if(card==Card.Cards.AV_115// 风雪增幅体 AV_115 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.AV_115))
                    {
                        Keep(card,"风雪增幅体");
                    } 
                }
                if(card==Card.Cards.BAR_541// 符文宝珠 BAR_541 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BAR_541))
                    {
                        Keep(card,"符文宝珠");
                    } 
                }
                if(card==Card.Cards.WC_805// 织霜地下城历险家 WC_805
                ){
                    if(!CardsToKeep.Contains(Card.Cards.WC_805))
                    {
                        Keep(card,"织霜地下城历险家");
                    } 
                }
                if(card==Card.Cards.CORE_CS2_023// 奥术智慧 CORE_CS2_023
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CORE_CS2_023))
                    {
                        Keep(card,"奥术智慧");
                    } 
                }
                if(card==Card.Cards.REV_602// 夜隐者圣所 REV_602
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_602))
                    {
                        Keep(card,"夜隐者圣所");
                    } 
                }
                if(card==Card.Cards.TSC_087// 指挥官西瓦拉 TSC_087
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_087))
                    {
                        Keep(card,"指挥官西瓦拉");
                    } 
                }
                if(card==Card.Cards.REV_505// 冰冷案例 REV_505 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_505))
                    {
                        Keep(card,"冰冷案例");
                    } 
                }
                if(card==Card.Cards.AV_114// 战栗的女巫 AV_114
                ){
                    if(!CardsToKeep.Contains(Card.Cards.AV_114))
                    {
                        Keep(card,"战栗的女巫");
                    } 
                }
                 if(card==Card.Cards.REV_906//德纳修斯大帝 REV_906
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_906))
                    {
                        Keep(card,"德纳修斯大帝");
                    } 
                }
                 if(card==Card.Cards.DED_516//深水唤醒师 DED_516 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.DED_516))
                    {
                        Keep(card,"深水唤醒师");
                    } 
                }
                 if(card==Card.Cards.REV_000//可疑的炼金师 Suspicious Alchemist ID：REV_000 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_000))
                    {
                        Keep(card,"可疑的炼金师");
                    } 
                }
                 if(card==Card.Cards.TSC_823//暗水记录员 Murkwater Scribe ID：TSC_823 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_823))
                    {
                        Keep(card,"暗水记录员");
                    } 
                }
                 if(card==Card.Cards.TSC_647//潜水俯冲鹈鹕 TSC_647
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_647))
                    {
                        Keep(card,"潜水俯冲鹈鹕");
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