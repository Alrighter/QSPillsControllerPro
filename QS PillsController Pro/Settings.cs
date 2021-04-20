using System;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;

namespace QS_PillsController_Pro
{
    public static class Settings
    {
        public static ApplicationContext DataContext = new ApplicationContext();
        public static string NotPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "/PCNotifier/PCNotifier.exe";


        public static void init()
        {
            SQLiteConnection sqLite_connection = db.CreateConnection();
            db.CreateTable(sqLite_connection);
            DataContext.Information.Load();
        }

    }
}
