using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PMSClass
{
    class DBConnection
    {
        public static SqlConnection MyConnection(string IP)
        {
            return new SqlConnection(
                @"server=" +  IP   + ";database=sjfx;User ID=sa;pwd="
                );
        }
    }
}
