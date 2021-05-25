using System;
using System.Linq;

namespace MIS
{
    public class DatabaseConfiguration
    {

        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public bool TrustedConnection { get; set; }

        public string ToConnectionString()
        {
            if(TrustedConnection)
            {
                return "SERVER=" + Server + ";" + "Database=" + Database +
                ";Pooling=true;Enlist=true;Max Pool Size=400;" +
                "MultipleActiveResultSets=True;Integrated Security=True";
            }
            else
            {
                return "SERVER=" + Server + ";" + "Database=" + Database +
                ";Pooling=true;Enlist=true;Max Pool Size=400;" +
                "MultipleActiveResultSets=True;" +
                "User ID=" + Username + ";Password=" + Password + ";";
            }
            
        }


    }
}
