using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

// ### 法强萨
// # 职业：萨满祭司
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (0) 雷霆绽放 SCH_427
// # 2x (1) 闪电箭
// # 2x (1) 电击学徒
// # 2x (1) 强行透支
// # 2x (1) 始生研习 SCH_270
// # 2x (1) 冷风
// # 2x (2) 破霰元素 AV_260 
// # 2x (2) 大地崩陷
// # 2x (2) 冰霜撕咬 AV_259 
// # 2x (3) 艳丽的金刚鹦鹉 DED_509 
// # 2x (3) 毒蛇神殿传送门
// # 1x (3) 原初地下城历险家 WC_005 
// # 2x (4) 蛮爪洞穴 AV_268
// # 2x (4) 多系施法者 DED_524 
// # 2x (6) 雪落守护者 AV_255 
// # 1x (8) 元素使者布鲁坎
// #
// AAECAaoIAuPuA8ORBA7buAPNzgPw1AOJ5APq5wOF+gPTgASogQS5kQT5kQSVkgTckgTblAT5nwQA
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/3zdp1X5kIA1byIKl51JT5f/
// ### 法强萨
// # 职业：萨满祭司
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (0) 雷霆绽放 SCH_427
// # 2x (1) 闪电箭 CORE_EX1_238
// # 2x (1) 电击学徒 CS3_007 
// # 2x (1) 强行透支
// # 2x (1) 始生研习 SCH_270
// # 1x (1) 冷风 AV_266
// # 2x (2) 破霰元素 AV_260
// # 2x (2) 大地崩陷 YOP_023
// # 2x (2) 冰霜撕咬 AV_259
// # 2x (3) 艳丽的金刚鹦鹉 DED_509
// # 2x (3) 毒蛇神殿传送门 BT_100
// # 2x (3) 原初地下城历险家 WC_005 
// # 2x (4) 蛮爪洞穴 AV_268
// # 2x (4) 多系施法者 DED_524
// # 2x (6) 雪落守护者 AV_255
// # 1x (8) 元素使者布鲁坎
// #
// AAECAaoIAsORBNySBA7buAPNzgPw1AOJ5APq5wPj7gOF+gPTgASogQS5kQT5kQSVkgTblAT5nwQA
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/DQBfU3QNYAeDZ6yN8FxSzc/

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
                 if((card==Card.Cards.SCH_427
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SCH_427))
                    {
                        Keep(card,"雷霆绽放");
                    }
                    }   
                }
                 if((card==Card.Cards.AV_260
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.AV_260))
                    {
                        Keep(card,"破霰元素");
                    }
                    }   
                }
                 if((card==Card.Cards.WC_005
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.WC_005))
                    {
                        Keep(card,"原初地下城历险家");
                    }
                    }   
                }
                 if((card==Card.Cards.AV_268//霜狼巢屋 Frostwolf Kennels ID：AV_268 
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.AV_268))
                    {
                        Keep(card,"蛮爪洞穴");
                    }
                    }   
                }
                 if((card==Card.Cards.SCH_270//始生研习 SCH_270
                )){
                    {
                       if(!CardsToKeep.Contains(Card.Cards.SCH_270))
                    {
                        Keep(card,"始生研习");
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