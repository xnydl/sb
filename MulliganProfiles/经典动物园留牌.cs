using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

// ### Warlock
// # 职业：术士
// # 模式：经典模式
// #
// # 2x (0) 灵魂之火
// # 2x (1) 叫嚣的中士 VAN_CS2_188 
// # 2x (1) 年轻的女祭司 VAN_EX1_004 
// # 2x (1) 持盾卫士 VAN_EX1_405
// # 2x (1) 烈焰小鬼 VAN_EX1_319
// # 2x (1) 精灵弓箭手 VAN_CS2_189
// # 2x (1) 虚空行者 VAN_CS2_065 
// # 2x (1) 银色侍从 VAN_EX1_008
// # 2x (1) 麻风侏儒 VAN_EX1_029 
// # 2x (2) 恐狼前锋 VAN_EX1_162 
// # 1x (2) 酸性沼泽软泥怪 VAN_EX1_066 
// # 2x (2) 阿曼尼狂战士 VAN_EX1_393 
// # 2x (2) 飞刀杂耍者 VAN_NEW1_019
// # 1x (3) 破碎残阳祭司
// # 2x (4) 阿古斯防御者
// # 2x (5) 末日守卫
// # 
// AAEDAcn1AgLVlgTZlgQO+5UEs5YE7ZYEgaEErqEEsqEEvaEE06EE7qEEnaIEo6IEu6IEv6IEw6MEAA==
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
               
                // if(card==Card.Cards.VAN_CS2_188//叫嚣的中士 VAN_CS2_188 
                // )
                // {
                //     if(!CardsToKeep.Contains(Card.Cards.VAN_CS2_188))
                //     {
                //         Keep(card,"叫嚣的中士 ");
                //     }   
                // }
                if(card==Card.Cards.VAN_EX1_004//年轻的女祭司 VAN_EX1_004 
                )
                {
                    if(!CardsToKeep.Contains(Card.Cards.VAN_EX1_004))
                    {
                        Keep(card,"年轻的女祭司 ");
                    }   
                }
                if(card==Card.Cards.VAN_EX1_405//持盾卫士 VAN_EX1_405
                )
                {
                    if(!CardsToKeep.Contains(Card.Cards.VAN_EX1_405))
                    {
                        Keep(card,"持盾卫士 ");
                    }   
                }
                if(card==Card.Cards.VAN_EX1_319//烈焰小鬼 VAN_EX1_319
                )
                {
                   
                        Keep(card,"烈焰小鬼 ");
                      
                }
                // if(card==Card.Cards.VAN_CS2_189//精灵弓箭手 VAN_CS2_189
                // )
                // {
                //     if(!CardsToKeep.Contains(Card.Cards.VAN_CS2_189))
                //     {
                //         Keep(card,"精灵弓箭手 ");
                //     }   
                // }
                if(card==Card.Cards.VAN_CS2_065//虚空行者 VAN_CS2_065 
                )
                {
                   
                        Keep(card,"虚空行者 ");
                   
                }
                if(card==Card.Cards.VAN_EX1_008//银色侍从 VAN_EX1_008
                )
                {
                   
                        Keep(card,"银色侍从 ");
                      
                }
                if(card==Card.Cards.VAN_EX1_029//麻风侏儒 VAN_EX1_029 
                )
                {
                    
                        Keep(card,"麻风侏儒 ");
                       
                }
             
                // if(card==Card.Cards.VAN_EX1_162//恐狼前锋 VAN_EX1_162 
                // )
                // {
                //     if(!CardsToKeep.Contains(Card.Cards.VAN_EX1_162))
                //     {
                //         Keep(card,"恐狼前锋 ");
                //     }   
                // }
                // if(card==Card.Cards.VAN_EX1_066//酸性沼泽软泥怪 VAN_EX1_066 
                // )
                // {
                //     if(!CardsToKeep.Contains(Card.Cards.VAN_EX1_066))
                //     {
                //         Keep(card,"酸性沼泽软泥怪 ");
                //     }   
                // }
                if(card==Card.Cards.VAN_EX1_393//阿曼尼狂战士 VAN_EX1_393 
                )
                {
                   
                        Keep(card,"阿曼尼狂战士 ");
                      
                }
                if(card==Card.Cards.VAN_NEW1_019//飞刀杂耍者 VAN_NEW1_019
                )
                {
                    if(!CardsToKeep.Contains(Card.Cards.VAN_NEW1_019))
                    {
                        Keep(card,"飞刀杂耍者 ");
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