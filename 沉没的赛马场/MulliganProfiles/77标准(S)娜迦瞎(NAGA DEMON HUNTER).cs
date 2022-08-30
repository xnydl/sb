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
            int flag2=0;// 剃刀野猪 BAR_325
            int flag3=0;// 恐惧牢笼战刃 AV_209
            int flag4=0;// 獠牙锥刃 BAR_330
            int flag5=0;// 历战先锋 AV_118
            
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.TSC_827//凶恶的滑矛纳迦 TSC_827
                ){flag1+=1;}
                if(card==Card.Cards.BAR_325// 剃刀野猪 BAR_325
                ){flag2+=1;}
                if(card==Card.Cards.AV_209// 恐惧牢笼战刃 AV_209
                ){flag3+=1;}
                if(card==Card.Cards.BAR_330// 獠牙锥刃 BAR_330
                ){flag4+=1;}
                if(card==Card.Cards.AV_118// 历战先锋 AV_118
                ){flag5+=1;}
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
                if(card==Card.Cards.AV_137// 深铁穴居人 AV_137
                ){
                    if(!CardsToKeep.Contains(Card.Cards.AV_137))
                    {
                        Keep(card,"深铁穴居人");
                    } 
                }
                if(card==Card.Cards.TSC_006&&HUNTER+MAGE+ROGUE+PALADIN+PRIEST+WARLOCK+SHAMAN>0// 多重打击 TSC_006
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_006))
                    {
                        Keep(card,"多重打击");
                    } 
                }
                if(card==Card.Cards.TSC_915&&HUNTER>0// 骸骨战刃 TSC_915
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_915))
                    {
                        Keep(card,"骸骨战刃");
                    } 
                }
                if(card==Card.Cards.SW_451// 魔变鱼人 Metamorfin ID：SW_451
                ){
                    if(!CardsToKeep.Contains(Card.Cards.SW_451))
                    {
                        Keep(card,"魔变鱼人");
                    } 
                }
                if(card==Card.Cards.CORE_BT_351// 战斗邪犬 CORE_BT_351
                ){
                    if(!CardsToKeep.Contains(Card.Cards.CORE_BT_351))
                    {
                        Keep(card,"战斗邪犬");
                    } 
                }
                if(card==Card.Cards.SW_041// 敏捷咒符 Sigil of Alacrity ID：SW_041 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.SW_041))
                    {
                        Keep(card,"敏捷咒符");
                    } 
                }
                if(card==Card.Cards.AV_209// 恐惧牢笼战刃 AV_209
                ){
                    if(!CardsToKeep.Contains(Card.Cards.AV_209))
                    {
                        Keep(card,"恐惧牢笼战刃");
                    } 
                }
                if(card==Card.Cards.TSC_006&&HasCoin==true// 多重打击 Multi-Strike ID：TSC_006 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_006))
                    {
                        Keep(card,"多重打击");
                    } 
                }
                if(card==Card.Cards.TSC_827// 凶恶的滑矛纳迦 TSC_827
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_827))
                    {
                        Keep(card,"凶恶的滑矛纳迦");
                    } 
                }
                // if(card==Card.Cards.TSC_058&&flag1>0// 捕掠 Predation ID：TSC_058 
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.TSC_058))
                //     {
                //         Keep(card,"捕掠");
                //     } 
                // }
                if(card==Card.Cards.AV_118// 历战先锋 AV_118
                ){
                    if(!CardsToKeep.Contains(Card.Cards.AV_118))
                    {
                        Keep(card,"历战先锋");
                    } 
                }
                if(card==Card.Cards.AV_100// 德雷克塔尔 AV_100
                ){
                    if(!CardsToKeep.Contains(Card.Cards.AV_100))
                    {
                        Keep(card,"德雷克塔尔");
                    } 
                }
                if(card==Card.Cards.BAR_721// 曼科里克 Mankrik ID：BAR_721
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BAR_721))
                    {
                        Keep(card,"曼科里克");
                    } 
                }
                if(card==Card.Cards.TSC_002&&PALADIN>0// 刺豚拳手 Pufferfist ID：TSC_002 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_002))
                    {
                        Keep(card,"刺豚拳手");
                    } 
                }
                if(card==Card.Cards.AV_204&&(HasCoin==true||WARRIOR+PALADIN+DRUID+MAGE+ROGUE+PALADIN+WARLOCK+SHAMAN>0)// 裂魔者库尔特鲁斯 Kurtrus, Demon-Render ID：AV_204 

                ){
                    if(!CardsToKeep.Contains(Card.Cards.AV_204))
                    {
                        Keep(card,"裂魔者库尔特鲁斯");
                    } 
                }
                if(card==Card.Cards.TSC_217// 游荡贤者 Wayward Sage ID：TSC_217 

                ){
                    if(!CardsToKeep.Contains(Card.Cards.TSC_217))
                    {
                        Keep(card,"游荡贤者");
                    } 
                }
                 if(card==Card.Cards.WC_003// 召唤咒符 WC_003 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.WC_003))
                    {
                        Keep(card,"召唤咒符");
                    } 
                }
                //  if(card==Card.Cards.TSC_938&&flag2>0// 宝藏守卫 TSC_938
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.TSC_938))
                //     {
                //         Keep(card,"宝藏守卫");
                //     } 
                // }
                //  if(card==Card.Cards.SW_072&&PALADIN>0// 锈烂蝰蛇 Rustrot Viper ID：SW_072 
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.SW_072))
                //     {
                //         Keep(card,"锈烂蝰蛇");
                //     } 
                // }
                 if(card==Card.Cards.ONY_016// 憎恨之翼（等级1） ONY_016
                ){
                    if(!CardsToKeep.Contains(Card.Cards.ONY_016))
                    {
                        Keep(card,"憎恨之翼（等级1）");
                    } 
                }
                 if(card==Card.Cards.TID_704// 化石狂热者 Fossil Fanatic ID：TID_704 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.TID_704))
                    {
                        Keep(card,"化石狂热者");
                    } 
                }
                 if(card==Card.Cards.SW_041// 敏捷咒符 Sigil of Alacrity ID：SW_041 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.SW_041))
                    {
                        Keep(card,"敏捷咒符");
                    } 
                }
                 if(card==Card.Cards.AV_267// 凯丽娅·邪魂 Caria Felsoul ID：AV_267 
                ){
                    if(!CardsToKeep.Contains(Card.Cards.AV_267))
                    {
                        Keep(card,"凯丽娅·邪魂");
                    } 
                }
                 if(card==Card.Cards.BT_035// 混乱打击 Chaos Strike ID：BT_035
                ){
                    if(!CardsToKeep.Contains(Card.Cards.BT_035))
                    {
                        Keep(card,"混乱打击");
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