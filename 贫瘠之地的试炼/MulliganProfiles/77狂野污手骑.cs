using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;
// ### 自定义 圣骑士
// # 职业：圣骑士
// # 模式：狂野模式
// #
// # 1x (1) 圣礼骑士
// # 2x (1) 水晶学 BOT_909
// # 2x (1) 活化扫帚
// # 2x (1) 石牙野猪
// # 2x (1) 风驰电掣 CFM_305
// # 2x (2) 劳累的驮骡
// # 2x (2) 卑劣的脏鼠
// # 1x (2) 定罪（等级1）
// # 2x (2) 污手街供货商 CFM_753
// # 2x (3) 古墓卫士
// # 1x (3) 巴罗夫领主
// # 1x (3) 正义防御
// # 2x (3) 联盟旗手
// # 2x (3) 萨赫特的傲狮 ULD_438
// # 1x (3) 银色骑手
// # 1x (4) 剑圣萨穆罗
// # 1x (5) 亮石技师
// # 1x (5) 洛欧塞布
// # 1x (6) 战场军官
// # 1x (7) 光铸凯瑞尔
// # 
// AAEBAaToAgr6DroT3f4Ck9AD++gDzOsD4+sDx/kDt4AE4IsECogFs7sC97wC38QC2f4ClaYDlc0DiPQD8PYD8/YDAA==
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

            int flag1=0;//青蛙之灵 TRL_060
            int flag2=0;//快攻
            int flag3=0;//快攻
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
                if(card==Card.Cards.TRL_060//青蛙之灵 TRL_060
                ){flag1+=1;}
                if(card==Card.Cards.SCH_427//雷霆绽放 SCH_427
                ){flag3+=1;}
                if(card==Card.Cards.CFM_313//先到先得 CFM_313
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
            flag2+=1;
            }
            if(opponentClass==Card.CClass.DRUID){
            DRUID+=1;
            flag2+=1;
            }
            if(opponentClass==Card.CClass.HUNTER){
            HUNTER+=1;
            flag2+=1;
            }
            if(opponentClass==Card.CClass.MAGE){
            MAGE+=1;
            }
            if(opponentClass==Card.CClass.PRIEST){
            PRIEST+=1;
            }
            if(opponentClass==Card.CClass.ROGUE){
            ROGUE+=1;
            flag2+=1;
            }
            if(opponentClass==Card.CClass.SHAMAN){
            SHAMAN+=1;
            }
            if(opponentClass==Card.CClass.WARLOCK){
            WARLOCK+=1;
            
            }
            if(opponentClass==Card.CClass.WARRIOR){
            WARRIOR+=1;
            flag2+=1;
            }
            if(opponentClass==Card.CClass.DEMONHUNTER){
            DEMONHUNTER+=1;
            flag2+=1;
            }

            foreach (Card.Cards card in choices)
            {
              
                 if((card==Card.Cards.BOT_909//水晶学 BOT_909
                )){
                     if(!CardsToKeep.Contains(Card.Cards.BOT_909))
                    {
                        Keep(card,"水晶学");
                    }
                }
                 if((card==Card.Cards.CFM_305//风驰电掣 CFM_305
                )){
                     if(!CardsToKeep.Contains(Card.Cards.BOT_909))
                    {
                       Keep(card,"风驰电掣");
                    }
                        
                    
                }
                 if((card==Card.Cards.CFM_753//污手街供货商 CFM_753
                )){
                    
                        Keep(card,"污手街供货商");
                    
                }

                if(card==Card.Cards.ULD_438// 萨赫特的傲狮 ULD_438
                ){
               if(!CardsToKeep.Contains(Card.Cards.ULD_438))
                    {
                        Keep(card,"萨赫特的傲狮");
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