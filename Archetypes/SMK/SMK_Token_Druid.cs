using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

namespace SmartBotAPI.Plugins.API
{

    public class SMK_TokenDruid : Archetype
    {
        public string ArchetypeName()
        {
            return "SMK_Token_Druid";
        }

        public List<Card.Cards> ArchetypeCardSet()
        {
            return new List<Card.Cards>()
            {
                Cards.Acornbearer,
                Cards.Treenforcements,
                Cards.DreamwayGuardians,
                Cards.Fungalmancer,
                Cards.PoweroftheWild,
                Cards.RisingWinds,
                Cards.BEEEES,
                Cards.BlessingoftheAncients,
                Cards.SavageRoar,
                Cards.GardenGnome,
                Cards.SouloftheForest,
                Cards.Swipe,
                Cards.Aeroponics,
                Cards.AnubisathDefender,
                Cards.ForceofNature,
                Cards.GlowflySwarm,
                Cards.TheForestsAid
            };
        }
    }
}