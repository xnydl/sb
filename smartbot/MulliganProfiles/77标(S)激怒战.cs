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
                if(card==Card.Cards.REV_990// 赤红深渊 REV_990
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_990))
                    {
                        Keep(card,"赤红深渊");
                    } 
                }
                if(card==Card.Cards.REV_332// 心能提取者 REV_332
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_332))
                    {
                        Keep(card,"心能提取者");
                    } 
                }
                 if(card==Card.Cards.REV_933// 灌能战斧 REV_933
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_933))
                    {
                        Keep(card,"灌能战斧");
                    } 
                }
                 if(card==Card.Cards.BAR_843// 战歌大使 BAR_843 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BAR_843))
                    {
                        Keep(card,"战歌大使");
                    } 
                }
                 if(card==Card.Cards.CORE_ULD_271// 受伤的托维尔人 CORE_ULD_271
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CORE_ULD_271))
                    {
                        Keep(card,"受伤的托维尔人");
                    } 
                }
                 if(card==Card.Cards.BAR_847// 洛卡拉 BAR_847
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BAR_847))
                    {
                        Keep(card,"洛卡拉");
                    } 
                }
                 if(card==Card.Cards.CORE_EX1_007// 苦痛侍僧 CORE_EX1_007
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CORE_EX1_007))
                    {
                        Keep(card,"苦痛侍僧");
                    } 
                }
                 if(card==Card.Cards.FP1_007// 蛛魔之卵 FP1_007
                ){
                    if(!CardsToKeep.Contains(Card.Cards.FP1_007))
                    {
                        Keep(card,"蛛魔之卵");
                    } 
                }
                 if(card==Card.Cards.REV_930// 疯狂的可怜鬼 REV_930 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_930))
                    {
                        Keep(card,"疯狂的可怜鬼");
                    } 
                }
                 if(card==Card.Cards.REV_338// 泥仆员工 REV_338
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_338))
                    {
                        Keep(card,"泥仆员工");
                    } 
                }
                 if(card==Card.Cards.TSC_942// 黑曜石铸匠 TSC_942 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_942))
                    {
                        Keep(card,"黑曜石铸匠");
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