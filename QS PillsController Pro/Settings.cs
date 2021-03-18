using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QS_PillsController_Pro
{
    public static class Settings
    {
        public static ApplicationContext db = new ApplicationContext();
        
        public static void init()
        {
            db.Pills.Load();
        }
        


    }
}
