using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModUtil;
using Prototype;
using TangentSpysColourLib;
using EconAPI;
using EcoPlayer;

namespace SpaceEngineersEmulation
{
    // Emulating Space Engineers
    static class SpaceEngineers
    {
        // List of Space Engineers game items
        private static string[] GameItems = new string[] {
            "Cobalt Ore",
            "Gold Ore",
            "Iron Ore",
            "Magnesium Ore",
            "Nickel Ore",
            "Platinum Ore",
            "Silicon Ore",
            "Silver Ore",
            "Stone",
            "Antenna",
            "Artificial Mass",
            "Assembler",
            "Beacon",
            "Cargo Container, Large",
            "Cargo Container, Medium",
            "Cargo Container, Small",
            "Cockpit 1",
            "Cockpit 2",
            "Cockpit 3",
            "Collector",
            "Connector",
            "Conveyor",
            "Conveyor, Small",
            "Conveyor Frame",
            "Conveyor Tube",
            "Conveyor Tube, Small",
            "Conveyor Tube, Curved",
            "Conveyor Tube, Small Curved",
            "Cover Wall, Full",
            "Cover Wall, Half",
            "Decoy",
            "Door",
            "Drill",
            "Ejector",
            "Gatling Gun",
            "Gatling Turret",
            "Gravity Generator",
            "Gyroscope",
            "Interior Light",
            "Interior Pillar",
            "Interior Turret",
            "Interior Wall",
            "Landing Gear",
            "Grinder",
            "Medical Room",
            "Missile Turret",
            "Ore Detector",
            "Passage",
            "Ramp",
            "Reactor, Large",
            "Reactor, Small",
            "Refinery",
            "Rocket Launcher",
            "Rotor",
            "Solar Panel",
            "Spotlight",
            "Stairs",
            "Steel Catwalk",
            "Thruster, Large",
            "Thruster, Small",
            "Warhead",
            "Welder",
            "Wheel, 1x1",
            "Wheel, 3x3",
            "Wheel, 5x5",
            "Window, Diagonal",
            "Window, Vertical",
            "Window 1x1 Face",
            "Window 1x1 Flat",
            "Window 1x1 Flat Inv",
            "Window 1x1 Inv",
            "Window 1x1 Side",
            "Window 1x1 Slope",
            "Window 1x2 Face",
            "Window 1x2 Flat",
            "Window 1x2 Flat Inv",
            "Window 1x2 Inv",
            "Window 1x2 Side Left",
            "Window 1x2 Side Right",
            "Window 1x2 Slope",
            "Window 2x3 Flat",
            "Window 2x3 Flat Inv",
            "Window 3x3 Flat",
            "Window 3x3 Flat Inv",
            "Spherical Gravity Generator",
            "Space Ball",
            "Window, Diagonal",
            "Window, Vertical",
            "Wheel, 1x1",
            "Wheel, 3x3",
            "Wheel, 5x5",
            "Battery"
        };

        // getBlocks()
        /// <summary>
        /// This function gets a list of Space Engineers items for emulation.
        /// </summary>
        /// <returns>SpaceEngineers Game Items Array</returns>
        public static string[] getItems()
        {
            return GameItems;
        }

        public static void CommandHandler(bool Repeat)
        {
            if (Repeat)
            {
                Console.Write("> ");
                string Input = Console.ReadLine().ToLower();
                if (Input.StartsWith("/"))
                {
                    if (Input.Split(' ').Length >= 1)
                    {
                        string Command = Input.Split(' ')[0];

                        switch (Command)
                        {
                            case "/hello":
                                Console.WriteLine("Hello World!");
                                CommandHandler(true);
                                break;
                            case "/exit":
                                break;
                            case "/bal":
                                string[] CommandArgs = Input.Split(' ');
                                if (CommandArgs.Length <= 1)
                                {
                                    Console.WriteLine("Your balance is: $" + BalanceAPI.getBalance());
                                }
                                CommandHandler(true);
                                break;
                            case "/help":
                                command_Help();
                                CommandHandler(true);
                                break;
                            case "/list":
                                if (Input.Split(' ').Length >= 2)
                                {
                                        string SubCommand = Input.Split(' ')[1];
                                        switch (SubCommand)
                                        {
                                            case "players":
                                                command_listPlayers();
                                                CommandHandler(true);
                                                break;
                                            case "items":
                                            command_Items();
                                            CommandHandler(true);
                                                break;
                                            default:
                                                    ColourEngine.writeLine("Syntax: /list [players|items]", ConsoleColor.DarkGreen, Console.BackgroundColor);
                                                    CommandHandler(true);
                                                    break;
                                        }
                                }
                                else
                                {
                                    ColourEngine.writeLine("Syntax: /list [players|items]", ConsoleColor.DarkGreen, Console.BackgroundColor);
                                    CommandHandler(true);
                                    break;
                                }
                                break;
                            default:
                                ColourEngine.writeLine("The command you entered, does not exist!", ConsoleColor.Red, Console.BackgroundColor);
                                CommandHandler(true);
                                break;
                        }
                    }
                }
                else
                {
                    ColourEngine.write(SEMod.playerName + "> ", ConsoleColor.White, Console.BackgroundColor);
                    ColourEngine.writeLine(Input, ConsoleColor.Green, Console.BackgroundColor);
                    CommandHandler(true);
                }
            }
        }

        public static void onServerJoinHandler(Player JoinedPlayer)
        {
            if (ConfigAPI.loadProfile(JoinedPlayer))
            {
                PlayerAPI.createPlayer(JoinedPlayer);
                ColourEngine.write("[Project Eco] ", ConsoleColor.Magenta, Console.BackgroundColor);
                ColourEngine.writeLine("Welcome " + JoinedPlayer.playerName + " to the server!", ConsoleColor.Red, Console.BackgroundColor);
            }
            else
            {
                ServerAPI.playerList.Add(JoinedPlayer);
                ColourEngine.write("[Project Eco] ", ConsoleColor.Magenta, Console.BackgroundColor);
                ColourEngine.writeLine(JoinedPlayer.playerName + " joined the server.", ConsoleColor.Yellow, Console.BackgroundColor);
            }
        }

        public static void command_Help()
        {
            ColourEngine.writeLine("----------------------------------------", ConsoleColor.Cyan, Console.BackgroundColor);
            ColourEngine.writeLine("                 [HELP]                 ", ConsoleColor.Cyan, Console.BackgroundColor);
            ColourEngine.writeLine("----------------------------------------", ConsoleColor.Cyan, Console.BackgroundColor);
            ColourEngine.writeLine("                                        ", ConsoleColor.Cyan, Console.BackgroundColor);
            ColourEngine.writeLine("  /bal                                  ", ConsoleColor.Yellow, Console.BackgroundColor);
            ColourEngine.writeLine("  /hello                                ", ConsoleColor.Yellow, Console.BackgroundColor);
            ColourEngine.writeLine("  /help                                 ", ConsoleColor.Yellow, Console.BackgroundColor);
            ColourEngine.writeLine("  /list [players|items]                 ", ConsoleColor.Yellow, Console.BackgroundColor);
            ColourEngine.writeLine("  /exit                                 ", ConsoleColor.Yellow, Console.BackgroundColor);
            ColourEngine.writeLine("                                        ", ConsoleColor.Cyan, Console.BackgroundColor);
            ColourEngine.writeLine("----------------------------------------", ConsoleColor.Cyan, Console.BackgroundColor);
        }

        public static void command_Items()
        {
            ColourEngine.writeLine("----------------------------------------", ConsoleColor.Cyan, Console.BackgroundColor);
            ColourEngine.writeLine("                 [ITEMS]                ", ConsoleColor.Cyan, Console.BackgroundColor);
            ColourEngine.writeLine("----------------------------------------", ConsoleColor.Cyan, Console.BackgroundColor);
            ColourEngine.writeLine("                                        ", ConsoleColor.Cyan, Console.BackgroundColor);
            string[] SpaceEngineersItems = ItemAPI.getItems();
            for (int Item = 0; Item < SpaceEngineersItems.Length; Item++)
            {
                ColourEngine.writeLine("  " + SpaceEngineersItems[Item].ToString(), ConsoleColor.Yellow, Console.BackgroundColor);
            }
            ColourEngine.writeLine("                                        ", ConsoleColor.Cyan, Console.BackgroundColor);
            ColourEngine.writeLine("----------------------------------------", ConsoleColor.Cyan, Console.BackgroundColor);
        }

        public static void command_listPlayers()
        {
            ColourEngine.writeLine("----------------------------------------", ConsoleColor.Cyan, Console.BackgroundColor);
            ColourEngine.writeLine("             [PLAYERS ONLINE]           ", ConsoleColor.Cyan, Console.BackgroundColor);
            ColourEngine.writeLine("----------------------------------------", ConsoleColor.Cyan, Console.BackgroundColor);
            ColourEngine.writeLine("                                        ", ConsoleColor.Cyan, Console.BackgroundColor);
            foreach(Player Player in PlayerAPI.getPlayers())
            {
                ColourEngine.writeLine("  " + Player.playerName + " Ping: " + Player.Ping.ToString() + " Bal: $" + BalanceAPI.getBalance(Player).ToString() + " IP: " + Player.IP + " UID: " + Player.UID.ToString(), ConsoleColor.Yellow, Console.BackgroundColor);
            }
            ColourEngine.writeLine("                                        ", ConsoleColor.Cyan, Console.BackgroundColor);
            ColourEngine.writeLine("----------------------------------------", ConsoleColor.Cyan, Console.BackgroundColor);
        }
    }
}
