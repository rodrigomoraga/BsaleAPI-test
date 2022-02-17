using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BsaleAPI_test
{
    public class MySQLConfiguration
    {
        public MySQLConfiguration(string connectionString) => ConnectionString = connectionString;

        public string ConnectionString { get; set; }
    }
}
