using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QS_PillsController_Pro
{
    public static class Settings
    {
        public static ApplicationContext DataContext = new ApplicationContext();
        
        public static void init()
        {
            SQLiteConnection sqLite_connection = db.CreateConnection();
            db.CreateTable(sqLite_connection);
            DataContext.Information.Load();
        }
        
        

    }
}
