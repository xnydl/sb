using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

// ### 自定义 德鲁伊
// # 职业：德鲁伊
// # 模式：狂野模式
// #
// # 2x (1) 厄运鼹鼠 LOOT_258
// # 2x (1) 暗礁德鲁伊
// # 2x (1) 活泼的松鼠
// # 2x (1) 玉莲印记
// # 2x (1) 萌物来袭
// # 2x (2) 亚煞极印记
// # 2x (2) 堆肥
// # 2x (2) 尼鲁巴蛛网领主 FP1_017 
// # 2x (2) 月光指引
// # 2x (2) 荆棘护卫
// # 2x (3) 艾露恩神谕者
// # 2x (3) 蜂群来袭 ULD_134
// # 2x (5) 树木生长
// # 2x (7) 荒野骑士 AT_041
// # 2x (7) 霜刃豹头领
// 森然巨化 Embiggen ID：DRG_315 
// # 
// AAEBAZarBAAPiA7kFcGrAs27AovlAq+iA7nSA4zkA63sA8n1A4H3A4T3A6yABK+ABOekBAA=
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

            int flag1=0;//艾露恩神谕者 Oracle of Elune      SW_419
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
                if(card==Card.Cards.SW_419//艾露恩神谕者 Oracle of Elune      SW_419  
                ){flag1+=1;}
            }

            foreach (Card.Cards card in choices)
            {
                //  if((card==Card.Cards.SW_419//艾露恩神谕者 Oracle of Elune      SW_419 
                // )){
                //     {
                //        if(!CardsToKeep.Contains(Card.Cards.SW_419))
                //     {
                //         Keep(card,"艾露恩神谕者");
                //     }
                //     }   
                // }
                 if((card==Card.Cards.SCH_333//自然研习 Nature Studies      SCH_333  
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SCH_333))
                    {
                        Keep(card,"自然研习");
                    }
                    }   
                }
                 if((card==Card.Cards.LOOT_258//厄运鼹鼠 LOOT_258  
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.LOOT_258))
                    {
                        Keep(card,"厄运鼹鼠");
                    }
                    }   
                }
                 if((card==Card.Cards.FP1_017//尼鲁巴蛛网领主 FP1_017   
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.FP1_017))
                    {
                        Keep(card,"尼鲁巴蛛网领主");
                    }
                    }   
                }
                 if((card==Card.Cards.ULD_134//蜂群来袭 ULD_134  
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.ULD_134))
                    {
                        Keep(card,"蜂群来袭");
                    }
                    }   
                }
                 if((card==Card.Cards.AT_041//荒野骑士 AT_041
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.AT_041))
                    {
                        Keep(card,"荒野骑士");
                    }
                    }   
                }
                 if((card==Card.Cards.SCH_617//萌物来袭 Adorable Infestation      SCH_617  
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SCH_617))
                    {
                        Keep(card,"萌物来袭");
                    }
                    }   
                }
                   if(card==Card.Cards.SW_319//农夫 Peasant      SW_319
                )
                {
                     if(!CardsToKeep.Contains(Card.Cards.SW_319))
                    {
                        Keep(card,"农夫");
                    }
                        
                }
                 if((card==Card.Cards.DRG_315//森然巨化 Embiggen ID：DRG_315 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.DRG_315))
                    {
                        Keep(card,"森然巨化");
                    }
                    }   
                }
                 if((card==Card.Cards.BAR_533//荆棘护卫 Thorngrowth Sentries ID：BAR_533 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.BAR_533))
                    {
                        Keep(card,"荆棘护卫");
                    }
                    }   
                }
                if(card==Card.Cards.SW_439//活泼的松鼠 Vibrant Squirrel      SW_439 
                )
                {
                   if(!CardsToKeep.Contains(Card.Cards.SW_439))
                    {
                        Keep(card,"活泼的松鼠");
                    }
                }
                  if(card==Card.Cards.DED_001//活泼的松鼠 Vibrant Squirrel      SW_439 
                )
                {//暗礁德鲁伊 Druid of the Reef ID：DED_001 

                   if(!CardsToKeep.Contains(Card.Cards.DED_001))
                    {
                        Keep(card,"暗礁德鲁");
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