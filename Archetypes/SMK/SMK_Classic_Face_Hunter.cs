using System;
using System.Collections.Generic;
using System.Linq;
using SmartBot.Database;
using SmartBot.Plugins.API;

namespace SmartBotAPI.Plugins.API
{

    public class SMK_ClassicFaceHunter : Archetype
    {
        public string ArchetypeName()
        {
            return "SMK_Classic_Face_Hunter";
        }

        public List<Card.Cards> ArchetypeCardSet()
        {
            return new List<Card.Cards>()
            {
                Cards.Classic.HuntersMark,
                Cards.Classic.AbusiveSergeant,
                Cards.Classic.ArgentSquire,
                Cards.Classic.LeperGnome,
                Cards.Classic.TimberWolf,
                Cards.Classic.Tracking,
                Cards.Classic.WorgenInfiltrator,
                Cards.Classic.ExplosiveTrap,
                Cards.Classic.KnifeJuggler,
                Cards.Classic.Misdirection,
                Cards.Classic.AnimalCompanion,
                Cards.Classic.ArcaneGolem,
                Cards.Classic.EaglehornBow,
                Cards.Classic.KillCommand,
                Cards.Classic.UnleashtheHounds,
                Cards.Classic.Wolfrider,
                Cards.Classic.LeeroyJenkins,
                Cards.Classic.Flare,
                Cards.Classic.ArcaneShot,
                Cards.Classic.BluegillWarrior,
                Cards.Classic.IronbeakOwl,
                Cards.Classic.FreezingTrap,
                Cards.Classic.StarvingBuzzard,
            };
        }
    }
}