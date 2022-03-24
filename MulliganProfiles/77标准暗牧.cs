using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;
// ### 快攻暗牧
// # 职业：牧师
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (0) 亡者复生 SCH_514
// # 2x (1) 防护改装师
// # 2x (1) 虚触侍从 SW_446 
// # 2x (1) 疲倦的大一新生 SCH_137
// # 2x (1) 深铁穴居人 AV_137
// # 2x (1) 巡游向导 SCH_312
// # 2x (1) 农夫 SW_319
// # 2x (2) 迪菲亚麻风侏儒 DED_513 
// # 2x (2) 蠕动的恐魔 DMF_091
// # 2x (2) 暮光欺诈者
// # 1x (2) 暗中生长 CS3_028 
// # 2x (2) 异教低阶牧师 SCH_713 
// # 2x (2) 库尔提拉斯教士
// # 1x (3) 曼科里克 BAR_721
// # 2x (4) 虚空碎片 SW_442
// # 1x (5) 黑暗主教本尼迪塔斯
// # 1x (6) 重拳先生
// #
// AAECAa0GBOfwA7v3A7+ABK2KBA3evgObzQPXzgO70QOL1QPK4wP09gOI9wOj9wOt9wONgQTvnwThpAQA
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/fRe2XmbfvXVnHQvXrhqCve/

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
                if(card==Card.Cards.SW_419
                ){flag1+=1;}
                
            }

            foreach (Card.Cards card in choices)
            {
                 if((card==Card.Cards.SW_446
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SW_446))
                    {
                        Keep(card,"虚触侍从");
                    }
                    }   
                }
                 if((card==Card.Cards.SCH_137
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SCH_137))
                    {
                        Keep(card,"疲倦的大一新生");
                    }
                    }   
                }
                 if((card==Card.Cards.GVG_009//暗影投弹手 Shadowbomber ID：GVG_009 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.GVG_009))
                    {
                        Keep(card,"暗影投弹手");
                    }
                    }   
                }
                 if((card==Card.Cards.AV_137
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.AV_137))
                    {
                        Keep(card,"深铁穴居人");
                    }
                    }   
                }
                 if((card==Card.Cards.SCH_312
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SCH_312))
                    {
                        Keep(card,"巡游向导");
                    }
                    }   
                }
                 if((card==Card.Cards.SW_319
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SW_319))
                    {
                        Keep(card,"农夫");
                    }
                    }   
                }
                 if((card==Card.Cards.DMF_091
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.DMF_091))
                    {
                        Keep(card,"蠕动的恐魔");
                    }
                    }   
                }
                 if((card==Card.Cards.SCH_713
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SCH_713))
                    {
                        Keep(card,"异教低阶牧师");
                    }
                    }   
                }
                 if((card==Card.Cards.BAR_721
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.BAR_721))
                    {
                        Keep(card,"曼科里克");
                    }
                    }   
                }
				// //有逝者之剑 Sword of the Fallen      BAR_875留北卫军指挥官 Northwatch Commander      BAR_876
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