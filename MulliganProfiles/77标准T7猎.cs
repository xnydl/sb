using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;
// ### t7
// # 职业：猎人
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (1) 奥术畸体 CORE_KAR_036
// # 2x (1) 恶魔伙伴 SCH_600
// # 2x (1) 新生刺头 SCH_231
// # 2x (1) 深铁穴居人 AV_137
// # 2x (1) 萌物来袭 SCH_617 
// # 2x (1) 防护改装师
// # 2x (1) 鹿角小飞兔 SCH_133
// # 2x (2) 快速射击
// # 2x (2) 狗狗饼干 DED_009
// # 2x (3) 山羊坐骑
// # 2x (3) 瞄准射击
// # 2x (4) 战歌驯兽师
// # 1x (4) 瑞林的步枪
// # 2x (4) 穿刺射击
// # 1x (5) 巴拉克·科多班恩
// # 2x (5) 狂踏的犀牛
// # 
// AAECAairBAKP4wPl7wMO3r4D3MwDos4DgtADudIDhuID3OoD8OwD9/gDxfsDw4AEu6AE2qAE4aQEAA==
// # 
// # 想要使用这副套牌，请先复制到剪贴板，然后在游戏中点击“新套牌”进行粘贴。
// ### T7猎
// # 职业：猎人
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (1) 鹿角小飞兔 SCH_133
// # 2x (1) 防护改装师
// # 2x (1) 萌物来袭 SCH_617
// # 2x (1) 深铁穴居人 AV_137
// # 2x (1) 新生刺头 SCH_231
// # 2x (1) 恶魔伙伴 SCH_600
// # 2x (2) 觅血者 AV_244
// # 2x (2) 狗狗饼干 DED_009
// # 2x (2) 快速射击
// # 2x (2) 异教低阶牧师 SCH_713 
// # 2x (3) 瞄准射击
// # 2x (3) 山羊坐骑
// # 2x (4) 穿刺射击
// # 2x (4) 战歌驯兽师
// # 2x (5) 狂踏的犀牛
// #
// AAECAR8AD96+A9zMA6LOA4LQA7nSA4vVA4biA9zqA/DsA/f4A8X7A8OABPaPBLugBOGkBAA=
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/DuVwEhqRLpu2DZ7RFAOq9f/


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
                if(card==Card.Cards.CORE_KAR_036// 奥术畸体 CORE_KAR_036
                ){ if(!CardsToKeep.Contains(Card.Cards.CORE_KAR_036))
                    {
                        Keep(card,"奥术畸体");
                    }
                }
                if(card==Card.Cards.AV_244// 觅血者 AV_244
                ){ if(!CardsToKeep.Contains(Card.Cards.AV_244))
                    {
                        Keep(card,"觅血者");
                    }
                }
                if(card==Card.Cards.SCH_713// 异教低阶牧师 SCH_713 
                ){ if(!CardsToKeep.Contains(Card.Cards.SCH_713))
                    {
                        Keep(card,"异教低阶牧师");
                    }
                }
                if(card==Card.Cards.SCH_600// 恶魔伙伴 SCH_600
                ){ if(!CardsToKeep.Contains(Card.Cards.SCH_600))
                    {
                        Keep(card,"恶魔伙伴");
                    }
                }

              if(card==Card.Cards.SCH_231)//新生刺头 SCH_231
                {
                     if(!CardsToKeep.Contains(Card.Cards.SCH_231))
                    {
                        Keep(card,"新生刺头");
                    }
                }
              if(card==Card.Cards.AV_137)//深铁穴居人 AV_137
                {
                     if(!CardsToKeep.Contains(Card.Cards.AV_137))
                    {
                        Keep(card,"深铁穴居人");
                    }
                }
              if(card==Card.Cards.SCH_617)//萌物来袭 SCH_617
                {
                     if(!CardsToKeep.Contains(Card.Cards.SCH_617))
                    {
                        Keep(card,"萌物来袭");
                    }
                }
              if(card==Card.Cards.SCH_133)//鹿角小飞兔 SCH_133
                {
                     if(!CardsToKeep.Contains(Card.Cards.SCH_133))
                    {
                        Keep(card,"鹿角小飞兔");
                    }
                }
              if(card==Card.Cards.DED_009)//狗狗饼干 DED_009
                {
                     if(!CardsToKeep.Contains(Card.Cards.DED_009))
                    {
                        Keep(card,"狗狗饼干");
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