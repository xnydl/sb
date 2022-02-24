using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;
// ### 宝宝园
// # 职业：术士
// # 模式：标准模式
// # 狮鹫年
// #
// # 2x (0) 亡者复生 
// # 2x (0) 末日仪式 CS3_002
// # 2x (0) 课桌小鬼 SCH_145
// # 2x (0) 鱼人宝宝 LOEA10_3
// # 2x (1) 巡游向导 SCH_312
// # 2x (1) 暗影之刃飞刀手
// # 2x (1) 深铁穴居人 AV_137
// # 2x (1) 烈焰小鬼 EX1_319 
// # 2x (1) 邪恶低语
// # 2x (1) 邪恶船运
// # 2x (2) 蛛魔之卵 FP1_007
// # 2x (2) 蠕动的恐魔
// # 2x (2) 骨网之卵 SCH_147
// # 1x (3) 塔隆·血魔
// # 2x (3) 被亵渎的墓园 AV_657
// # 1x (4) 教导主任加丁 SCH_126 
// # 
// AAECAcn1AgLUugPn0QMOm80D184Dz9ED1dED0OEDyuMDjecDxIAExYAEhKAE0aAE26AE4aQE+LUEAA==
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

            int flag1=0;//狂暴邪翼蝠 YOD_032
            int flag2=0;//暗影投弹手 GVG_009
            int flag3=0;//心灵震爆 DS1_233 
            int flag4=0;//迪菲亚麻风侏儒 DED_513
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
            
            foreach (Card.Cards card in choices)
            {
                if(card==Card.Cards.YOD_032//狂暴邪翼蝠 YOD_032
                ){flag1+=1;}
                if(card==Card.Cards.GVG_009//暗影投弹手 GVG_009
                ){flag2+=1;}
                if(card==Card.Cards.DS1_233//心灵震爆 DS1_233 
                ){flag2+=1;}
                if(card==Card.Cards.DED_513//迪菲亚麻风侏儒 DED_513
                ){flag4+=1;}
                if(card==Card.Cards.SCH_514//亡者复生 SCH_514
                ){flag3+=1;}
                if(card==Card.Cards.DS1_233//心灵震爆 DS1_233
                ){flag3+=1;}
                if(card==Card.Cards.CS3_028//暗中生长 CS3_028
                ){flag3+=1;}
                if(card==Card.Cards.UNG_029//暗影视界 UNG_029
                ){flag3+=1;}
            }
            // foreach (Card.Cards EnemyClass in opponentClass)
            // {
            //     if(EnemyClass == Card.CClass.PALADIN//奥尔多侍从 BT_020 
            //     ){flag1+=1;}
            //     if(card==Card.Cards.BAR_873//圣礼骑士 BAR_873
            //     ){flag1+=1;}
            //     if(card==Card.Cards.BAR_875//逝者之剑逝者之剑 BAR_875 
            //     ){flag2+=1;}
            //     if(card==Card.Cards.DMF_236//古神在上 DMF_236 
            //     ){flag3+=1;}
            // }
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
              
         
                 if((card==Card.Cards.SCH_312//巡游向导 SCH_312
                )){
                       if(!CardsToKeep.Contains(Card.Cards.SCH_312))
                    {
                        Keep(card,"巡游向导");
                    }
                }
                 if((card==Card.Cards.FP1_007//蛛魔之卵 FP1_007
                )){
                       if(!CardsToKeep.Contains(Card.Cards.FP1_007))
                    {
                        Keep(card,"蛛魔之卵");
                    }
                }
                 if((card==Card.Cards.SCH_147//骨网之卵 SCH_147
                )){
                       if(!CardsToKeep.Contains(Card.Cards.SCH_147))
                    {
                        Keep(card,"骨网之卵");
                    }
                }
                 if((card==Card.Cards.AV_137//深铁穴居人 AV_137
                )){
                    
                        Keep(card,"深铁穴居人");
                    
                }
                 if((card==Card.Cards.EX1_319//烈焰小鬼 EX1_319 
                )){
                    
                        Keep(card,"烈焰小鬼");
                    
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