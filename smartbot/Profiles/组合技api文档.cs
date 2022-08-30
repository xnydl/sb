using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;
using SmartBotAPI.Plugins.API;
using System.IO;

namespace SmartBotProfiles
{
    [Serializable]
    public class PlayOrderPriority : Profile
    {
		public ProfileParameters GetParameters(Board board)
        {
            var p = new ProfileParameters(BaseProfile.Rush) {DiscoverSimulationValueThresholdPercent = -10};
            var flameImpId = board.Hand.FirstOrDefault(x => x.Template.Id == Card.Cards.CORE_EX1_319);//烈焰小鬼 Flame Imp
            var voidWalkerId = board.Hand.FirstOrDefault(x => x.Template.Id == Card.Cards.CORE_CS2_065);//虚空行者 Voidwalker ID：CORE_CS2_065 
            var theCoin = board.Hand.FirstOrDefault(x => x.Template.Id == Card.Cards.GAME_005);//幸运币 The Coin ID：GAME_005 
            var vileLib = board.Hand.FirstOrDefault(x => x.Template.Id == Card.Cards.REV_371);//邪恶图书馆 Vile Library ID：REV_371 
            // 得确保对应值不为null,不然会报错
            if(flameImpId!=null
            &&voidWalkerId!=null
            &&theCoin!=null
            &&vileLib!=null
            ){
                p.ComboModifier = new ComboSet(vileLib.Id, theCoin.Id, flameImpId.Id, voidWalkerId.Id);
            }
            // 这里定义好了之后写xxx.id就好了,理解成取对象里面的id属性去做判断

            return p;
        }
        
        public Card.Cards SirFinleyChoice(List<Card.Cards> choices)
        {
            return choices[0];
        }

        public Card.Cards KazakusChoice(List<Card.Cards> choices)
        {
            return choices[0];
        }
    }
}

/*Test seed

3~3~1~0~0~22~24~0~False~3~False~4~0~0~HERO_07a*-1*0*0*0*7*0*64*30*0*6*23*0*False*False*False*False*False*False*False*False*False*False*False*False*False*6*False*True*False*1*False*False*False*False*False*False*False*50=1&202=3&45=30&44=7&12=1&18=42&49=1&53=64&203=4&271=6&380=47788&1556=1&1715=42&2187=0&318=0&1173=0&36=0~HERO_10*-1*0*0*0*0*0*66*30*0*6*30*0*False*False*False*False*True*False*False*False*False*False*False*False*False*6*False*True*False*0*False*False*False*False*False*False*False*50=2&202=3&45=30&43=0&49=1&53=66&203=2&267=64&271=6&297=0&380=60224&1556=1&1715=66~CS2_056_H1*-1*0*0*2*0*0*65*0*0*6*0*0*False*False*False*False*False*False*False*False*False*False*False*False*False*6*False*True*False*1*False*False*False*False*False*False*False*50=1&202=10&466=2&48=2&12=1&49=1&53=65&201=3&271=6&313=64&1037=1&1086=51468&1284=47817&1556=1&43=0~HERO_10bp*-1*0*0*1*0*0*67*0*0*6*0*0*False*False*False*False*True*False*False*False*False*False*False*False*False*6*False*True*False*0*False*False*False*False*False*False*False*50=2&202=10&466=1&48=1&43=0&49=1&53=67&271=6&313=66&1037=2&1086=60483&1284=56550&1556=1~0~EX1_019*0*0*3*3*0*0*51*2*0*1*2*0*False*False*False*False*True*False*False*False*False*False*False*False*False*1*False*True*False*0*False*False*False*False*False*False*False*49=1&50=2&53=51&263=1&202=4&466=3&479=3&48=3&47=3&45=2&201=3&203=2&218=1&261=0&267=42&273=2&478=2&1043=1&1068=0&1556=1&1196=0&43=1&271=1|EX1_506*1*0*3*2*0*0*42*2*0*3*2*0*False*False*False*False*True*False*False*False*False*False*False*False*False*3*False*True*False*0*False*False*False*False*False*False*False*49=1&50=2&53=42&263=2&202=4&466=2&479=3&48=2&47=3&45=2&200=14&201=3&203=2&218=1&261=0&273=1&478=2&1043=1&1068=0&1429=57338&1440=1&1556=1&1592=1&1196=0&43=1&271=3&267=64&1715=42&38=0&297=0*EX1_019e=2=51=0|EX1_506a*2*0*1*1*0*0*79*1*0*3*1*0*False*False*False*False*True*False*False*False*False*False*False*False*False*3*False*True*False*0*False*False*False*False*False*False*False*50=2&202=4&1196=0&466=1&479=1&48=1&47=1&45=1&43=1&49=1&53=79&200=14&201=3&203=1&263=3&313=42&1037=2&1254=42&1284=976&1429=57339&1440=1&1556=1&271=3&267=64&1715=79&38=0&297=0~REV_244*0*0*3*4*0*0*32*3*0*0*3*0*False*False*False*False*False*False*True*False*False*False*False*False*False*3*False*True*False*0*False*False*False*False*False*False*False*50=1&202=4&466=4&479=3&48=4&47=3&45=3&2=3&49=3&53=32&200=15&203=3&218=1&263=1&478=1&1037=1&1043=1&1452=78361&1556=1&1719=2&1965=1&2456=1&273=2|CORE_EX1_319*1*0*3*1*0*0*30*2*0*0*2*0*False*False*False*False*False*False*True*False*False*False*False*False*False*0*False*True*False*0*False*False*False*False*False*False*False*50=1&202=4&466=1&479=3&48=1&47=3&45=2&12=1&49=3&53=30&200=15&201=3&203=1&218=1&263=2&478=1&858=1090&1037=1&1043=1&1413=1090&1556=1&1965=1&273=2|TSC_962*2*0*7*8*0*0*14*4*0*0*4*0*False*False*False*False*False*False*True*False*False*False*False*False*False*0*False*True*False*0*False*False*False*False*False*False*False*50=1&202=4&466=8&479=7&48=8&47=7&45=4&49=3&53=14&114=1&200=14&203=5&217=1&218=1&263=3&478=1&1037=1&1043=1&1078=74742&1452=74742&1544=1&1556=1&2247=1&273=2|SW_086*3*0*4*5*0*0*31*4*0*0*4*0*False*False*False*False*False*False*True*False*False*False*False*False*False*0*False*True*False*0*False*False*False*False*False*False*False*50=1&202=4&466=5&479=4&48=5&47=4&45=4&49=3&53=31&203=1&218=1&263=4&478=1&1037=1&1043=1&1556=1&1720=1&1743=1&273=2|BAR_COIN1*4*0*0*0*0*0*68*0*0*0*0*0*False*False*False*False*False*False*True*False*False*False*False*False*False*0*False*True*False*0*False*False*False*False*False*False*False*50=1&202=5&49=3&53=68&263=5&313=1&1556=1&2088=1&273=2|REV_835*5*0*6*6*0*0*11*6*0*0*6*0*False*False*False*False*False*False*True*False*False*False*False*False*False*5*False*True*False*0*False*False*False*False*False*False*False*50=1&202=4&466=6&479=6&48=6&47=6&45=6&2=5&49=3&53=11&114=1&203=5&218=1&263=6&478=1&1037=1&1043=1&1452=78367&1556=1&1570=2&1719=2&2456=1&273=2|CORE_CS2_065*6*0*1*1*0*0*27*3*0*0*3*0*False*False*True*False*False*False*True*False*False*False*False*False*False*0*False*True*False*0*False*False*False*False*False*False*False*49=3&50=1&53=27&202=4&466=1&479=1&48=1&47=1&45=3&12=1&190=1&200=15&201=3&203=1&478=1&858=48&1037=1&1043=1&1068=0&1413=48&1440=1&1556=1&263=7&1570=4&273=1|CORE_EX1_319*7*0*3*1*0*0*17*2*0*0*2*0*False*False*False*False*False*False*True*False*False*False*False*False*False*0*False*True*False*0*False*False*False*False*False*False*False*49=3&50=1&53=17&202=4&466=1&479=3&48=1&47=3&45=2&12=1&200=15&201=3&203=1&218=1&478=1&858=1090&1037=1&1043=1&1068=0&1413=1090&1556=1&1965=1&263=8&1570=4&273=1|REV_371*8*0*0*2*0*0*6*2*0*0*2*0*False*False*False*False*False*False*False*False*False*False*False*False*False*0*False*True*False*0*False*False*False*False*False*False*False*49=3&50=1&53=6&202=39&466=2&48=2&45=2&203=3&478=1&1037=1&1043=1&1068=0&1556=1&263=9&1570=6~0~0~0~0~0~False=False=False=False=False=False~0~0~0~False~TSC_632,TSC_632,BOT_906,BOT_906,BOT_020,TSC_069,TSC_069,BOT_907,BOT_907,GVG_006,GVG_006,TSC_079,TSC_079,TSC_083,TSC_083,TSC_928,TSC_928,GVG_058,GVG_058,TSC_644,TSC_644,BOT_700,AV_343,AV_343,TSC_059,TSC_059,BOT_312,BOT_312,TSC_649,BOT_548~0~0~0~0~0~False~False~3~False~0~0~0~0~0~0~0~0~0~0~False~0~False~0~0~2~0~4~0~30=1&50=1&202=2&17=1&20=3&23=1&26=3&27=64&28=10&29=4&31=1&49=1&53=2&176=10&271=6&272=1&305=4&399=1&995=4&1292=1&1556=1&1853=7&2166=6&2323=1&2349=4&1854=1&467=0&2245=0&25=0&418=2&1025=2&464=0&1575=0&1573=1&406=0&1739=0&394=1&358=0~30=2&50=2&202=2&17=1&20=3&24=1&25=3&26=3&27=66&28=10&29=4&31=2&49=1&53=3&176=10&271=6&272=1&305=4&358=3&394=1&399=1&406=0&418=6&995=3&1556=1&1739=0&2166=41&2245=3&2335=1&1292=0&23=0&467=0&269=1&317=1&266=0&417=0~0~0~=1=PLAY=False|=2=PLAY=True|=3=PLAY=False|=4=DECK=True|=5=DECK=True|REV_371=6=HAND=True|=7=DECK=True|=8=DECK=True|=9=DECK=True|=10=DECK=True|REV_835=11=HAND=True|=12=DECK=True|=13=DECK=True|TSC_962=14=HAND=True|=15=DECK=True|=16=DECK=True|CORE_EX1_319=17=HAND=True|=18=DECK=True|=19=DECK=True|=20=DECK=True|=21=DECK=True|=22=DECK=True|=23=DECK=True|=24=DECK=True|=25=DECK=True|=26=DECK=True|CORE_CS2_065=27=HAND=True|=28=DECK=True|=29=DECK=True|CORE_EX1_319=30=HAND=True|SW_086=31=HAND=True|REV_244=32=HAND=True|=33=DECK=True|=34=DECK=False|=35=DECK=False|=36=DECK=False|=37=DECK=False|=38=DECK=False|=39=DECK=False|=40=HAND=False|=41=HAND=False|EX1_506=42=PLAY=False|=43=DECK=False|=44=DECK=False|=45=DECK=False|=46=DECK=False|=47=DECK=False|=48=DECK=False|=49=DECK=False|=50=DECK=False|EX1_019=51=PLAY=False|=52=DECK=False|=53=HAND=False|=54=DECK=False|=55=HAND=False|=56=DECK=False|=57=DECK=False|=58=DECK=False|=59=DECK=False|=60=DECK=False|=61=DECK=False|=62=DECK=False|=63=DECK=False|HERO_07a=64=PLAY=True|CS2_056_H1=65=PLAY=True|HERO_10=66=PLAY=False|HERO_10bp=67=PLAY=False|BAR_COIN1=68=HAND=True|=77=GRAVEYARD=False|EX1_506a=79=PLAY=False|EX1_019e=81=PLAY=False|~

*/