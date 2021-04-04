using System;
using System.Data.SQLite;
using System.Windows;

namespace QS_PillsController_Pro
{
    public static class db
    {
        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlconn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            try
            {
                sqlconn.Open();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error: " + Ex.Message);
            }
            return sqlconn;
        }

        public static void CreateTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlcmd;
            string createTableCmd = @"CREATE TABLE IF NOT EXISTS Pills(ID INTEGER NOT NULL UNIQUE, PillName TEXT NOT NULL,
                                    StartDateTime TEXT NOT NULL, EndDateTime TEXT NOT NULL,Frequency INTEGER NOT NULL, TimePicker1 TEXT NOT NULL, 
                                    TimePicker2 TEXT, TimePicker3 TEXT, PRIMARY KEY(ID AUTOINCREMENT)); ";
            sqlcmd = conn.CreateCommand();

            sqlcmd.CommandText = createTableCmd;
            sqlcmd.ExecuteNonQuery();

        }

        public static void InsertData(SQLiteConnection conn, string name, string startDate, string endDate, int frequency, string Time1, string Time2, string Time3)
        {
            SQLiteCommand sqlcmd = new SQLiteCommand($"INSERT INTO Information (NAME, START_DATE, END_DATE, FREQUENCY) VALUES('{name}', '{Convert.ToDateTime(startDate).ToString("d")}', '{Convert.ToDateTime(endDate).ToString("d")}', {frequency}, '{Time1}', '{Time2}', '{Time3}');", conn);
            sqlcmd.ExecuteNonQuery();
        }

    }
}
