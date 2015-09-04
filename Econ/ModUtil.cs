using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModUtil
{
    class Utility
    {
        public static bool empty(object Obj)
        {
            bool isEmpty = true;
            if (Obj == null)
            {
                isEmpty = true;
            }
            if (Obj.ToString() == "" | Obj.ToString() == " ")
            {
                isEmpty = true;
            }
            if (Obj.ToString().Length == 0)
            {
                isEmpty = true;
            }
            if(Obj.ToString() == "true" | Obj.ToString() == "false")
            {
                isEmpty = false;
            }
            if (isEmpty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
