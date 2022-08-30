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
            int flag1=0;//石雕凿刀 REV_917
            
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.REV_917//石雕凿刀 REV_917
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
                if(card==Card.Cards.TSC_922// 驻锚图腾 TSC_922
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_922))
                    {
                        Keep(card,"驻锚图腾");
                    } 
                }
                if(card==Card.Cards.ULD_276// 怪盗图腾 EVIL Totem ID：ULD_276 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.ULD_276))
                    {
                        Keep(card,"怪盗图腾");
                    } 
                }
                if(card==Card.Cards.OG_028&&flag1>0// 深渊魔物 OG_028
                ){
                    if(!CardsToKeep.Contains(Card.Cards.OG_028))
                    {
                        Keep(card,"深渊魔物");
                    } 
                }
                if(card==Card.Cards.ULD_171// 图腾潮涌 ULD_171
                ){
                    if(!CardsToKeep.Contains(Card.Cards.ULD_171))
                    {
                        Keep(card,"图腾潮涌");
                    } 
                }
                if(card==Card.Cards.GIL_530// 阴燃电鳗 GIL_530 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.GIL_530))
                    {
                        Keep(card,"阴燃电鳗");
                    } 
                }
                if(card==Card.Cards.DMF_704// 笼斗管理员 DMF_704
                ){
                    if(!CardsToKeep.Contains(Card.Cards.DMF_704))
                    {
                        Keep(card,"笼斗管理员");
                    } 
                }
                if(card==Card.Cards.REV_917// 石雕凿刀 REV_917
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_917))
                    {
                        Keep(card,"石雕凿刀");
                    } 
                }
                if(card==Card.Cards.TSC_069// 深海融合怪 TSC_069
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_069))
                    {
                        Keep(card,"深海融合怪");
                    } 
                }
                if(card==Card.Cards.AT_052//图腾魔像 AT_052
                ){
                    if(!CardsToKeep.Contains(Card.Cards.AT_052))
                    {
                        Keep(card,"图腾魔像");
                    } 
                }
                if(card==Card.Cards.REV_921// 锻石师 REV_921 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.REV_921))
                    {
                        Keep(card,"锻石师");
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