using System;

namespace WindowsAppProject.Apps
{
    internal class dbconnection
    {
        private static readonly Lazy<dbconnection> instance = new Lazy<dbconnection>(() => new dbconnection());

        public static dbconnection Instance => instance.Value;

        public string ConnectionString { get; private set; }

        // Private constructor for Singleton
        private dbconnection()
        {
            try
            {
                // Hardcoded connection string
                ConnectionString = "Server=localhost,1433;Database=possdb;User Id=sa;Password=password123#";

                // You can add environment-based connection string selection here
                // E.g., Dev vs Production
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to initialize the database connection string.", ex);
            }
        }
    }
}

