using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QS_PillsController_Pro
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefCon")
        {

        }
        public DbSet<Pills> Information { get; set; }
    }
}
