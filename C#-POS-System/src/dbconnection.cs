using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WindowsAppProject.Apps
{
    internal class dbconnection
    {
        private static readonly Lazy<dbconnection> instance = new Lazy<dbconnection>(() => new dbconnection());
        public static dbconnection Instance => instance.Value;
        
        public string ConnectionString { get; private set; }
        private dbconnection()
        {
            ConnectionString = "Server=localhost,1433;Database=posdb;User Id=sa;Password=haruma123#;";
        }
    }

}
