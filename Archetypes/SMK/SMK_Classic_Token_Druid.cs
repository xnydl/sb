using System.Collections.Generic;
using SmartBot.Plugins.API;

namespace SmartBotAPI.Plugins.API
{

    public class SMK_ClassicTokenDruid : Archetype
    {
        public string ArchetypeName()
        {
            return "SMK_Classic_Token_Druid";
        }

        public List<Card.Cards> ArchetypeCardSet()
        {
            return new List<Card.Cards>()
            {
                Cards.Classic.Innervate,
                Cards.Classic.ArgentSquire,
                Cards.Classic.BloodmageThalnos,
                Cards.Classic.LootHoarder,
                Cards.Classic.PoweroftheWild,
                Cards.Classic.Wrath,
                Cards.Classic.BigGameHunter,
                Cards.Classic.HarvestGolem,
                Cards.Classic.SavageRoar,
                Cards.Classic.KeeperoftheGrove,
                Cards.Classic.Swipe,
                Cards.Classic.VioletTeacher,
                Cards.Classic.AzureDrake,
                Cards.Classic.DruidoftheClaw,
                Cards.Classic.ForceofNature,
                Cards.Classic.AncientofLore,
            };
        }
    }
}