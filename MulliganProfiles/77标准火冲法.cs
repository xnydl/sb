using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;
// ### 火冲法
// # 职业：法师
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (1) 野火 BAR_546 
// # 2x (1) 战栗的女巫 AV_114
// # 2x (1) 巡游向导 SCH_312
// # 2x (2) 食魔影豹 SCH_283 
// # 2x (2) 风雪增幅体 AV_115 
// # 2x (2) 星占师 BT_014 
// # 2x (3) 织霜地下城历险家 WC_805
// # 1x (3) 曼科里克 BAR_721
// # 2x (3) 寒冰护体
// # 2x (4) 鲁莽的学徒 BAR_544
// # 1x (4) 瓦尔登·晨拥
// # 2x (4) 深水唤醒师 DED_516 
// # 2x (5) 话痨奥术师
// # 1x (7) 魔导师晨拥
// # 2x (7) 笨拙的信使 SW_109
// # 1x (8) 火眼莫德雷斯
// # 2x (9) 大法师的符文 AV_283
// #
// AAECAf0EBNjsA53uA+fwA6CKBA33uAObzQP7zgPS7APT7APW7AOx9wOTgQSljQSfkgShkgTonwT7ogQA
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/apxZZ7VPUA4TUALWubS3I/


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
            bool HasCoin = choices.Count >= 4;

            int flag1=0;//奥尔多侍从 BT_020 
            int flag2=0;//BAR_875逝者之剑 BAR_875 
            int flag3=0;//古神在上 DMF_236 
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
            
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.BT_020//奥尔多侍从 BT_020 
                ){flag1+=1;}
                if(card==Card.Cards.BAR_873//圣礼骑士 BAR_873
                ){flag1+=1;}
                if(card==Card.Cards.AV_137//深铁穴居人  AV_137 
                ){flag1+=1;}
                if(card==Card.Cards.BAR_875//逝者之剑逝者之剑 BAR_875 
                ){flag2+=1;}
                if(card==Card.Cards.DMF_236//古神在上 DMF_236 
                ){flag3+=1;}
            }
            // foreach (Card.Cards EnemyClass in opponentClass)
            // {
            //     if(EnemyClass == Card.CClass.PALADIN//奥尔多侍从 BT_020 
            //     ){flag1+=1;}
            //     if(card==Card.Cards.BAR_873//圣礼骑士 BAR_873
            //     ){flag1+=1;}
            //     if(card==Card.Cards.BAR_875//逝者之剑逝者之剑 BAR_875 
            //     ){flag2+=1;}
            //     if(card==Card.Cards.DMF_236//古神在上 DMF_236 
            //     ){flag3+=1;}
            // }
            Bot.Log("对阵职业"+opponentClass);

            if(opponentClass==Card.CClass.PALADIN){
            PALADIN+=1;
            }
            if(opponentClass==Card.CClass.DRUID){
            DRUID+=1;
            }
            if(opponentClass==Card.CClass.HUNTER){
            HUNTER+=1;
            }
            if(opponentClass==Card.CClass.MAGE){
            MAGE+=1;
            }
            if(opponentClass==Card.CClass.PRIEST){
            PRIEST+=1;
            }
            if(opponentClass==Card.CClass.ROGUE){
            ROGUE+=1;
            }
            if(opponentClass==Card.CClass.SHAMAN){
            SHAMAN+=1;
            }
            if(opponentClass==Card.CClass.WARLOCK){
            WARLOCK+=1;
            }
            if(opponentClass==Card.CClass.WARRIOR){
            WARRIOR+=1;
            }
            if(opponentClass==Card.CClass.DEMONHUNTER){
            DEMONHUNTER+=1;
            }

            foreach (Card.Cards card in choices)
            {
              
                 if((card==Card.Cards.BAR_546//野火 BAR_546 
                )){
                     if(!CardsToKeep.Contains(Card.Cards.BAR_546))
                    {
                        Keep(card,"野火");
                    }
                }
                 if((card==Card.Cards.AV_114//战栗的女巫 AV_114
                )){
                     if(!CardsToKeep.Contains(Card.Cards.AV_114))
                    {
                        Keep(card,"战栗的女巫");
                    }
                }
                 if((card==Card.Cards.SCH_312//巡游向导 SCH_312
                )){
                     if(!CardsToKeep.Contains(Card.Cards.SCH_312))
                    {
                        Keep(card,"巡游向导");
                    }
                }
                 if((card==Card.Cards.SCH_283//食魔影豹 SCH_283 
                )){
                     if(!CardsToKeep.Contains(Card.Cards.SCH_283))
                    {
                        Keep(card,"食魔影豹");
                    }
                }
                 if((card==Card.Cards.AV_115//风雪增幅体 AV_115 
                )){
                     if(!CardsToKeep.Contains(Card.Cards.AV_115))
                    {
                        Keep(card,"风雪增幅体");
                    }
                }
                 if((card==Card.Cards.BT_014//星占师 BT_014
                )){
                     if(!CardsToKeep.Contains(Card.Cards.BT_014))
                    {
                        Keep(card,"星占师");
                    }
                }
                 if((card==Card.Cards.WC_805//织霜地下城历险家 WC_805
                )){
                     if(!CardsToKeep.Contains(Card.Cards.WC_805))
                    {
                        Keep(card,"织霜地下城历险家");
                    }
                }
                 if((card==Card.Cards.BAR_721//曼科里克 BAR_721
                )){
                     if(!CardsToKeep.Contains(Card.Cards.BAR_721))
                    {
                        Keep(card,"曼科里克");
                    }
                }
               
                 if((card==Card.Cards.DED_516//深水唤醒师 DED_516 
                )){
                     if(!CardsToKeep.Contains(Card.Cards.DED_516))
                    {
                        Keep(card,"深水唤醒师");
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
}//德：DRUID 猎：HUNTER 法：MAGE 骑：PALADIN 牧：PRIEST 贼：ROGUE 萨：SHAMAN 术：WARLOCK 战：WARRIOR 瞎：DEMONHUNTER