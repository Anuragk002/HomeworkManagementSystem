using System;
using System.Collections.Generic;
using System.Text;

namespace HWMS.DAL
{
    static class ConnectionStr
    {
        static string constr = "Server=INW-R-033; Database=HWMS; Trusted_Connection=True;";
        public static string cName { get => constr; }
    }
}
