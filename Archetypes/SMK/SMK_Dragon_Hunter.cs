using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

namespace SmartBotAPI.Plugins.API
{

    public class DragonHunterArchetype : Archetype
    {
        public string ArchetypeName()
        {
            return "SMK_Dragon_Hunter";
        }

        public List<Card.Cards> ArchetypeCardSet()
        {
            return new List<Card.Cards>()
            {
                Cards.BeamingSidekick,
                Cards.DwarvenSharpshooter,
                Cards.Tracking,
                Cards.CorrosiveBreath,
                Cards.DragonBreeder,
                Cards.ExplosiveTrap,
                Cards.FaerieDragon,
                Cards.PhaseStalker,
                Cards.SnakeTrap,
                Cards.PrimordialExplorer,
                Cards.Scalerider,
                Cards.Stormhammer,
                Cards.EvasiveFeywing,
                Cards.Lifedrinker,
                Cards.BigOlWhelp,
                Cards.LeeroyJenkins
            };
        }
    }
}