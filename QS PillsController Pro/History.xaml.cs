using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QS_PillsController_Pro
{
    /// <summary>
    /// Логика взаимодействия для History.xaml
    /// </summary>
    public partial class History : Window
    {
        private BindingList<Pills> context;
        private ApplicationContext datactx;
        public History()
        {
            InitializeComponent();
            datactx = Settings.DataContext;
            context = datactx.Information.Local.ToBindingList();
            DataContext = this.context;
        }

        



        #region SQLite

        public SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlconn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            try
            {
                sqlconn.Open();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Convert.ToString(Ex));
            }
            return sqlconn;
        }
        

        public void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Information";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            conn.Close();
        }

        #endregion


    }
}
