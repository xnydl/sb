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
// ### 德雷克塔尔猎
// # 职业：猎人
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (1) 银色侍从 CORE_EX1_008 
// # 2x (1) 萌物来袭
// # 2x (1) 深铁穴居人 
// # 2x (1) 新生刺头
// # 2x (1) 恶魔伙伴
// # 2x (1) 引月长弓
// # 2x (1) 击伤猎物 BAR_801
// # 2x (2) 狗狗饼干
// # 2x (2) 快速射击
// # 2x (2) 异教低阶牧师
// # 2x (3) 贪婪的书虫
// # 1x (3) 穆克拉
// # 2x (3) 瞄准射击
// # 2x (3) 山羊坐骑
// # 1x (4) 瑞林的步枪
// # 1x (4) 德雷克塔尔 AV_100
// # 1x (6) 野兽追猎者塔维什
// #
// AAECAR8Ej+MDu4oE25EEmKAEDdzMA+HOA4LQA8bRA7nSA4vVA9vtA/f4A8X7A8OABJWgBLugBOGkBAA=
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/MwZSDcQGdaHCy6o5qqDQih/
// ### 野兽猎
// # 职业：猎人
// # 模式：标准模式
// # 狮鹫年
// #
// # 1x (1) 追踪术 CORE_DS1_184 
// # 2x (2) 爆炸陷阱
// # 2x (2) 冰霜陷阱
// # 2x (2) 冰冻陷阱
// # 2x (2) 丹巴达尔碉堡 AV_147
// # 2x (3) 宠物乐园 DMF_086 
// # 1x (4) 范达尔·雷矛 AV_223
// # 1x (4) 瑞林的步枪 DMF_088
// # 1x (4) 布置陷阱
// # 1x (5) 鼠王
// # 2x (5) 进口狼蛛
// # 1x (5) 月牙
// # 2x (5) 教师的爱宠
// # 2x (5) 宠物收集者
// # 1x (6) 野兽追猎者塔维什
// # 2x (7) 山岭野熊
// # 2x (8) 恩佐斯宝石
// # 1x (8) 动物保镖
// # 1x (9) 空军指挥官艾克曼
// # 1x (9) 暴龙王克鲁什
// #
// AAECAR8Kk9EDj+MDleQDyvsDp40EqY0E25EEqZ8E4Z8E2qMECpLNA/rhA4TiA4f9A6uNBOOfBOSfBOWkBMCsBJmtBAA=
// # 想要使用这副套牌，请先复制到剪贴板，再在游戏中创建新套牌。
// # 套牌详情请查看https://hsreplay.net/decks/5uC6j4C1dofalbI3rzZv7e/


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
                if(card==Card.Cards.BAR_801// 击伤猎物 BAR_801
                ){ if(!CardsToKeep.Contains(Card.Cards.BAR_801))
                    {
                        Keep(card,"击伤猎物");
                    }
                }
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
              if(card==Card.Cards.AV_100)//德雷克塔尔 AV_100
                {
                     if(!CardsToKeep.Contains(Card.Cards.AV_100))
                    {
                        Keep(card,"德雷克塔尔");
                    }
                }
              if(card==Card.Cards.AV_137)//深铁穴居人 AV_137
                {
                     if(!CardsToKeep.Contains(Card.Cards.AV_137))
                    {
                        Keep(card,"深铁穴居人");
                    }
                }
              if(card==Card.Cards.CORE_EX1_008)//银色侍从 CORE_EX1_008 
                {
                     if(!CardsToKeep.Contains(Card.Cards.CORE_EX1_008))
                    {
                        Keep(card,"银色侍从");
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
              if(card==Card.Cards.CORE_DS1_184)//追踪术 CORE_DS1_184
                {
                     if(!CardsToKeep.Contains(Card.Cards.CORE_DS1_184))
                    {
                        Keep(card,"追踪术");
                    }
                }
              if(card==Card.Cards.AV_147)//丹巴达尔碉堡 AV_147
                {
                     if(!CardsToKeep.Contains(Card.Cards.AV_147))
                    {
                        Keep(card,"丹巴达尔碉堡");
                    }
                }
              if(card==Card.Cards.DMF_086)//宠物乐园 DMF_086 
                {
                     if(!CardsToKeep.Contains(Card.Cards.DMF_086))
                    {
                        Keep(card,"宠物乐园");
                    }
                }
              if(card==Card.Cards.AV_223)//范达尔·雷矛 AV_223
                {
                     if(!CardsToKeep.Contains(Card.Cards.AV_223))
                    {
                        Keep(card,"范达尔·雷矛");
                    }
                }
        
              if(card==Card.Cards.DMF_088)//瑞林的步枪 DMF_088
                     if(!CardsToKeep.Contains(Card.Cards.DMF_088))
                    {
                        Keep(card,"瑞林的步枪");
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