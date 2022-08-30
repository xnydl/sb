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
            int flag1=0;//过期货物专卖商 ULD_163 
            int flag2=0;//古尔丹之手 BT_300
            
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.ULD_163//过期货物专卖商 ULD_163 
                ){flag1+=1;}
                if(card==Card.Cards.BT_300//古尔丹之手 BT_300
                ){flag2+=1;}
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
                if(card==Card.Cards.DED_504// 邪恶船运 DED_504
                ){
                    if(!CardsToKeep.Contains(Card.Cards.DED_504))
                    {
                        Keep(card,"邪恶船运");
                    } 
                }
                if(card==Card.Cards.ULD_163&&flag2>0// 过期货物专卖商 ULD_163 
                ){
                        Keep(card,"过期货物专卖商"); 
                }
                if(card==Card.Cards.BT_300&&flag1>0// 古尔丹之手 BT_300
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BT_300))
                    {
                        Keep(card,"古尔丹之手");
                    } 
                }
                if(card==Card.Cards.SCH_145// 课桌小鬼 SCH_145
                ){
                    if(!CardsToKeep.Contains(Card.Cards.SCH_145))
                    {
                        Keep(card,"课桌小鬼");
                    } 
                }
                if(card==Card.Cards.KAR_089// 玛克扎尔的小鬼 KAR_089 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.KAR_089))
                    {
                        Keep(card,"玛克扎尔的小鬼");
                    } 
                }
                if(card==Card.Cards.LOOT_014// 狗头人图书管理员 LOOT_014 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.LOOT_014))
                    {
                        Keep(card,"狗头人图书管理员");
                    } 
                }
                if(card==Card.Cards.AV_137// 深铁穴居人  AV_137 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.AV_137))
                    {
                        Keep(card,"深铁穴居人");
                    } 
                }
                if(card==Card.Cards.CORE_CS2_065// 虚空行者 CORE_CS2_065 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CORE_CS2_065))
                    {
                        Keep(card,"虚空行者");
                    } 
                }
                if(card==Card.Cards.CORE_EX1_319// 烈焰小鬼 CORE_EX1_319
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CORE_EX1_319))
                    {
                        Keep(card,"烈焰小鬼");
                    } 
                }
                if(card==Card.Cards.REV_242// 慌乱的图书管理员 REV_242
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_242))
                    {
                        Keep(card,"慌乱的图书管理员");
                    } 
                }
                if(card==Card.Cards.REV_371// 邪恶图书馆 REV_371
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_371))
                    {
                        Keep(card,"邪恶图书馆");
                    } 
                }
                if(card==Card.Cards.SW_084// 血缚小鬼 SW_084 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.SW_084))
                    {
                        Keep(card,"血缚小鬼");
                    } 
                }
                // if(card==Card.Cards.REV_245// 灾祸降临 REV_245
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.REV_245))
                //     {
                //         Keep(card,"灾祸降临");
                //     } 
                // }
                if(card==Card.Cards.CORE_GIL_191// 恶魔法阵 CORE_GIL_191 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CORE_GIL_191))
                    {
                        Keep(card,"恶魔法阵");
                    } 
                }
                // if(card==Card.Cards.REV_835// 小鬼大王拉法姆 REV_835 
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.REV_835))
                //     {
                //         Keep(card,"小鬼大王拉法姆");
                //     } 
                // }
                // if(card==Card.Cards.CORE_BRM_006// 小鬼首领 CORE_BRM_006
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.CORE_BRM_006))
                //     {
                //         Keep(card,"小鬼首领");
                //     } 
                // }
                // if(card==Card.Cards.REV_244// 调皮的小鬼 REV_244
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.REV_244))
                //     {
                //         Keep(card,"调皮的小鬼");
                //     } 
                // }
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