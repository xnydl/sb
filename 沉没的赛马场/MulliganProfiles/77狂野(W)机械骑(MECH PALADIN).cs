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

            int flag1=0;//港口匪徒 SW_029
            int flag2=0;//血帆桨手 CS3_008
            
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.SW_029//港口匪徒 SW_029
                ){flag1+=1;}
                if(card==Card.Cards.CS3_008//血帆桨手 CS3_008
                ){flag2+=1;}
            }

            foreach (Card.Cards card in choices)
            {
                // if(card==Card.Cards.BOT_906// 格洛顿 BOT_906
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.BOT_906))
                //     {
                //         Keep(card,"格洛顿");
                //     } 
                // }
                // if(card==Card.Cards.BOT_906// 格洛顿 BOT_906
                // ){
                //     if(!CardsToKeep.Contains(Card.Cards.BOT_906))
                //     {
                //         Keep(card,"格洛顿");
                //     } 
                // }

                if(card==Card.Cards.BOT_909// 水晶学 BOT_909 
                ){   
                    if(!CardsToKeep.Contains(Card.Cards.BOT_909))
                    {
                        Keep(card,"水晶学");
                    } 
                }
                 if(card==Card.Cards.CFM_753// 污手街供货商 CFM_753
                ){   
                    if(!CardsToKeep.Contains(Card.Cards.CFM_753))
                    {
                        Keep(card,"污手街供货商");
                    } 
                }
                 if(card==Card.Cards.CFM_753// 污手街供货商 CFM_753
                ){   
                    if(!CardsToKeep.Contains(Card.Cards.CFM_753))
                    {
                        Keep(card,"污手街供货商");
                    } 
                }
                // if(card==Card.Cards.TSC_083// 海床救生员 TSC_083
                // ){   
                //     if(!CardsToKeep.Contains(Card.Cards.TSC_083))
                //     {
                //         Keep(card,"海床救生员");
                //     } 
                // }
                if(card==Card.Cards.TSC_632// 械钳虾 TSC_632
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_632))
                    {
                        Keep(card,"械钳虾");
                    }
                }
                if(card==Card.Cards.TSC_079// 雷达探测 TSC_079
                ){ if(!CardsToKeep.Contains(Card.Cards.TSC_079))
                    {
                        Keep(card,"雷达探测");
                    }
                }
                // if(card==Card.Cards.TSC_928// 安保自动机 TSC_928
                // ){ if(!CardsToKeep.Contains(Card.Cards.TSC_928))
                //     {
                //         Keep(card,"安保自动机");
                //     }
                // }
                if(card==Card.Cards.BOT_907// 通电机器人 BOT_907
                ){ if(!CardsToKeep.Contains(Card.Cards.BOT_907))
                    {
                        Keep(card,"通电机器人");
                    }
                }
                if(card==Card.Cards.SW_048// 棱彩珠宝工具 SW_048
                ){ if(!CardsToKeep.Contains(Card.Cards.SW_048))
                    {
                        Keep(card,"棱彩珠宝工具");
                    }
                }
                if(card==Card.Cards.GVG_006// 机械跃迁者 GVG_006
                ){ 
                        Keep(card,"机械跃迁者");
                }
                if(card==Card.Cards.AV_343// 石炉守备官 AV_343
                ){ if(!CardsToKeep.Contains(Card.Cards.AV_343))
                    {
                        Keep(card,"石炉守备官");
                    }
                }
                if(card==Card.Cards.GVG_013// 齿轮大师 Cogmaster ID：GVG_013 
                ){ if(!CardsToKeep.Contains(Card.Cards.GVG_013))
                    {
                        Keep(card,"齿轮大师");
                    }
                }
                // if(card==Card.Cards.BOT_445// 机械袋鼠 BOT_445 
                // ){ if(!CardsToKeep.Contains(Card.Cards.BOT_445))
                //     {
                //         Keep(card,"机械袋鼠");
                //     }
                // }
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