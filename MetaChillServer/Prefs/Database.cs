using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaChillServer.Prefs
{
    public class Database
    {
        public string connectionString;

        public Database()
        {
            connectionString = "Data Source=127.0.0.1;Initial Catalog=MetaChill;Persist Security Info=False;User ID=sa;Password=Pa$$w0rd";
        }
    }
}
