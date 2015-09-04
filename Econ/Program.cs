using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype;
using SpaceEngineersEmulation;
using EconAPI;
using EcoPlayer;
using EcoVector3;

namespace Econ
{
    class Program
    {
        
        static void Main(string[] args)
        {
            SEMod.BeginPrototype();
            Console.Write("Enter a test player name: ");
            SEMod.playerName = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            Player JoinedPlayer = new Player();
            JoinedPlayer.playerName = SEMod.playerName;
            JoinedPlayer.UID = 13836692456;
            JoinedPlayer.IP = System.Net.IPAddress.Loopback.ToString();
            Vector3 Location = new Vector3();
            Location.x = 0;
            Location.y = 100;
            Location.z = 432;
            JoinedPlayer.Location.Add(Location);
            JoinedPlayer.Balance = 500;
            JoinedPlayer.Ping = 41;
            SEMod.addBots(18);
            SpaceEngineers.onServerJoinHandler(JoinedPlayer);
            SpaceEngineers.CommandHandler(true);
            SEMod.EndPrototype();
        }
    }

    
}
