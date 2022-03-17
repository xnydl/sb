using System.Collections.Generic;
using SmartBot.Plugins.API;

namespace SmartBotAPI.Plugins.API
{

    public class SMK_ClassicZooWarlock : Archetype
    {
        public string ArchetypeName()
        {
            return "SMK_Classic_Zoo_Warlock";
        }

        public List<Card.Cards> ArchetypeCardSet()
        {
            return new List<Card.Cards>()
            {
                Cards.Classic.Soulfire,
                Cards.Classic.AbusiveSergeant,
                Cards.Classic.ArgentSquire,
                Cards.Classic.FlameImp,
                Cards.Classic.LeperGnome,
                Cards.Classic.MortalCoil,
                Cards.Classic.Voidwalker,
                Cards.Classic.YoungPriestess,
                Cards.Classic.DireWolfAlpha,
                Cards.Classic.IronbeakOwl,
                Cards.Classic.KnifeJuggler,
                Cards.Classic.HarvestGolem,
                Cards.Classic.ScarletCrusader,
                Cards.Classic.DarkIronDwarf,
                Cards.Classic.DefenderofArgus,
                Cards.Classic.Doomguard,
                Cards.Classic.Shieldbearer,
                Cards.Classic.ShatteredSunCleric,
                Cards.Classic.ArgentCommander,
                Cards.Classic.LordJaraxxus,
                Cards.Classic.AmaniBerserker,
            };
        }
    }
}