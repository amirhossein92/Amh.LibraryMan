using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amh.LibraryMan.UI.Services
{
    public class DbService
    {
        public static string GetConnectionStatus()
        {
            var result = "No Connection...";

            using (var dbContext = new LibraryDbContext())
            {
                if (dbContext.Database.Exists())
                    result = "Connection Alive";
            }

            return result;
        }
    }
}
