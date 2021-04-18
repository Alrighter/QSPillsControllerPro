using System;
using System.Data.Entity;
using System.Data.SQLite;

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
