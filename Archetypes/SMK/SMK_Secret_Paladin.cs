using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

namespace SmartBotAPI.Plugins.API
{

    public class SMK_SecretPaladin : Archetype
    {
        public string ArchetypeName()
        {
            return "SMK_Secret_Paladin";
        }

        public List<Card.Cards> ArchetypeCardSet()
        {
            return new List<Card.Cards>()
            {
                Cards.FirstDayofSchool,
                Cards.Avenge,
                Cards.Core.Avenge,
                Cards.NobleSacrifice,
                Cards.Core.NobleSacrifice,
                Cards.OhMyYogg,
                Cards.RighteousProtector,
                Cards.Core.RighteousProtector,
                Cards.HandofAdal,
                Cards.SunreaverSpy,
                Cards.Core.SunreaverSpy,
                Cards.SwordoftheFallen,
                Cards.CrossroadsGossiper,
                Cards.NorthwatchCommander,
                Cards.KazakusGolemShaper,
                Cards.CannonmasterSmythe,
                Cards.GallopingSavior,
                Cards.IntrepidInitiate,
                Cards.KnightofAnointment,
                Cards.Core.Reckoning,
                Cards.MurgurMurgurgle,
                Cards.GoodyTwoShields,
                Cards.VoraciousReader,
            };
        }
    }
}