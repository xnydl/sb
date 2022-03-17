using System.Collections.Generic;
using SmartBot.Plugins.API;

namespace SmartBotAPI.Plugins.API
{

    public class SMK_ClassicMidrangeShaman : Archetype
    {
        public string ArchetypeName()
        {
            return "SMK_Classic_Midrange_Shaman";
        }

        public List<Card.Cards> ArchetypeCardSet()
        {
            return new List<Card.Cards>()
            {
                Cards.Classic.ArgentSquire,
                Cards.Classic.EarthShock,
                Cards.Classic.LightningBolt,
                Cards.Classic.RockbiterWeapon,
                Cards.Classic.AcidicSwampOoze,
                Cards.Classic.BloodmageThalnos,
                Cards.Classic.FlametongueTotem,
                Cards.Classic.FeralSpirit,
                Cards.Classic.Hex,
                Cards.Classic.LavaBurst,
                Cards.Classic.LightningStorm,
                Cards.Classic.ManaTideTotem,
                Cards.Classic.UnboundElemental,
                Cards.Classic.DefenderofArgus,
                Cards.Classic.Doomhammer,
                Cards.Classic.FireElemental,
                Cards.Classic.AlAkirtheWindlord,
                Cards.Classic.RagnarostheFirelord,

                Cards.Classic.KoboldGeomancer,
                Cards.Classic.ChillwindYeti,
                Cards.Classic.ShatteredSunCleric,
                Cards.Classic.StormforgedAxe,
                Cards.Classic.MurlocTidehunter,
                Cards.Classic.Bloodlust,
            };
        }
    }
}