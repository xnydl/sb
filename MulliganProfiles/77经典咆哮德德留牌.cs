using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

// ### Druid
// # 职业：德鲁伊
// # 模式：经典模式
// #
// # 2x (0) 激活 VAN_EX1_169
// # 2x (2) 愤怒 VAN_EX1_154
// # 1x (2) 血法师萨尔诺斯 VAN_EX1_012
// # 2x (2) 野性之力 VAN_EX1_160 
// # 2x (2) 野性成长 VAN_CS2_013 
// # 2x (3) 野蛮咆哮
// # 2x (3) 麦田傀儡 VAN_EX1_556 
// # 2x (4) 丛林守护者 VAN_EX1_166
// # 2x (4) 横扫
// # 1x (4) 火车王里诺艾
// # 2x (4) 紫罗兰教师 VAN_NEW1_026
// # 2x (5) 利爪德鲁伊
// # 2x (5) 碧蓝幼龙
// # 2x (6) 自然之力 VAN_EX1_571 
// # 1x (7) 战争古树
// # 2x (7) 知识古树
// # 1x (9) 塞纳留斯
// # 
// AAEDAbSKAwS1oQTcoQTzoQSPowQN2ZUE25UE3JUE3ZYE6aEE7KEE8KEE8aEEk6IE1KIEvaMEyqMExaoEAA==
// # 
// # 想要使用这副套牌，请先复制到剪贴板，然后在游戏中点击“新套牌”进行粘贴。
// ### Druid
// # 职业：德鲁伊
// # 模式：经典模式
// #
// # 2x (0) 激活
// # 2x (2) 野性成长
// # 2x (2) 愤怒
// # 2x (3) 野蛮咆哮
// # 2x (3) 大地之环先知
// # 2x (4) 横扫
// # 2x (4) 森金持盾卫士 VAN_CS2_179 
// # 2x (4) 冰风雪人 VAN_CS2_182
// # 2x (4) 丛林守护者
// # 2x (5) 碧蓝幼龙
// # 2x (5) 利爪德鲁伊
// # 2x (6) 自然之力
// # 1x (6) 希尔瓦娜斯·风行者
// # 1x (6) 凯恩·血蹄
// # 2x (7) 知识古树
// # 2x (7) 战争古树
// #
// AAEDAZICArehBNuhBA7ZlQTblQTclQSvlgSwlgTdlgT6oATpoQTwoQTxoQTzoQSTogS9owTFqgQA
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/2gX1PvCxdK5O8sU6RXDtkc/

// ### Druid
// # 职业：德鲁伊
// # 模式：经典模式
// #
// # 2x (0) 激活
// # 2x (1) 银色侍从 VAN_EX1_008 
// # 2x (2) 野性之力 VAN_EX1_160 
// # 1x (2) 血法师萨尔诺斯
// # 2x (2) 战利品贮藏者 VAN_EX1_096
// # 2x (2) 愤怒
// # 2x (3) 麦田傀儡
// # 2x (3) 野蛮咆哮
// # 1x (3) 王牌猎人
// # 2x (4) 紫罗兰教师
// # 2x (4) 横扫
// # 2x (4) 丛林守护者
// # 2x (5) 碧蓝幼龙
// # 2x (5) 利爪德鲁伊
// # 2x (6) 自然之力
// # 2x (7) 知识古树
// #
// AAEDAZICAq+hBLWhBA7ZlQTblQTdlgSyoQTVoQTpoQTsoQTwoQTxoQSTogTUogS9owTKowTFqgQA
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/LANODFHdJXUfkpBgJkxvYc/

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
                 if((card==Card.Cards.VAN_EX1_169//激活 VAN_EX1_169
                )){
                    {
                    
                        Keep(card,"激活");
                    
                    }   
                }
                 if((card==Card.Cards.VAN_EX1_154//愤怒 VAN_EX1_154
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.VAN_EX1_154))
                    {
                        Keep(card,"愤怒");
                    }
                    }   
                }
                 if((card==Card.Cards.VAN_EX1_012//血法师萨尔诺斯 VAN_EX1_012
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.VAN_EX1_012))
                    {
                        Keep(card,"血法师萨尔诺斯");
                    }
                    }   
                }
                //  if((card==Card.Cards.VAN_EX1_160//野性之力 VAN_EX1_160  
                // )){
                //     {
                //        if(!CardsToKeep.Contains(Card.Cards.VAN_EX1_160))
                //     {
                //         Keep(card,"野性之力");
                //     }
                //     }   
                // }
                 if((card==Card.Cards.VAN_CS2_013//野性成长 VAN_CS2_013 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.VAN_CS2_013))
                    {
                        Keep(card,"野性成长");
                    }
                    }   
                }
                   if(card==Card.Cards.VAN_EX1_556// 麦田傀儡 VAN_EX1_556 
                ){ if(!CardsToKeep.Contains(Card.Cards.VAN_EX1_556))
                    {
                        Keep(card,"麦田傀儡");
                    }
                }

                // if(card==Card.Cards.VAN_EX1_166//丛林守护者 VAN_EX1_166
                // )
                // {
                //        if(!CardsToKeep.Contains(Card.Cards.VAN_EX1_166))
                //     {
                //         Keep(card,"丛林守护者");
                //     }
                // }
                if(card==Card.Cards.VAN_NEW1_026// 紫罗兰教师 VAN_NEW1_026
                )
                 {
                       if(!CardsToKeep.Contains(Card.Cards.VAN_NEW1_026))
                    {
                        Keep(card,"紫罗兰教师");
                    }
                }
                if(card==Card.Cards.VAN_CS2_179// 森金持盾卫士 VAN_CS2_179 
                )
                 {
                       if(!CardsToKeep.Contains(Card.Cards.VAN_CS2_179))
                    {
                        Keep(card,"森金持盾卫士");
                    }
                }
                if(card==Card.Cards.VAN_CS2_182// 冰风雪人 VAN_CS2_182
                )
                 {
                       if(!CardsToKeep.Contains(Card.Cards.VAN_CS2_182))
                    {
                        Keep(card,"冰风雪人");
                    }
                }
                if(card==Card.Cards.VAN_EX1_008// 银色侍从 VAN_EX1_008 
                )
                 {
                       if(!CardsToKeep.Contains(Card.Cards.VAN_EX1_008))
                    {
                        Keep(card,"银色侍从");
                    }
                }
                if(card==Card.Cards.VAN_EX1_096// 战利品贮藏者 VAN_EX1_096
                )
                 {
                       if(!CardsToKeep.Contains(Card.Cards.VAN_EX1_096))
                    {
                        Keep(card,"战利品贮藏者");
                    }
                }
                if(card==Card.Cards.VAN_EX1_005&&WARRIOR>0// 王牌猎人 Big Game Hunter ID：VAN_EX1_005 
                )
                 {
                       if(!CardsToKeep.Contains(Card.Cards.VAN_EX1_005))
                    {
                        Keep(card,"王牌猎人");
                    }
                }
                if(card==Card.Cards.VAN_EX1_085&&WARLOCK>0// 精神控制技师 Mind Control Tech ID：VAN_EX1_085
                )
                 {
                       if(!CardsToKeep.Contains(Card.Cards.VAN_EX1_085))
                    {
                        Keep(card,"精神控制技师");
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