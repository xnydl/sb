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
            bool HasCoin = choices.Count >= 4;

            int flag1=0;//艾露恩神谕者 Oracle of Elune      SW_419
            int flag2=0;//钢鬃卫兵 Razormane Battleguard      BAR_537 
            int flag3=0;//噬骨殴斗者 Bonechewer Brawler      BT_715
            int flag4=0;//狂野蟾蜍 Toad of the Wilds      BAR_743 
            int flag5=0;//播种施肥 Sow the Soil      SW_422
            int flag6=0;//活泼的松鼠 Vibrant Squirrel      SW_439 
            int flag7=0;//前沿哨所 Far Watch Post      BAR_074 
            int flag8=0;//吵吵机器人 Annoy-o-Tron      CORE_GVG_085 
            int flag9=0;//雷霆绽放 Lightning Bloom      SCH_427 
            int flag10=0;//农夫 Peasant      SW_319
            int flag11=0;//银色侍从 Argent Squire      CORE_EX1_008 
            int flag12=0;//劳累的驮骡 Encumbered Pack Mule      SW_306 
            int flag13=0;//施肥 Composting      SW_437  
            int flag14=0;//新生刺头 Intrepid Initiate      SCH_231
            int flag15=0;//魔法乌鸦 Enchanted Raven      CORE_KAR_300
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
                
                if(card==Card.Cards.BAR_537//钢鬃卫兵 Razormane Battleguard      BAR_537 
                ){flag2+=1;}
                
                if(card==Card.Cards.BT_715//噬骨殴斗者 Bonechewer Brawler      BT_715
                ){flag3+=1;}
                
                if(card==Card.Cards.BAR_743 //狂野蟾蜍 Toad of the Wilds      BAR_743 
                ){flag4+=1;}
                
                if(card==Card.Cards.SW_422//播种施肥 Sow the Soil      SW_422
                ){flag5+=1;}

                if(card==Card.Cards.SW_439//活泼的松鼠 Vibrant Squirrel      SW_439 
                ){flag6+=1;}

                if(card==Card.Cards.BAR_074//前沿哨所 Far Watch Post      BAR_074 
                ){flag7+=1;}
                 
                if(card==Card.Cards.CORE_GVG_085//吵吵机器人 Annoy-o-Tron      CORE_GVG_085 
                ){flag8+=1;}

                if(card==Card.Cards.SCH_427//雷霆绽放 Lightning Bloom      SCH_427 
                ){flag9+=1;}
                if(card==Card.Cards.SW_319//农夫 Peasant      SW_319
                ){flag10+=1;}
                if(card==Card.Cards.CORE_EX1_008//银色侍从 Argent Squire      CORE_EX1_008
                ){flag11+=1;}
                if(card==Card.Cards.SW_306//劳累的驮骡 Encumbered Pack Mule      SW_306  
                ){flag12+=1;}
                if(card==Card.Cards.SW_437//施肥 Composting      SW_437
                ){flag13+=1;}
                if(card==Card.Cards.SCH_231//新生刺头 Intrepid Initiate      SCH_231
                ){flag14+=1;}
                if(card==Card.Cards.CORE_KAR_300//魔法乌鸦 Enchanted Raven      CORE_KAR_300
                ){flag15+=1;}
            }

            foreach (Card.Cards card in choices)
            {
                 if((card==Card.Cards.SW_419//艾露恩神谕者 Oracle of Elune      SW_419 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SW_419))
                    {
                        Keep(card,"艾露恩神谕者");
                    }
                    }   
                }
                 if((card==Card.Cards.SCH_333//自然研习 Nature Studies      SCH_333  
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SCH_333))
                    {
                        Keep(card,"自然研习");
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
                 if((card==Card.Cards.BAR_533//荆棘护卫 Thorngrowth Sentries ID：BAR_533 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.BAR_533))
                    {
                        Keep(card,"荆棘护卫");
                    }
                    }    
                }
                 if((card==Card.Cards.TSC_653//底层掠食鱼 TSC_653
                )){
                      {
                       if(!CardsToKeep.Contains(Card.Cards.TSC_653))
                    {
                        Keep(card,"底层掠食鱼");
                    }
                    }    
                }
                 if((card==Card.Cards.TSC_654//水栖形态 TSC_654
                )){
                      {
                       if(!CardsToKeep.Contains(Card.Cards.TSC_654))
                    {
                        Keep(card,"水栖形态");
                    }
                    }    
                }
                 if((card==Card.Cards.AV_219//群羊指挥官 Ram Commander ID：AV_219
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.AV_219))
                    {
                        Keep(card,"群羊指挥官");
                    }
                    }   
                }
                 if((card==Card.Cards.AV_360//霜狼巢屋 Frostwolf Kennels ID：AV_360 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.AV_360))
                    {
                        Keep(card,"霜狼巢屋");
                    }
                    }   
                }
                 if((card==Card.Cards.DED_003//应急木工 Jerry Rig Carpenter ID：DED_003 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.DED_003))
                    {
                        Keep(card,"应急木工");
                    }
                    }   
                }
                   if(card==Card.Cards.BAR_075// 十字路口哨所 BAR_075 
                ){ if(!CardsToKeep.Contains(Card.Cards.BAR_075)&&MAGE+ROGUE+PRIEST+WARLOCK+DEMONHUNTER>0)
                    {
                        Keep(card,"十字路口哨所");
                    }
                }

                if(card==Card.Cards.BAR_537//钢鬃卫兵 Razormane Battleguard      BAR_537 
                )
                {
                       if(!CardsToKeep.Contains(Card.Cards.BAR_537))
                    {
                        Keep(card,"钢鬃卫兵");
                    }
                }
                if(card==Card.Cards.YOP_025// 迷梦幼龙  YOP_025 
                )
                 {
                       if(!CardsToKeep.Contains(Card.Cards.YOP_025)&&flag2+flag3+flag4+flag8+flag12>=2)
                    {
                        Keep(card,"迷梦幼龙");
                    }
                }
                  if(card==Card.Cards.AV_137// 深铁穴居人  AV_137 
                ){ 
                        Keep(card,"深铁穴居人");
                    
                }
                  if(card==Card.Cards.SCH_607// 大导师野爪 Shan'do Wildclaw ID：SCH_607 
                ){ 
                        Keep(card,"大导师野爪");
                    
                }
                  if(card==Card.Cards.AV_100// 德雷克塔尔 Drek'Thar ID：AV_100
                ){ 
                        Keep(card,"德雷克塔尔");
                    
                }
               
                if(card==Card.Cards.BT_715)//噬骨殴斗者 Bonechewer Brawler      BT_715
                {
                  if(!CardsToKeep.Contains(Card.Cards.BT_715))
                    {
                        Keep(card,"噬骨殴斗者");
                    }
                }
               
                if(card==Card.Cards.BAR_743&&flag2>0)//狂野蟾蜍 Toad of the Wilds      BAR_743 
                {
                        Keep(card,"2狂野蟾蜍 ");   
                }
                if(card==Card.Cards.CORE_GVG_085&&flag2>0)//吵吵机器人 Annoy-o-Tron      CORE_GVG_085 
                {
                        Keep(card,"吵吵机器人 ");   
                }
              
                if(card==Card.Cards.CORE_KAR_300//魔法乌鸦 Enchanted Raven      CORE_KAR_300
                )
                {
                   if(!CardsToKeep.Contains(Card.Cards.CORE_KAR_300))
                    {
                        Keep(card,"魔法乌鸦");
                    }
                }
                if(card==Card.Cards.SW_439//活泼的松鼠 Vibrant Squirrel      SW_439 
                )
                {
                        Keep(card,"活泼的松鼠");
                }
                  if(card==Card.Cards.DED_001//暗礁德鲁
                )
                {
                        Keep(card,"暗礁德鲁");
                }
                if(card==Card.Cards.CORE_EX1_008//银色侍从 Argent Squire      CORE_EX1_008
                )
                {
                   if(!CardsToKeep.Contains(Card.Cards.CORE_EX1_008))
                    {
                        Keep(card,"银色侍从");
                    }
                }
                if(card==Card.Cards.SW_319//农夫 Peasant      SW_319
                )
                {
                        Keep(card,"农夫");
                }
                if(card==Card.Cards.SCH_231//新生刺头 Intrepid Initiate      SCH_231
                )
                {
                   if(!CardsToKeep.Contains(Card.Cards.SCH_231))
                    {
                        Keep(card,"新生刺头");
                    }
                }
                if(card==Card.Cards.BAR_074//前沿哨所 Far Watch Post      BAR_074
                )
                {
                   if(!CardsToKeep.Contains(Card.Cards.BAR_074))
                    {
                        Keep(card,"前沿哨所");
                    }
                }
                // if(card==Card.Cards.SW_437//施肥 Composting      SW_437
                // )
                // {
                //    if(!CardsToKeep.Contains(Card.Cards.SW_437))
                //     {
                //         Keep(card,"施肥");
                //     }
                // }
                // if(card==Card.Cards.BAR_743//狂野蟾蜍 Toad of the Wilds      BAR_743 
                // )
                // {
                //    if(!CardsToKeep.Contains(Card.Cards.BAR_743))
                //     {
                //         Keep(card,"狂野蟾蜍");
                //     }
                // }
                if(card==Card.Cards.SCH_427&&flag1+flag2>0//雷霆绽放 Lightning Bloom      SCH_427
                )
                {
                    if(!CardsToKeep.Contains(Card.Cards.SCH_427))
                    {
                        Keep(card,"雷霆绽放 ");
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