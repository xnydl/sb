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
                if(card==Card.Cards.BAR_330// 獠牙锥刃 BAR_330
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BAR_330))
                    {
                        Keep(card,"獠牙锥刃");
                    } 
                }
                if(card==Card.Cards.REV_834// 灭绝圣物 REV_834
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_834))
                    {
                        Keep(card,"灭绝圣物");
                    } 
                }
                if(card==Card.Cards.REV_942// 圣物仓库 REV_942
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_942))
                    {
                        Keep(card,"圣物仓库");
                    } 
                }
                if(card==Card.Cards.BAR_325// 剃刀野猪 BAR_325
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BAR_325))
                    {
                        Keep(card,"剃刀野猪");
                    } 
                }
                if(card==Card.Cards.REV_943// 幻灭心能圣物 REV_943
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_943))
                    {
                        Keep(card,"幻灭心能圣物");
                    } 
                }
                if(card==Card.Cards.TSC_938// 宝藏守卫 TSC_938
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_938))
                    {
                        Keep(card,"宝藏守卫");
                    } 
                }
                if(card==Card.Cards.BAR_326// 剃刀沼泽兽王 BAR_326
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BAR_326))
                    {
                        Keep(card,"剃刀沼泽兽王");
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