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
            int flag2=0;//凶恶的滑矛纳迦 TSC_827
            
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.REV_242//慌乱的图书管理员 REV_242
                ){flag1+=1;}
                if(card==Card.Cards.CORE_EX1_319//烈焰小鬼 CORE_EX1_319
                ){flag1+=1;}
                if(card==Card.Cards.CORE_CS2_065//虚空行者 CORE_CS2_065 
                ){flag1+=1;}
                if(card==Card.Cards.DED_504//邪恶船运 DED_504
                ){
                flag1+=1;
                flag2+=1;
                }
                if(card==Card.Cards.SW_084//血缚小鬼 SW_084 
                ){flag1+=1;}
                if(card==Card.Cards.CORE_GIL_191&&HasCoin//恶魔法阵 CORE_GIL_191 
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
                if(card==Card.Cards.TSC_215// 毒蛇假发 TSC_215 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_215))
                    {
                        Keep(card,"毒蛇假发");
                    } 
                }
                if(card==Card.Cards.TSC_212// 侍女 TSC_212
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_212))
                    {
                        Keep(card,"侍女");
                    } 
                }
                if(card==Card.Cards.CORE_UNG_034// 光照元素 CORE_UNG_034
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CORE_UNG_034))
                    {
                        Keep(card,"光照元素");
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