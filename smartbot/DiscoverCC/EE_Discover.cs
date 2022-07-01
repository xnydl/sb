using SmartBot.Database;
using SmartBot.Discover;
using SmartBot.Plugins.API;
using SmartBotAPI.Plugins.API;
using SmartBotAPI.Plugins.API.HSReplayArchetypes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace EE_Discover
{
    //======================================================//
    // Operation    Version 5.3            by Evil_Eyes     //
    //                                                      //
    //  * Includes cards for Standard, Wild, Classic, Arena //
    //    Duels.                                            //
    //  * Searches for the best card from an origin card    //
    //    in the following order.                           //
    // 1) Searches for an external custom made file,        //
    //    combining the words "Custom" and the name of the  //
    //    card with either Local or HSReplay Archetype.     //
    // 2) Searches for card using statistics from           //
    //    "HSReplay, Most popular Discover choices".        //
    // 3) Options to override points from external files.   //
    // 4) Cards missing is then searched from a backup file //
    //    using statistics from "HSReplay" includes all     //
    //    cards from Hearthstone.                           //
    //======================================================//

    public class EE_Discover : DiscoverPickHandler
    {
        //Global variables declaration
        private string _mode = "Wild", _discoverFile, fileName;
        private IniManager _iniTierList0;
        private string _log;

        //Card Handle Pick Decision from SB
        public Card.Cards HandlePickDecision(Card.Cards originCard, List<Card.Cards> choices, Board board) //originCard; ID of card played by SB: choices; names of cards for selection: board; 3 states , Even, Losing, Winning
        {
            //Local variables declaration
            String[] heroes = { "none", "WARRIOR", "SHAMAN", "ROGUE", "PALADIN", "HUNTER", "DRUID", "WARLOCK", "MAGE", "PRIEST", "DEMONHUNTER" };
            int _discoverIndex = 1;
            string Version = "=====Discover ChoicesV5.3=====", description = null;
            string Divider = new string('=', 50);
            string Origin_Card = CardTemplate.LoadFromId(originCard).Name;
            Random rnd = new Random();
            Card.Cards bestChoice = choices[rnd.Next(0, choices.Count)]; //final random choice if no cards found
            //Get current play mode
            _mode = CurrentMode(Bot.CurrentMode());
            //Create card list
            List<CardValue> choicesCardValue = new List<CardValue>();
            //Get custom file if exists
            try
            {
                string currentAchetype = !String.IsNullOrEmpty(GetCurrentHSReplayArchetype()) ? GetCurrentHSReplayArchetype() : GetCurrentLocalArchetype();
                //Only get files that contains with the word "Custom" and bot current deck or discover card name.
                string[] fileNames = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\DiscoverCC\" + _mode + '\\', "Custom*.ini");
                foreach (string discoverFile in fileNames)
                {
                    //Get custom file if origin card name and current archetype matches
                    if (Regex.Replace(discoverFile, @"[\s+_,]", String.Empty).IndexOf(Regex.Replace(Origin_Card, @"[\s+_,]", String.Empty), StringComparison.OrdinalIgnoreCase) >= 0 && Regex.Replace(discoverFile, @"[\s+_,]", String.Empty).IndexOf(Regex.Replace(currentAchetype, @"[\s+_,]", String.Empty), StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Bot.Log("Using archetype: " + currentAchetype);
                        _discoverFile = discoverFile;
                        _discoverIndex = 0;
                        break;
                    }
                    else if (String.Equals(discoverFile, "Custom " + Origin_Card + ".ini", StringComparison.OrdinalIgnoreCase))
                    {
                        _discoverFile = discoverFile;
                        _discoverIndex = 0;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Bot.Log("[Discover] -> File not found");
                Bot.Log("More information in SmartBot forums");
                Bot.Log("https://smartbot.ws/forums/index.php?/topic/9672-evil_eyes-hsreplay-discover-choices/");
                _discoverIndex = 1;
            }
            //Main loop starts here
            double TotalPoints = 0;
            do
            {
                switch (_discoverIndex)
                {
                    case 0:
                        fileName = Path.GetFileName(_discoverFile);
                        _iniTierList0 = new IniManager(fileName); //load custom file into List
                        description = "From custom: " + fileName + ", Mode - " + _mode;
                        break;
                    case 1:
                        fileName = Origin_Card + ".ini";
                        _iniTierList0 = new IniManager(Directory.GetCurrentDirectory() + @"\DiscoverCC\" + _mode + '\\' + fileName); //load HSReplay file into List
                        description = "From: " + fileName + ", Mode - " + _mode;
                        break;
                    case 2:
                        _iniTierList0 = new IniManager(Directory.GetCurrentDirectory() + @"\DiscoverCC\" + _mode + '\\' + "discover.ini"); //load "discover.ini" file into List
                        description = "No cards found from: " + Origin_Card + ".ini, using: discover.ini, Mode - " + _mode;
                        break;
                }
                choicesCardValue.Clear();
                //Search for best points
                int heroIndex = 0;
                int friend;
                int.TryParse(_iniTierList0.GetString("Hero", "FriendClass", "0"), out friend);
                foreach (var card in choices) //loops for each card
                {
                    double points = 0;
                    var cardTemplate = CardTemplate.LoadFromId(card); //cardTemplate = Name of card + [CardId], card = CardId
                    //Check for any special conditions
                    switch (originCard)
                    {
                        case Card.Cards.BAR_079: //Kazakus, Golem Shaper, Forged in the Barrens
                            points = KazakusGolemShaper(CardTemplate.LoadFromId(bestChoice).Name, cardTemplate.Name, Bot.CurrentBoard);
                            description = "From: Kazakus, Golem Shaper, minion count: " + board.MinionFriend.Count + " mana available: " + board.ManaAvailable;
                            break;
                        case Card.Cards.DMF_075: //Guess the Weight, Madness at the Darkmoon Faire
                            if (card == Card.Cards.DMF_075a2) //Less!
                                points = Convert.ToDouble(GuessTheWeight(Bot.CurrentBoard).Split(new char[] { '/' })[0].Trim());
                            else if (card == Card.Cards.DMF_075a) //More!
                                points = Convert.ToDouble(GuessTheWeight(Bot.CurrentBoard).Split(new char[] { '/' })[1].Trim());
                            else
                                description = "From: Guess the Weight: " + cardTemplate.Name + "  Cost: " + cardTemplate.Cost.ToString(); //Display name and cost of weight card
                            break;
                        case Card.Cards.AV_295: //Capture Coldtooth Mine, Fractured in Alterac Valley
                            // if (card == Card.Cards.AV_295b) //More Supplies
                            // {
                            //     points = CaptureColdtoothMine(Bot.CurrentBoard);
                            //     description = points == 100 ? "Capture Coldtooth Mine, selecting highest cost card" : "Capture Coldtooth Mine, selecting lowest cost card";
                            // }
                            // else
                            //     points = 10; //More resources
                            description = "Capture Coldtooth Mine, selecting highest cost card";
                            break;
                        case Card.Cards.AV_258:  //Bru'kan of the Elements, Fractured in Alterac Valley
                            points = BrukanOfTheElements(card, Bot.CurrentBoard);
                            description = "Bru'kan of the Elements";
                            break;
                        default:
                            string HeroClass = friend == 1 ? board.FriendClass.ToString() : board.EnemyClass.ToString();//Get friendly/opponent hero class
                            double.TryParse(_iniTierList0.GetString(cardTemplate.Name, HeroClass, "0"), NumberStyles.Any, CultureInfo.InvariantCulture, out points); //search for card from TierList
                            if (points < 0.001) //if hero points is zero, search for default points
                                double.TryParse(_iniTierList0.GetString(cardTemplate.Name, "points", "0"), NumberStyles.Any, CultureInfo.InvariantCulture, out points);
                            else
                                heroIndex = Array.IndexOf(heroes, HeroClass);
                            break;
                    } //End of switch
                    choicesCardValue.Add(new CardValue(card, points, heroIndex, friend)); //add points, class, hero to each card
                    TotalPoints += points; //Adding points, check if points is not = zero
                }
                _discoverIndex++;
            } while (!(TotalPoints > 0 || _discoverIndex > 2));
            //Card selection with highest points
            double bestPoints = 0;
            _log = Version;
            for (var i = 0; i < choicesCardValue.Count; i++) //index through each card
            {
                var cardValue = choicesCardValue[i]; //index through cardValue
                double pts = cardValue.GetPoints(); //calls cardValue subroutine, get points
                int heroIndex = cardValue.GetHeroClass(); //calls cardValue subroutine, get hero class
                bool friend = Convert.ToBoolean(cardValue.GetFriend()); //calls cardValue subroutine, get friend/opponent hero
                string hero = heroIndex != 0 ? friend ? ", friend - " + heroes[heroIndex] : ", enemy - " + heroes[heroIndex] : null; //preparation to log
                AddLog(i + 1 + ") " + CardTemplate.LoadFromId(cardValue.GetCard()).Name + ": " + pts + hero); //output cards choices to log
                if (!(bestPoints < pts)) continue; //selects highest points
                bestChoice = cardValue.GetCard(); //calls cardValue subroutine, get card assign to bestChoice
                bestPoints = pts;
            }
            //Out to Bot log
            AddLog(Divider);
            AddLog("Best: " + CardTemplate.LoadFromId(bestChoice).Name + ": " + bestPoints);
            AddLog(description);
            AddLog(Divider);
            Bot.Log(_log);
            return bestChoice; //returns cardID
        }

        //Get from list
        public class CardValue
        {
            private readonly double _points;
            private readonly int _hero;
            private readonly int _friend;
            private readonly Card.Cards _card;

            public CardValue(Card.Cards card, double points, int hero, int friend)
            {
                _card = card;
                _points = points;
                _hero = hero;
                _friend = friend;
            }

            public Card.Cards GetCard()
            {
                return _card;
            }

            public double GetPoints()
            {
                return _points;
            }

            public int GetHeroClass()
            {
                return _hero;
            }

            public int GetFriend()
            {
                return _friend;
            }
        }

        //Memory management, input/output operations
        public class IniManager
        {
            private const int CSize = 1024;

            public IniManager(string path)
            {
                Path = path;
            }

            public IniManager()
                : this("")
            {
            }

            public string Path { get; set; }

            public string GetString(string section, string key, string Default = null)
            {
                StringBuilder buffer = new StringBuilder(CSize);
                GetString(section, key, Default, buffer, CSize, Path);
                return buffer.ToString();
            }

            public void WriteString(string section, string key, string sValue)
            {
                WriteString(section, key, sValue, Path);
            }

            [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
            private static extern int GetString(string section, string key, string def, StringBuilder bufer, int size, string path);

            [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
            private static extern int WriteString(string section, string key, string str, string path);
        }

        //Return current mode
        private static string CurrentMode(Bot.Mode mode)
        {
            switch (mode)
            {
                case Bot.Mode.Arena:
                case Bot.Mode.ArenaAuto:
                    return "Arena";
                case Bot.Mode.Standard:
                    return "Standard";
                case Bot.Mode.Wild:
                    return "Wild";
                case Bot.Mode.Classic:
                    return "Classic";
                default:
                    return "Wild";
            }
        }

        //Get Current Local Archetype
        private static string GetCurrentLocalArchetype()
        {
            var localArchetype = ArchetypeDetector.DetectArchetype(Bot.GetSelectedDecks()[0].Cards.Select(x => CardTemplate.StringToCard(x)).ToList(), Bot.GetArchetypes());
            if (localArchetype == null) return string.Empty; //Couldn't find archetype
            return localArchetype.ArchetypeName();
        }

        //Get Current HSReplay Archetype
        private static string GetCurrentHSReplayArchetype()
        {
            var HSReplayArchetype = HSReplayArchetypesMatcher.DetectArchetype(Bot.GetSelectedDecks()[0].Cards, Bot.GetSelectedDecks()[0].Class, 30);
            if (HSReplayArchetype == null || HSReplayArchetype is HSReplayArchetypeError)
                return string.Empty; //Archetype couldn't be found
            return HSReplayArchetype.Name;
        }

        //Adds text to log variable
        private void AddLog(string log)
        {
            _log += "\r\n" + log;
        }

        // *********** Special conditions ***********
        //Kazakus, Golem Shaper, Forged in the Barrens
        private static double KazakusGolemShaper(string bestChoice, string kazakusCard, Board board)
        {
            //Kazakus, Golem Shaper choice cards 
            var kazakusCards = new List<Kazakus>() // Create a list of Kazakus choiceCards
            {   // First choice
                new Kazakus(){ Name = "Lesser Golem", Points = 200, AltPoints = 200, GrtPoints = 100 },
                new Kazakus(){ Name = "Greater Golem", Points = 100, AltPoints = 100, GrtPoints = 200 },
                new Kazakus(){ Name = "Superior Golem", Points = 10, AltPoints = 10, GrtPoints = 10 },
                // Second choice
                new Kazakus(){ Name = "Grave Moss", Points = 200, AltPoints = 1, GrtPoints = 60 }, // 38 HSReplay points
                new Kazakus(){ Name = "Sungrass", Points = 199, AltPoints = 1, GrtPoints = 100 }, // 80
                new Kazakus(){ Name = "Fadeleaf", Points = 198, AltPoints = 1, GrtPoints = 70 }, // 42
                new Kazakus(){ Name = "Earthroot", Points = 197, AltPoints = 1, GrtPoints = 50 }, // 29
                new Kazakus(){ Name = "Liferoot", Points = 196, AltPoints = 1, GrtPoints = 80 }, // 45
                new Kazakus(){ Name = "Swifthistle", Points = 195, AltPoints = 1, GrtPoints = 90 }, // 72
                // Third choice
                new Kazakus(){ Name = "Wildvine", Points = 200, AltPoints = 200, GrtPoints = 80 }, // 55
                new Kazakus(){ Name = "Firebloom", Points = 198, AltPoints = 2, GrtPoints = 90 }, // 62
                new Kazakus(){ Name = "Gromsblood", Points = 197, AltPoints = 1, GrtPoints = 100 }, // 113
                new Kazakus(){ Name = "Kingsblood", Points = 196, AltPoints = 196, GrtPoints = 70 }, // 40
                new Kazakus(){ Name = "Icecap", Points = 195, AltPoints = 199, GrtPoints = 60 }, // 23
                new Kazakus(){ Name = "Mageroyal", Points = 1, AltPoints = 194, GrtPoints = 50 }, // 8
            };
            //Override Kazakus, Golem Shaper points
            if (board.MinionFriend.Count > 3 && board.ManaAvailable <= 8) //Lesser Golem, more than 3 minions and less than 9 mana
            {
                int index = kazakusCards.FindIndex(x => x.Name == bestChoice);
                foreach (var cards in kazakusCards)
                {
                    if (kazakusCard == cards.Name)
                        return index > -1 && kazakusCards[index].Points == 200 ? cards.Points : cards.AltPoints;
                }
            }
            return kazakusCards[kazakusCards.FindIndex(x => x.Name == kazakusCard)].GrtPoints; //If conditions not meet, return GrtPoints points
        }

        private class Kazakus
        {
            public string Name { get; set; }
            public double Points { get; set; }
            public double AltPoints { get; set; }
            public double GrtPoints { get; set; }
        }

        //Guess the weight, Madness at the Darkmoon Faire
        private static string GuessTheWeight(Board board)
        {
            //Get list of current cards in my deck
            List<Card.Cards> currentDeck = new List<Card.Cards>();
            currentDeck = CurretDeck(Bot.CurrentBoard);

            //Cost of last card in hand
            int lastCardCost = board.Hand.LastOrDefault().CurrentCost;

            //Return Less/More counting cost
            return currentDeck.Select(CardTemplate.LoadFromId).Count(x => x.Cost < lastCardCost) + "/" + currentDeck.Select(CardTemplate.LoadFromId).Count(x => x.Cost > lastCardCost);
        }

        //Capture Coldtooth Mine, Fractured in Alterac Valley
        private static double CaptureColdtoothMine(Board board) //Select highest cost card if equal or 1 higher current mana available
        {
            //Get list of current cards in my deck
            List<Card.Cards> currentDeck = new List<Card.Cards>();
            currentDeck = CurretDeck(Bot.CurrentBoard);
            if (currentDeck.Select(CardTemplate.LoadFromId).Max(x => x.Cost) >= board.ManaAvailable - 1)
                return 100;
            return 1;
        }

        //Bru'kan of the Elements, Fractured in Alterac Valley
        private static double BrukanOfTheElements(Card.Cards choice, Board board)
        {
            double[] points = { 40, 10, 30, 20 }; //Earth Invocation[0], Water Invocation[1], Fire Invocation[2], Lightning Invocation[3]
            //Choice
            if (EnemyDefence(Bot.CurrentBoard) - FriendAttack(Bot.CurrentBoard) <= 6) //Can opponent hero can be destroyed this turn
                points[2] = 100; //Fire Invocation
            else if (board.MinionEnemy.Count > 1 && EnemyMinionCurrentHealth(Bot.CurrentBoard) / board.MinionEnemy.Count < 4) //If opponent has more than 2 minions on board average health 3 or less. Deal 2 damage to all enemy minions
                points[3] = 90; //for Lightning Invocation
            else if (EnemyHasLethal(Bot.CurrentBoard)) //Block opponent lethal attack
                points[0] = 80; //Earth Invocation
            else if (FriendMinionDamage(Bot.CurrentBoard) > 2) //If friend has more than 2 damaged minions on board. Restore 6 Health to all friendly characters
                points[1] = 70; //Water Invocation

            switch (choice)
            {
                case Card.Cards.AV_258t:  //Earth Invocation, Summon two 2/3 Elementals with Taunt
                    return points[0];
                case Card.Cards.AV_258t2: //Water Invocation(67816) Restore 6 Health to all friendly characters
                    return points[1];
                case Card.Cards.AV_258t3: //Fire Invocation(67817) Deal 6 damage to the enemy hero
                    return points[2];
                case Card.Cards.AV_258t4: //Lightning Invocation(67818) Deal 2 damage to all enemy minions
                    return points[3];
            }
            return 0;
        }

        //Return list of current cards remaining in my deck
        private static List<Card.Cards> CurretDeck(Board board)
        {
            //List<Card.Cards> load list of card from deck -> _myDeck
            List<Card.Cards> _myDeck = new List<Card.Cards>();
            _myDeck = Bot.CurrentDeck().Cards.Select(card => (Card.Cards)Enum.Parse(typeof(Card.Cards), card)).ToList(); //from Soviet_Mulligan_Kit

            //List<Card.Cards> load list of cards from hand -> _myHand
            List<Card.Cards> _myHand = new List<Card.Cards>();
            foreach (var card in board.Hand)
                _myHand.Add(card.Template.Id);

            //List<Card.Cards> load list of cards from board -> _myBoard
            List<Card.Cards> _myBoard = new List<Card.Cards>();
            foreach (var card in board.MinionFriend)
                _myBoard.Add(card.Template.Id);

            //List<Card.Cards> load list of cards from my GraveYard -> _myGraveYard
            List<Card.Cards> _myGraveYard = new List<Card.Cards>();
            _myGraveYard = board.FriendGraveyard;

            //List combined and (one item per loop subtraction) -> _myDeck
            foreach (var card in _myBoard.Concat(_myHand).Concat(_myGraveYard))
                _myDeck.Remove(card);

            return _myDeck;
        }

        //Check if enemy has lethal
        private static bool EnemyHasLethal(Board board)
        {
            if (board.MinionFriend.Any(x => x.IsTaunt)) return false;
            return board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor
            <= board.MinionEnemy.FindAll(x => x.CanAttack && (x.IsCharge || x.NumTurnsInPlay != 0) && x.CountAttack == 0 && !x.IsTired).Sum(x => x.CurrentAtk)
            + (board.HasWeapon(false) && board.HeroEnemy.CountAttack == 0 ? board.WeaponEnemy.CurrentAtk : 0);
        }

        //Calculate friendly attack value
        private static int FriendAttack(Board board)
        {
            return (board.MinionFriend.FindAll(x => x.CanAttack && (x.IsCharge || x.NumTurnsInPlay != 0) && x.CountAttack == 0 && !x.IsTired).Sum(x => x.CurrentAtk) + (board.HasWeapon(false) && board.HeroFriend.CountAttack == 0 ? board.WeaponFriend.CurrentAtk : 0));
        }

        //Calculate friendly defense value
        private static int FriendDefence(Board board)
        {
            return board.HeroFriend.CurrentHealth + board.HeroFriend.CurrentArmor + (board.MinionFriend.FindAll(x => x.IsTaunt == true).Sum(x => x.CurrentHealth));
        }

        //Friendly minion damage count
        private static int FriendMinionDamage(Board board)
        {
            int damageCount = 0;
            foreach (var card in board.MinionFriend)
            {
                if (CardTemplate.LoadFromId(card.Template.Id).Health > card.CurrentHealth)
                    damageCount++;
            }
            return damageCount;
        }

        //Calculate opponent attack value
        private static int EnemyAttack(Board board)
        {
            return board.MinionEnemy.FindAll(x => x.CanAttack && (x.IsCharge || x.NumTurnsInPlay != 0) && x.CountAttack == 0 && !x.IsTired).Sum(x => x.CurrentAtk) + (board.HasWeapon(false) && board.HeroEnemy.CountAttack == 0 ? board.WeaponEnemy.CurrentAtk : 0);
        }

        //Calculate opponent defense value
        private static int EnemyDefence(Board board)
        {
            return board.HeroEnemy.CurrentHealth + board.HeroEnemy.CurrentArmor + (board.MinionEnemy.FindAll(x => x.IsTaunt == true).Sum(x => x.CurrentHealth));
        }

        //Calculate opponent board health value
        private static int EnemyMinionCurrentHealth(Board board)
        {
            return board.MinionEnemy.FindAll(x => x.CanAttack && (x.IsCharge || x.NumTurnsInPlay != 0) && x.CountAttack == 0 && !x.IsTired).Sum(x => x.CurrentHealth);
        }
    }
}
