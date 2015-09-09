using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoInventory;
using EcoVector3;

namespace EcoPlayer
{
    class Player
    {
        public string playerName;
        public long UID;
        public string IP;
        public List<Inventory> Inventory = new List<Inventory>(1);
        public List<Vector3> Location = new List<Vector3>(1);
        public decimal Balance = 250m;
        public double Ping = 0;
    }
}