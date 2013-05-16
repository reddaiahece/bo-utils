using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectsUtils.helper
{
    static class Waiter
    {
        public static bool Wait(int timems, ref Boolean cancel)
        {
            DateTime endtime = DateTime.Now.AddMilliseconds(timems);
            while(DateTime.Now<endtime){
                System.Threading.Thread.Sleep(25);
                if (cancel) return false;
            }
            return true;
        }
    }
}
