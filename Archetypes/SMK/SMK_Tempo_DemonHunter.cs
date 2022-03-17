using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

namespace SmartBotAPI.Plugins.API
{

    public class SMK_TempoDemonHunter : Archetype
    {
        public string ArchetypeName()
        {
            return "SMK_Tempo_DemonHunter";
        }

        public List<Card.Cards> ArchetypeCardSet()
        {
            return new List<Card.Cards>()
            {
                Cards.TwinSlice,
                Cards.Battlefiend,
                Cards.CrimsonSigilRunner,
                Cards.ChaosStrike,
                Cards.SpectralSight,
                Cards.Umberwing,
                Cards.EyeBeam,
                Cards.SatyrOverseer,
                Cards.AltruistheOutcast,
                Cards.KaynSunfury,
                Cards.GlaiveboundAdept,
                Cards.Metamorphosis,
                Cards.WarglaivesofAzzinoth,
                Cards.SkullofGuldan,
                Cards.BlazingBattlemage,
                Cards.SightlessWatcher,
                Cards.FrenziedFelwing,

                Cards.FuriousFelfin,
                Cards.AshtongueBattlelord,
                Cards.IllidariFelblade,
                Cards.ImprisonedAntaen,
                Cards.PriestessofFury,
                Cards.CoilfangWarlord
            };
        }
    }
}