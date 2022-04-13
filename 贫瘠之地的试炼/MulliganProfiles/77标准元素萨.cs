using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

// ### 元素冰萨
// # 职业：萨满祭司
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (1) 火光元素 BAR_854
// # 2x (1) 哀嚎蒸汽 WC_042
// # 2x (1) 冷风
// # 2x (2) 笼斗管理员 DMF_704 
// # 2x (2) 破霰元素 AV_260
// # 2x (2) 冰霜撕咬
// # 2x (3) 旱地风暴 BAR_045
// # 2x (3) 旋岩虫
// # 2x (3) 敲狼锤
// # 2x (4) 运河慢步者
// # 2x (4) 蛮爪洞穴 AV_268
// # 2x (4) 花岗岩熔铸体 SW_032 
// # 2x (4) 冰雪亡魂
// # 2x (5) 荷塘潜伏者
// # 1x (7) 熊男爵格雷希尔
// # 1x (8) 元素使者布鲁坎
// #
// AAECAaoIAsKRBMORBA6q3gOr3gOM4QPg7APh7AOt7gOv7gPA9gPB9gP5kQSVkgTckgTblATTpAQA
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/VW190G2FOcA2rPAXTQtGje/


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
                 if((card==Card.Cards.BAR_854//火光元素 BAR_854
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.BAR_854))
                    {
                        Keep(card,"火光元素");
                    }
                    }   
                }
                 if((card==Card.Cards.WC_042//哀嚎蒸汽 WC_042
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.WC_042))
                    {
                        Keep(card,"哀嚎蒸汽");
                    }
                    }   
                }
                 if((card==Card.Cards.DMF_704//笼斗管理员 DMF_704 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.DMF_704))
                    {
                        Keep(card,"笼斗管理员");
                    }
                    }   
                }
                 if((card==Card.Cards.AV_260//破霰元素 AV_260
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.AV_260))
                    {
                        Keep(card,"破霰元素");
                    }
                    }   
                }
                 if((card==Card.Cards.BAR_045//旱地风暴 BAR_045 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.BAR_045))
                    {
                        Keep(card,"旱地风暴");
                    }
                    }   
                }
                 if((card==Card.Cards.SW_032//花岗岩熔铸体 SW_032
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SW_032))
                    {
                        Keep(card,"花岗岩熔铸体");
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