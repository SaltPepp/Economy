using EcoPlayer;
using SpaceEngineersEmulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    static class SEMod
    {
        static double version = 1.1;
        static bool isAlpha = true;
        static string _playerName = "";
        public static void BeginPrototype()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;
            if (isAlpha)
            {
                Console.Title = "Project EcoMod Prototype [Version " + version + ".A] - Prototype programmed by TangentSpy";
                Console.WriteLine("Project EcoMod Prototype [Version " + version + ".A]");
                Console.WriteLine("Warning! This release is ALPHA");
            }
            else
            {
                Console.Title = "Project EcoMod Prototype [Version " + version + ".RC] - Prototype programmed by TangentSpy";
                Console.WriteLine("Project EcoMod Prototype [Version " + version + ".RC]");
            }
        }
        public static string playerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                _playerName = value;
            }
        }

        public static void addBots(int Amount)
        {
            for (int BotPlayer = 0; BotPlayer < Amount; BotPlayer++)
            {
                Player Bot = new Player();
                Bot.playerName = "Bot #" + (BotPlayer + 1);
                Bot.UID = 13836692457 + BotPlayer;
                Bot.Ping = 1;
                Bot.IP = System.Net.IPAddress.Loopback.ToString();
                SpaceEngineers.onServerJoinHandler(Bot);
            }
        }

        public static void EndPrototype()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Thankyou for trying out our Project Eco prototype.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
