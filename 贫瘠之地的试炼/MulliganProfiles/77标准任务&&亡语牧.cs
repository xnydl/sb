using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

// ### 奇迹牧
// # 职业：牧师
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (0) 绝望祷言
// # 2x (1) 龙族研习
// # 2x (1) 纳鲁碎片
// # 2x (1) 纳鲁的赐福
// # 1x (1) 神圣惩击
// # 2x (1) 暗言术：噬
// # 2x (1) 复苏
// # 1x (2) 祝福
// # 2x (2) 洞察 DMF_054 
// # 2x (2) 暗中生长 CS3_028
// # 2x (3) 解读手相 DMF_187
// # 2x (3) 纳兹曼尼织血者 DMF_120
// # 2x (3) 流光之赐 SCH_302
// # 2x (5) 心灵分裂
// # 1x (7) 雷象坐骑
// # 2x (8) 真言术：韧
// # 1x (9) 织法者玛里苟斯
// #
// AAECAa0GBKD3A7WKBIWfBImjBA2TugOWugOnywPezAPi3gP73wPK4QOY6wOZ6wOH9wOtigSEowSKowQA
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/sSwKXJEuu4j9fCAredcfJg/

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
                 if((card==Card.Cards.SW_433//寻求指引 SW_433 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SW_433))
                    {
                        Keep(card,"寻求指引");
                    }
                    }   
                }
                 if((card==Card.Cards.AV_100//德雷克塔尔 Drek'Thar ID：AV_100 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.AV_100))
                    {
                        Keep(card,"德雷克塔尔");
                    }
                    }   
                }
                 if((card==Card.Cards.DMF_054//洞察 Insight ID：DMF_054  
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.DMF_054))
                    {
                        Keep(card,"洞察");
                    }
                    }   
                }
                 if((card==Card.Cards.DMF_187//解读手相 Palm Reading ID：DMF_187
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.DMF_187))
                    {
                        Keep(card,"解读手相");
                    }
                    }   
                }
                 if((card==Card.Cards.DMF_120//纳兹曼尼织血者 Nazmani Bloodweaver ID：DMF_120 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.DMF_120))
                    {
                        Keep(card,"纳兹曼尼织血者");
                    }
                    }   
                }
                 if((card==Card.Cards.BT_254//塞泰克织巢者 Sethekk Veilweaver ID：BT_254 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.BT_254))
                    {
                        Keep(card,"塞泰克织巢者");
                    }
                    }   
                }
                 if((card==Card.Cards.AV_223//范达尔·雷矛 Vanndar Stormpike ID：AV_223 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.AV_223))
                    {
                        Keep(card,"范达尔·雷矛");
                    }
                    }   
                }
                 if((card==Card.Cards.SCH_233//龙族研习 SCH_233
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SCH_233))
                    {
                        Keep(card,"龙族研习");
                    }
                    }   
                }
                 if((card==Card.Cards.SW_065//熊猫人进口商 SW_065
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SW_065))
                    {
                        Keep(card,"熊猫人进口商");
                    }
                    }   
                }
                 if((card==Card.Cards.SCH_160//魔杖工匠 SCH_160
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SCH_160))
                    {
                        Keep(card,"魔杖工匠");
                    }
                    }   
                }
                 if((card==Card.Cards.SW_400//被困的女巫 SW_400 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SW_400))
                    {
                        Keep(card,"被困的女巫");
                    }
                    }   
                }
                 if((card==Card.Cards.BAR_735//泽瑞拉 BAR_735
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.BAR_735))
                    {
                        Keep(card,"泽瑞拉");
                    }
                    }   
                }
                 if((card==Card.Cards.CS3_028//暗中生长 CS3_028
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.CS3_028))
                    {
                        Keep(card,"暗中生长");
                    }
                    }   
                }
                 if((card==Card.Cards.SCH_302//流光之赐 SCH_302
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SCH_302))
                    {
                        Keep(card,"流光之赐");
                    }
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