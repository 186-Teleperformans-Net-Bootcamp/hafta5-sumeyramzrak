using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleperformance.Odev4.Common
{
    public class Settings
    {
        public DatabaseConfiguration Database { get; set; }

        public class DatabaseConfiguration
        {
            public string ConnectionString { get; set; }
        }
    }
}
