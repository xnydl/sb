using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

// ### 任务猎
// # 职业：猎人
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (1) 追踪术
// # 2x (1) 数量压制 SCH_604
// # 2x (1) 奥术射击 CORE_DS1_185 
// # 2x (1) 击伤猎物 BAR_801
// # 1x (1) 保卫矮人区 SW_322 
// # 2x (2) 爆炸陷阱
// # 2x (2) 灭龙射击 ONY_010
// # 2x (2) 快速射击
// # 2x (2) 套索射击 YOP_027 
// # 2x (2) 冰霜陷阱 AV_226
// # 2x (2) 冰冻陷阱 
// # 2x (2) 丹巴达尔碉堡 AV_147 
// # 2x (3) 瞄准射击
// # 2x (4) 布置陷阱
// # 2x (4) 多系施法者 DED_524
// # 1x (5) 巴拉克·科多班恩
// #
// AAECAR8C5e8D/fgDDrnQA43kA9vtA/f4A6iBBKmNBKuNBKmfBKqfBOOfBOSfBLugBMGsBJmtBAA=
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/bGZEPaZqObHVQUdwnC2wie/


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
                 if((card==Card.Cards.SCH_604//数量压制 SCH_604
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SCH_604))
                    {
                        Keep(card,"数量压制");
                    }
                    }   
                }
                 if((card==Card.Cards.CORE_DS1_185//奥术射击 CORE_DS1_185 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.CORE_DS1_185))
                    {
                        Keep(card,"奥术射击");
                    }
                    }   
                }
                 if((card==Card.Cards.BAR_801//击伤猎物 BAR_801
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.BAR_801))
                    {
                        Keep(card,"击伤猎物");
                    }
                    }   
                }
                 if((card==Card.Cards.SW_322//保卫矮人区 SW_322 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SW_322))
                    {
                        Keep(card,"保卫矮人区");
                    }
                    }   
                }
                 if((card==Card.Cards.ONY_010//灭龙射击 ONY_010
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.ONY_010))
                    {
                        Keep(card,"灭龙射击");
                    }
                    }   
                }
                 if((card==Card.Cards.YOP_027//套索射击 YOP_027 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.YOP_027))
                    {
                        Keep(card,"套索射击");
                    }
                    }   
                }
                 if((card==Card.Cards.AV_147//丹巴达尔碉堡 AV_147 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.AV_147))
                    {
                        Keep(card,"丹巴达尔碉堡");
                    }
                    }   
                }
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