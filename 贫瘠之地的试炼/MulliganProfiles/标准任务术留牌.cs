using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

// ### 任务手牌术
// # 职业：术士
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (0) 亡者复生
// # 2x (1) 纳斯雷兹姆之触 SW_090
// # 1x (1) 死亡缠绕
// # 2x (1) 暗影之刃飞刀手
// # 1x (1) 恶魔之种
// # 2x (1) 巡游向导
// # 2x (2) 吸取灵魂 CORE_ICC_055
// # 2x (3) 邪恶入骨
// # 2x (3) 赛车回火
// # 2x (3) 血岩碎片刺背野猪人
// # 1x (3) 塔姆辛·罗姆
// # 2x (4) 灵魂撕裂
// # 2x (6) 贫瘠之地拾荒者
// # 1x (6) 战场军官
// # 1x (6) 恐惧巫妖塔姆辛
// # 1x (6) 安纳塞隆 SW_092 
// # 2x (10) 闪金镇豺狼人 SW_062
// # 2x (10) 血肉巨人
// #
// AAECAf0GBvLtA8f5A4T7A4f7A7CRBLGfBAybzQPXzgPB0QOT5APY7QPw7QPx7QPG+QOD+wPEgATnoATbowQA
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/7HuHCLVkMVdjWvSW7IbZEd/

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

            int flag1=0;//坎雷萨德·埃伯洛克 Kanrethad Ebonlocke ID：BT_309 
            int flag2=0;//巡游向导 Tour Guide ID：SCH_312 
            int flag3=0;//黑眼 Darkglare ID：BT_307
            int flag4=0;//烈焰小鬼 Flame Imp ID：CORE_EX1_319 
            int flag5=0;//血缚小鬼 Bloodbound Imp ID：SW_084
            int flag6=0;//恶魔之种 The Demon Seed ID：SW_091
            int flag7=0;//亡者复生 Raise Dead ID：SCH_514
            int flag8=0;//精魂狱卒 Spirit Jailer ID：SCH_700 
            int flag9=0;//癫狂的游客 Midway Maniac ID：DMF_114 
            int flag10=0;//癫狂的游客 Midway Maniac ID：DMF_114 
            int flag11=0;//恶魔法阵 Fiendish Circle ID：CORE_GIL_191
            int flag12=0;//古尔丹之手 Hand of Gul'dan ID：BT_300 
            int flag13=0;//夜影主母 Nightshade Matron ID：BT_301 


            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.SW_091//恶魔之种 The Demon Seed ID：SW_091  
                ){flag1+=1;}
                
                if(card==Card.Cards.BT_309//坎雷萨德·埃伯洛克 Kanrethad Ebonlocke ID：BT_309  
                ){flag2+=1;}
                
                if(card==Card.Cards.SCH_312//巡游向导 Tour Guide ID：SCH_312 
                ){flag3+=1;}
                
                if(card==Card.Cards.BT_307 //黑眼 Darkglare ID：BT_307   
                ){flag4+=1;}
                
                if(card==Card.Cards.CORE_EX1_319//烈焰小鬼 Flame Imp ID：CORE_EX1_319
                ){flag5+=1;}

                if(card==Card.Cards.SW_084//血缚小鬼 Bloodbound Imp ID：SW_084 
                ){flag6+=1;}
                if(card==Card.Cards.SCH_514//亡者复生 Raise Dead ID：SCH_514
                ){flag7+=1;}
                if(card==Card.Cards.SCH_700//精魂狱卒 Spirit Jailer ID：SCH_700 
                ){flag8+=1;}
                if(card==Card.Cards.DMF_114
                ){flag9+=1;}
                if(card==Card.Cards.BAR_745//乱齿土狼 He才开了房H也拿IDB乱齿土狼 Hecklefang Hyena ID：BAR_745 
                ){flag10+=1;}
                if(card==Card.Cards.CORE_GIL_191//恶魔法阵 Fiendish Circle ID：CORE_GIL_191
                ){flag11+=1;}
                if(card==Card.Cards.BT_300//古尔丹之手 Hand of Gul'dan ID：BT_300 
                ){flag12+=1;}
                if(card==Card.Cards.BT_301//夜影主母 Nightshade Matron ID：BT_301  
                ){flag13+=1;}
            }

            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.SCH_312//巡游向导 Tour Guide ID：SCH_312 
                )
                {
                    Keep(card,"巡游向导 ");
                }
                if(card==Card.Cards.BT_309//坎雷萨德·埃伯洛克 Kanrethad Ebonlocke ID：BT_309 
                )
                {
                    Keep(card,"坎雷萨德·埃伯洛克 ");
                }
                if(card==Card.Cards.SW_091//恶魔之种 The Demon Seed ID：SW_091  
                )
                {
                     Keep(card,"恶魔之种 ");
                }
                if(card==Card.Cards.BT_300//古尔丹之手 Hand of Gul'dan ID：BT_300 
                )
                {
                    if(!CardsToKeep.Contains(Card.Cards.BT_300)&&flag13>0)
                    {
                        Keep(card,"古尔丹之手 ");
                    }   
                }
                if(card==Card.Cards.BT_301//夜影主母 Nightshade Matron ID：BT_301  
                )
                {
                    if(!CardsToKeep.Contains(Card.Cards.BT_301)&&flag12>0)
                    {
                        Keep(card,"夜影主母 ");
                    }   
                }
                if(card==Card.Cards.BT_307//黑眼 Darkglare ID：BT_307 
                )
                {
                    if(!CardsToKeep.Contains(Card.Cards.BT_307)&&flag1+flag2+flag4+flag7+flag8+flag9+flag10>=2)
                    {
                        Keep(card,"黑眼 ");
                    }   
                }
                if(card==Card.Cards.CORE_EX1_319//烈焰小鬼 Flame Imp ID：CORE_EX1_319
                )
                {
                    Keep(card,"烈焰小鬼 ");
                }
                if(card==Card.Cards.SCH_700//精魂狱卒 Spirit Jailer ID：SCH_700 
                )
                {
                    Keep(card,"精魂狱卒 ");
                }
                if(card==Card.Cards.DED_504//邪恶船运 Wicked Shipment ID：DED_504 
                )
                {
                    if(!CardsToKeep.Contains(Card.Cards.DED_504))
                    {
                        Keep(card,"邪恶船运");
                    }
                }
                if(card==Card.Cards.CORE_GIL_191//恶魔法阵 Fiendish Circle ID：CORE_GIL_191 
                )
                {
                    if(!CardsToKeep.Contains(Card.Cards.CORE_GIL_191))
                    {
                        Keep(card,"恶魔法阵");
                    }
                }
                if(card==Card.Cards.CS3_002//末日仪式 Ritual of Doom ID：CS3_002 
                )
                {
                    if(!CardsToKeep.Contains(Card.Cards.CS3_002)&&flag11>0)
                    {
                        Keep(card,"末日仪式");
                    }
                }
              
                if(card==Card.Cards.SW_084//血缚小鬼 Bloodbound Imp ID：SW_084 
                )
                {
                   if(!CardsToKeep.Contains(Card.Cards.SW_084))
                    {
                        Keep(card,"血缚小鬼");
                    }
                }
                if(card==Card.Cards.BAR_745//血缚小鬼 Bloodbound Imp ID：BAR_745 
                )
                {
                   if(!CardsToKeep.Contains(Card.Cards.BAR_745))
                    {
                        Keep(card,"土狼");
                    }
                }
                if(card==Card.Cards.DMF_114//血缚小鬼 Bloodbound Imp ID：DMF_114 
                )
                {
                   if(!CardsToKeep.Contains(Card.Cards.DMF_114))
                    {
                        Keep(card,"游客");
                    }
                }
                if(card==Card.Cards.YOP_033//血缚小鬼 Bloodbound Imp ID：DMF_114回火 Backfire ID：YOP_033  
                )
                {
                   if(!CardsToKeep.Contains(Card.Cards.YOP_033))
                    {
                        Keep(card,"赛车回火");
                    }
                }
                if(card==Card.Cards.CORE_EX1_302//死亡缠绕 Mortal Coil ID：CORE_EX1_302 
                )
                {
                   if(!CardsToKeep.Contains(Card.Cards.CORE_EX1_302))
                    {
                        Keep(card,"死亡缠绕");
                    }
                }
                if(card==Card.Cards.SW_090//纳斯雷兹姆之触 SW_090 
                )
                {
                   if(!CardsToKeep.Contains(Card.Cards.SW_090))
                    {
                        Keep(card,"纳斯雷兹姆之触");
                    }
                }
                if(card==Card.Cards.CORE_ICC_055//吸取灵魂 CORE_ICC_055
                )
                {
                   if(!CardsToKeep.Contains(Card.Cards.CORE_ICC_055))
                    {
                        Keep(card,"吸取灵魂");
                    }
                }
                if(card==Card.Cards.SW_092//安纳塞隆 SW_092 
                )
                {
                   if(!CardsToKeep.Contains(Card.Cards.SW_092))
                    {
                        Keep(card,"安纳塞隆");
                    }
                }
                if(card==Card.Cards.SW_062//闪金镇豺狼人 SW_062 
                )
                {
                   if(!CardsToKeep.Contains(Card.Cards.SW_062))
                    {
                        Keep(card,"闪金镇豺狼人");
                    }
                }
                // if(card==Card.Cards.WC_005//原初地下城历险家 Primal Dungeoneer ID：WC_005 
                // )
                // {
                //     if(!CardsToKeep.Contains(Card.Cards.WC_005)&&flag1+flag2>=1)
                //     {
                //         Keep(card,"留1原初地下城历险家");
                //     }   
                // }
                // if(card==Card.Cards.CORE_BOT_533//凶恶的雨云 Menacing Nimbus ID：CORE_BOT_533 
                // )
                // {
                //      Keep(card,"留2凶恶的雨云 ");
                // }
                // if(card==Card.Cards.SW_025//拍卖行木槌 Auctionhouse Gavel ID：SW_025 
                // )
                // {
                //      Keep(card,"留2拍卖行木槌 ");
                // }

                // if(card==Card.Cards.BT_292//阿达尔之手 Hand of A'dal ID：BT_292  
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.BT_292)
                //     )
                //     {
                //         Keep(card,"留一张阿达尔之手");
                //     }
                // }                

                // if(card==Card.Cards.YOP_031//螃蟹骑士 Crabrider ID：YOP_031 
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.YOP_031)
                //        && HasCoin==true)
                //     {
                //         Keep(card,"后手留一张螃蟹骑士");
                //     }
                // }

                // if(card==Card.Cards.DMF_194//赤鳞驯龙者 Redscale Dragontamer ID：DMF_194
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.DMF_194)
                //        && HasCoin==true)
                //     {
                //         Keep(card,"后手留一张赤鳞驯龙者 Redscale Dragontamer");
                //     }
                // }


                // if(card==Card.Cards.CORE_FP1_007//蛛魔之卵 Nerubian Egg ID：CORE_FP1_007 
                // ){
                //     {
                //         if(!CardsToKeep.Contains(Card.Cards.CORE_FP1_007)
                //         )
                //         {
                //         Keep(card,"留一张蛛魔之卵 Nerubian Egg");
                //         } 
                //     }  //蛛魔之卵 Nerubian Egg ID：CORE_FP1_007
                // }

                // if(card==Card.Cards.CORE_EX1_319//笼斗管理员 Cagematch Custodian ID：CORE_EX1_319 
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.CORE_EX1_319)
                //        && HasCoin==true)
                //     {
                //         Keep(card,"后手留一张莫戈尔·莫戈尔格 Murgur Murgurgle");
                //     }
                //     else
                //     {
                //         if(!CardsToKeep.Contains(Card.Cards.CORE_EX1_319)
                //         && flag1+flag2+flag3>=1
                //         )
                //         {
                //         Keep(card,"先手有1费留一张莫戈尔·莫戈尔格 Murgur Murgurgle");
                //         } 
                //     }  //笼斗管理员 Cagematch Custodian ID：CORE_EX1_319 
                // }

                // //留第一张逝者之剑 Sword of the Fallen ID：BAR_875
                // if(card==Card.Cards.BAR_875)
                // {
                //     if(!CardsToKeep.Contains(Card.Cards.BAR_875))
                //     {
                //         Keep(card,"留第一张逝者之剑 Sword of the Fallen");
                //     }   
                // }
				
				
				// //有逝者之剑 Sword of the Fallen ID：BAR_875留北卫军指挥官 Northwatch Commander ID：BAR_876
        //         if(card==Card.Cards.BAR_876 && flag7>=1
        //         && HasCoin==true
        //          )
				// {Keep(card,"后手有逝者之剑 Sword of the Fallen留北卫军指挥官 Northwatch Commander");}


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