using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Prototype;
using SpaceEngineersEmulation;
using EcoPlayer;
using EconSellableItem;

namespace EconAPI
{

    /**
     * PROJECT ECON
     * Licence: To be licenced.
     *
     * This file is apart of the Project Econ Space Engineers mod.
     *
     * Marking Guide:
     * [f] = Completed foundation programming
     * [c] = Completed
     * [b] = Completed but buggy
     * [!] = Important feature
     *
     * APIs
     * - PermissionAPI
     *   -- Commands
     *      - hasPermission(Player, Permission) [f], hasPermission(UID, Permission) [f]
     *      - givePermission(Player, Permission) [f], givePermission(UID, Permission) [f]
     * - PlayerAPI
     *  -- Commands
     *      - createPlayer() [f] [!]
     *      - getPlayer() self [f] [!], getPlayer(Player) [f], getPlayer(UID) [f]
     *      - getUID() self, getUID(Player)
     *      - kickPlayer(Player)
     *      - banPlayer(Player)
     *      - resetPlayer(Player)
     *      - teleportPlayer(Player), teleportPlayer(Player, Player)
     *      - sendMessage(Player, Message)
     *      - payPlayer(Player)
     * - BalanceAPI
     *  -- Commands
     *      - getBalance() self [f] [!], getBalance(Player) [f], getBalance(UID) [f]
     *      - setBalance() self, setBalance(Player), setBalance(UID)
     *      - deductBalance()
     *      - resetBalance() self, resetBalance(Player)
     * - SellingAPI
     *  -- Commands
     *      - getPrice(ItemName) [f] [!]
     *      - buyItem(ItemName) [f] [!]
     *      - sellHand(ItemName) [f] [!], sellHand(ItemName, SellAll) [f] [!]
     * - ItemAPI
     *  -- Commands
     *      - getItem(ItemName) [f] [!]
     * - InventoryAPI
     *  -- Commands
     *      - addItem(ItemName) [!]
     *      - removeItem(ItemName) [!]
     * - ConfigAPI
     *  -- Commands
     *      - createConfig(Path, ConfigName) [f] [!]
     *      - getConfig(ConfigName), getConfig(Path, ConfigName) [!]
     *      - truncateConfig(ConfigName), truncateConfig(Path, ConfigName) [!]
     *      - addLine(ConfigName), addLine(Path, ConfigName) [!]
     * - ServerAPI
     *  -- Commands
     *      - broadcast(Message)
     *      - help() [!], help(Command)
     **/

    class PermissionAPI
    {
        // hasPermission(Player, Permission)
        /// <summary>
        /// This function checks to see if the specified Player has the specified Permission
        /// </summary>
        /// <param name="Player">EcoMod Player</param>
        /// <param name="Permission">EcoMod Permission</param>
        /// <returns>True, if the player has permission</returns>
        public static bool hasPermission(Player EcoPlayer, string Permission){return true;}

        // hasPermission(UID)
        /// <summary>
        /// This function checks to see if the specified player UID has the specified Permission
        /// </summary>
        /// <param name="UID">EcoMod UID</param>
        /// <param name="Permission">EcoMod Permission</param>
        /// <returns>True, if the player UID has permission</returns>
        internal static bool hasPermission(int UID, string Permission) {return true;}

        // givePermission(Player, Permission)
        /// <summary>
        /// This function gives the specified Permission to the specified Player.
        /// </summary>
        /// <param name="Player">EcoMod Player</param>
        /// <param name="Permission">EcoMod Permission</param>
        public static void givePermission(Player EcoPlayer, string Pemission){}

        // givePermission(UID, Permission)
        /// <summary>
        /// This function gives the specified Permission to the specified player UID
        /// </summary>
        /// <param name="UID">EcoMod UID</param>
        /// <param name="Permission">EcoMod Permission</param>
        internal static void givePermission(int UID, string Permission){}
    }

    class PlayerAPI
    {
        // createPlayer(Player)
        /// <summary>
        /// This function creates a new player profile.
        /// </summary>
        /// <param name="Player">EcoMod Player</param>
        public static void createPlayer(Player EcoPlayer) {
            ServerAPI.playerList.Add(EcoPlayer);
            // Write player profile to hdd
        }

        public static List<Player> getPlayers(){ return ServerAPI.playerList; }

        // getPlayer()
        /// <summary>
        /// This function gets the profile of the current player. (Self)
        /// </summary>
        /// <returns>EcoMod Player Profile (Self)</returns>
        public static Player getPlayer()
        {
            foreach (Player Player in ServerAPI.playerList)
            {
                if (Player.playerName == SEMod.playerName){ return Player; }
            }
            return null;
        }

        // getPlayer(Player)
        /// <summary>
        /// This function gets the profile of another player on the server by name.
        /// </summary>
        /// <param name="Player">EcoMod Player</param>
        /// <returns>EcoMod Player Profile</returns>
        internal static Player getPlayer(string EcoPlayer) {
            foreach (Player Player in ServerAPI.playerList)
            {
                if (Player.playerName == EcoPlayer){ return Player; }
            }
            return null;
        }

        // getPlayer(UID)
        /// <summary>
        /// This function gets the profile of another player on the server by UID.
        /// </summary>
        /// <param name="UID">EcoMod UID</param>
        /// <returns>EcoMod Player Profile</returns>
        internal static Player getPlayer(int UID)
        {
            foreach (Player Player in ServerAPI.playerList)
            {
                if (Player.UID == UID) { return Player; }
            }
            return null;
        }
    }

    class BalanceAPI
    {
        // getBalance()
        /// <summary>
        /// This function gets the balance for the current Player (Self).
        /// </summary>
        /// <returns>Balance of the current Player (Self)</returns>
        public static decimal getBalance()
        {
            Player EcoPlayer = PlayerAPI.getPlayer(SEMod.playerName);
            return Convert.ToDecimal(EcoPlayer.Balance);
        }

        // getBalance(Player)
        /// <summary>
        /// This function gets the balance for the specified Player.
        /// </summary>
        /// <param name="Player">EcoMod Player</param>
        /// <returns>Balance of the Player</returns>
        internal static decimal getBalance(string Player)
        {
            Player EcoPlayer = PlayerAPI.getPlayer(SEMod.playerName);
            return Convert.ToDecimal(EcoPlayer.Balance);
        }

        // getBalance(Player)
        /// <summary>
        /// This function gets the balance for the specified Player.
        /// </summary>
        /// <param name="Player">EcoMod Player</param>
        /// <returns>Balance of the Player</returns>
        internal static decimal getBalance(Player Player)
        {
            return Convert.ToDecimal(Player.Balance);
        }

        // getBalance(UID)
        /// <summary>
        /// This function gets the balance for the specified Player.
        /// </summary>
        /// <param name="UID">EcoMod UID</param>
        /// <returns>Balance of the Player</returns>
        internal static decimal getBalance(int UID)
        {
            Player EcoPlayer = PlayerAPI.getPlayer(UID);
            return Convert.ToDecimal(EcoPlayer.Balance);
        }

        // resetBalance(Player)
        /// <summary>
        /// This function resets a player balance back to default.
        /// </summary>
        /// <param name="Player">EcoMod Player</param>
        public static void resetBalance(string Player)
        {
            foreach (Player GamePlayer in ServerAPI.playerList)
            {
                if (GamePlayer.playerName == Player)
                {
                    GamePlayer.Balance = 250m;
                }
            }
        }

        // resetBalance(Player)
        /// <summary>
        /// This function resets a player balance back to default.
        /// </summary>
        /// <param name="Player">EcoMod Player</param>
        public static void resetBalance(Player Player)
        {
            Player.Balance = 250m;
        }

        // resetBalance(UID)
        /// <summary>
        /// This function resets a player balance back to default.
        /// </summary>
        /// <param name="Player">EcoMod Player</param>
        public static void resetBalance(int UID)
        {
            foreach (Player GamePlayer in ServerAPI.playerList)
            {
                if (GamePlayer.UID == UID)
                {
                    GamePlayer.Balance = 250m;
                }
            }
        }
    }
    
    class SellingAPI
    {
        public static List<SellableItem> sellableItems = new List<SellableItem>();
        // getPrice(ItemName)
        /// <summary>
        /// This function gets the price for the specified item.
        /// </summary>
        /// <param name="ItemName">EcoMod ItemName</param>
        /// <returns>Item Price</returns>
        public static decimal getPrice(string ItemName)
        {
            foreach (SellableItem Item in SellingAPI.sellableItems)
            {
                if (Item.Name == ItemName){ return Item.Price; }
            }
            return 0.00m;
        }

        // buyItem(ItemName)
        /// <summary>
        /// This function purchases the specified Item.
        /// </summary>
        /// <param name="ItemName">EcoMod ItemName</param>
        public static void buyItem(string ItemName)
        {
            foreach (SellableItem Item in SellingAPI.sellableItems)
            {
                if (Item.Name == ItemName)
                {
                    Player EcoPlayer = PlayerAPI.getPlayer(SEMod.playerName);
                    if (EcoPlayer.Balance >= Item.Price)
                    {
                        EcoPlayer.Balance = EcoPlayer.Balance - Item.Price;
                        //EcoPlayer.Inventory.Add(GameItem Item);
                    }
                }
            }
        }

        // buyItem(ItemName, Amount)
        /// <summary>
        /// This function purchases the specified Item.
        /// </summary>
        /// <param name="ItemName">EcoMod ItemName</param>
        public static void buyItem(string ItemName, int Amount)
        {
            foreach (SellableItem Item in sellableItems)
            {
                if (Item.Name == ItemName)
                {
                    Player EcoPlayer = PlayerAPI.getPlayer(SEMod.playerName);
                    if (EcoPlayer.Balance >= (Amount * Item.Price))
                    {
                        EcoPlayer.Balance = EcoPlayer.Balance - (Amount * Item.Price);
                        //EcoPlayer.Inventory.Add(GameItem Item, int Amount);
                    }
                }
            }
        }

        // sellHand(ItemName)
        /// <summary>
        /// This function sells one of the specified Item.
        /// </summary>
        /// <param name="ItemName">EcoMod ItemName</param>
        public static void sellHand(string ItemName){}

        // sellHand(ItemName, SellAll)
        /// <summary>
        /// This function sells all of the specified Item.
        /// </summary>
        /// <param name="ItemName">EcoMod ItemName</param>
        public static void sellHand(string ItemName, bool SellAll){}
    }

    class ItemAPI
    {
        // getItems()
        /// <summary>
        /// This function gets the list of Space Engineers game items.
        /// </summary>
        /// <returns>Space Engineers Items Array.</returns>
        public static string[] getItems(){return SpaceEngineers.getItems();}
    }

    class InventoryAPI{}

    class ConfigAPI
    {
        // createConfig(Path, ConfigName)
        /// <summary>
        /// This function creates a new config file.
        /// </summary>
        /// <param name="Path">Config file directory.</param>
        /// <param name="ConfigName">Config file name.</param>
        public static void createConfig(string Path, string ConfigName)
        {
            File.Create(Path+@"\"+ConfigName);
        }

        // loadProfile(joinedPlayer
        /// <summary>
        /// This function loads a player profile.
        /// </summary>
        /// <param name="joinedPlayer"></param>
        /// <returns></returns>
        internal static bool loadProfile(Player joinedPlayer)
        {
            return false;
        }
    }

    class ServerAPI{
        public static List<Player> playerList = new List<Player>();
    }
}
