using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

namespace SmartBotAPI.Plugins.API
{

    public class SMK_WildMurlocPaladin : Archetype
    {
        public string ArchetypeName()
        {
            return "SMK_Wild_Murloc_Paladin";
        }

        public List<Card.Cards> ArchetypeCardSet()
        {
            return new List<Card.Cards>()
            {
                Cards.GrimscaleOracle,
                Cards.MurlocTidecaller,
                Cards.Murmy,
                Cards.SirFinleyMrrgglton,
                Cards.VilefinInquisitor,
                Cards.BluegillWarrior,
                Cards.Hydrologist,
                Cards.MurgurMurgurgle,
                Cards.RockpoolHunter,
                Cards.MurlocWarleader,
                Cards.UnderlightAnglingRod,
                Cards.FishyFlyer,
                Cards.GentleMegasaur,
                Cards.HighAbbessAlura,
                Cards.OldMurkEye,
                Cards.PrismaticLens,
                Cards.TiptheScales
            };
        }
    }
}