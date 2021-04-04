using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SQLite;
using System.Windows;

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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (itemsList.SelectedItem == null) return;
            Pills item = itemsList.SelectedItem as Pills;
            datactx.Information.Remove(item);
            datactx.SaveChanges();
            TaskCreator.TaskRemover(item.PillName, item.ID);
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
