using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

namespace SmartBotAPI.Plugins.API
{

    public class SMK_MurlocPaladin : Archetype
    {
        public string ArchetypeName()
        {
            return "SMK_Murloc_Paladin";
        }

        public List<Card.Cards> ArchetypeCardSet()
        {
            return new List<Card.Cards>()
            {
                Cards.ImprisonedSungill,
                Cards.MurlocTidecaller,
                Cards.Murmy,
                Cards.Toxfin,
                Cards.Fishflinger,
                Cards.HandofAdal,
                Cards.HenchClanHogsteed,
                Cards.MurgurMurgurgle,
                Cards.MurlocTidehunter,
                Cards.ColdlightSeer,
                Cards.MurlocWarleader,
                Cards.UnderlightAnglingRod,
                Cards.FelfinNavigator,
                Cards.HoardPillager,
                Cards.TruesilverChampion,
                Cards.Consecration,
                Cards.Scalelord,
            };
        }
    }
}