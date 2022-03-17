using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

namespace SmartBotAPI.Plugins.API
{

    public class SMK_TempoMage : Archetype
    {
        public string ArchetypeName()
        {
            return "SMK_Tempo_Mage";
        }

        public List<Card.Cards> ArchetypeCardSet()
        {
            return new List<Card.Cards>()
            {
                Cards.Aluneth,
                Cards.AncientMysteries,
                Cards.ArcaneFlakmage,
                Cards.ArcaneIntellect,
                Cards.ArcaneMissiles,
                Cards.Arcanologist,
                Cards.ArchmageAntonidas,
                Cards.BreathofSindragosa,
                Cards.Cinderstorm,
                Cards.CloudPrince,
                Cards.Counterspell,
                Cards.Duplicate,
                Cards.ExplosiveRunes,
                Cards.Fireball,
                Cards.FlameWard,
                Cards.Frostbolt,
                Cards.IceBlock,
                Cards.KabalLackey,
                Cards.KirinTorMage,
                Cards.MadScientist,
                Cards.ManaWyrm,
                Cards.MedivhsValet,
                Cards.MirrorImage,
                Cards.PrimordialGlyph,
                Cards.Pyroblast,
                Cards.SorcerersApprentice,
                Cards.StargazerLuna,
                Cards.VexCrow,
            };
        }
    }
}