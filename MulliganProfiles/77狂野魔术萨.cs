using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;
// ### 魔术萨
// # 职业：萨满祭司
// # 模式：狂野模式
// #
// # 2x (0) 瓶装闪电 BOT_246
// # 2x (0) 雷霆绽放 SCH_427
// # 1x (0) 静电震击 GIL_600
// # 2x (1) 先到先得 CFM_313
// # 1x (1) 冷风 AV_266
// # 1x (1) 号令元素 SW_031 
// # 2x (1) 强行透支
// # 1x (1) 电击学徒
// # 2x (1) 闪电箭
// # 2x (2) 先祖知识 AT_053
// # 2x (2) 永恒之火 WC_020
// # 1x (2) 熔岩震击
// # 1x (2) 笔记能手 SCH_236
// # 1x (2) 衰变
// # 1x (3) 亡鬼幻象
// # 1x (3) 导师火心
// # 2x (3) 治疗之雨
// # 1x (3) 熔岩爆裂
// # 2x (3) 青蛙之灵 TRL_060
// # 1x (4) 德雷克塔尔 AV_100
// # 1x (4) 洪流
// # 
// AAEBAZnDAwzgBvER9r0C9vACioUDk7kD4cwDnM4D6ucDwvYDu4oE3JIECdIT57sC8+cCnv0CjIUD8NQD+uwDhfoD+Z8EAA==
// # 
// # 想要使用这副套牌，请先复制到剪贴板，然后在游戏中点击“新套牌”进行粘贴。


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

            int flag1=0;//青蛙之灵 TRL_060
            int flag2=0;//快攻
            int flag3=0;//快攻
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
                if(card==Card.Cards.TRL_060//青蛙之灵 TRL_060
                ){flag1+=1;}
                if(card==Card.Cards.SCH_427//雷霆绽放 SCH_427
                ){flag3+=1;}
                if(card==Card.Cards.CFM_313//先到先得 CFM_313
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
            flag2+=1;
            }
            if(opponentClass==Card.CClass.DRUID){
            DRUID+=1;
            flag2+=1;
            }
            if(opponentClass==Card.CClass.HUNTER){
            HUNTER+=1;
            flag2+=1;
            }
            if(opponentClass==Card.CClass.MAGE){
            MAGE+=1;
            }
            if(opponentClass==Card.CClass.PRIEST){
            PRIEST+=1;
            }
            if(opponentClass==Card.CClass.ROGUE){
            ROGUE+=1;
            flag2+=1;
            }
            if(opponentClass==Card.CClass.SHAMAN){
            SHAMAN+=1;
            }
            if(opponentClass==Card.CClass.WARLOCK){
            WARLOCK+=1;
            
            }
            if(opponentClass==Card.CClass.WARRIOR){
            WARRIOR+=1;
            flag2+=1;
            }
            if(opponentClass==Card.CClass.DEMONHUNTER){
            DEMONHUNTER+=1;
            flag2+=1;
            }

            foreach (Card.Cards card in choices)
            {
              
                 if((card==Card.Cards.TRL_060//青蛙之灵 TRL_060
                )){
                     if(!CardsToKeep.Contains(Card.Cards.TRL_060))
                    {
                        Keep(card,"青蛙之灵");
                    }
                }
                 if((card==Card.Cards.AV_100//德雷克塔尔 AV_100
                )){
                    
                        Keep(card,"德雷克塔尔");
                    
                }
                 if((card==Card.Cards.SW_031//号令元素 SW_031 
                )){
                    
                        Keep(card,"号令元素");
                    
                }

                if(card==Card.Cards.AV_266// 冷风 AV_266 
                ){
               if(!CardsToKeep.Contains(Card.Cards.AV_266))
                    {
                        Keep(card,"冷风");
                    }
                }
                if(card==Card.Cards.AT_053// 先祖知识 AT_053
                ){
               if(!CardsToKeep.Contains(Card.Cards.AT_053))
                    {
                        Keep(card,"先祖知识");
                    }
                }
                if(card==Card.Cards.CFM_313// 先到先得 CFM_313 
                ){
               if(!CardsToKeep.Contains(Card.Cards.CFM_313))
                    {
                        Keep(card,"先到先得");
                    }
                }
                if(card==Card.Cards.SCH_427// 雷霆绽放 SCH_427 
                ){
               if(!CardsToKeep.Contains(Card.Cards.SCH_427)&&HasCoin==true)
                    {
                        Keep(card,"雷霆绽放");
                    }
                }

                if(card==Card.Cards.BOT_246&&flag1+flag2>=1// 瓶装闪电 BOT_246 
                ){
               
                        Keep(card,"瓶装闪电");
                    
                }
                
                if(card==Card.Cards.WC_020&&flag2>=1// 永恒之火 WC_020 
                ){
               if(!CardsToKeep.Contains(Card.Cards.WC_020))
                    {
                        Keep(card,"永恒之火");
                    }
                }
                if(card==Card.Cards.SCH_236&&flag3>=1// 笔记能手 SCH_236 
                ){
               if(!CardsToKeep.Contains(Card.Cards.SCH_236))
                    {
                        Keep(card,"笔记能手");
                    }
                }
                if(card==Card.Cards.SCH_427&&flag1>=1// 雷霆绽放 SCH_427 
                ){
               
                        Keep(card,"雷霆绽放");
                    
                }
                if(card==Card.Cards.GIL_600&&flag1>=1// 静电震击 GIL_600
                ){
               
                        Keep(card,"静电震击");
                    
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