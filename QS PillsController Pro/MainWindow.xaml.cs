using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ValidationResult = System.Windows.Controls.ValidationResult;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;

namespace QS_PillsController_Pro
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (_frequency ==  1)
            {
                PresetTimePicker1.IsEnabled = true;
                PresetTimePicker2.IsEnabled = false;
                PresetTimePicker3.IsEnabled = false;
            }
            else if (_frequency == 2)
            {
                PresetTimePicker1.IsEnabled = true;
                PresetTimePicker2.IsEnabled = true;
                PresetTimePicker3.IsEnabled = false;
            }
            else if (_frequency == 3)
            {
                PresetTimePicker1.IsEnabled = true;
                PresetTimePicker2.IsEnabled = true;
                PresetTimePicker3.IsEnabled = true;
            }
            
            base.OnPropertyChanged(e);
        }

        public MainWindow()
        { 
            InitializeComponent();
        }

        #region Fields

        private string _pillName;
        private int _frequency;
        private DateTime _startDateTime;
        private DateTime _endDateTime;
        private string _time1;
        private string _time2;
        private string _time3;

        #endregion


        #region Properties

        public string PillName
        {
            get { return _pillName;}
            set { _pillName = value; }
        }

        public int Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }

        public DateTime StartDateTime
        {
            get { return _startDateTime; }
            set { _startDateTime = value; }
        }

        public DateTime EndDateTime
        {
            get { return _endDateTime; }
            set { _endDateTime = value; }
        }

        public string Time1
        {
            get { return _time1; }
            set { _time1 = value; }
        }

        public string Time2
        {
            get { return _time2; }
            set { _time2 = value; }
        }

        public string Time3
        {
            get { return _time3; }
            set { _time3 = value; }
        }

        #endregion

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

            if (_pillName != null & _frequency != null & _startDateTime != null & _endDateTime != null & _time1 != null)
            {
                SQLiteConnection sqLite_connection = CreateConnection();
                CreateTable(sqLite_connection);
                InsertData(sqLite_connection, PillName, Convert.ToString(StartDateTime), Convert.ToString(EndDateTime), Frequency);
                MessageBox.Show(_time1);
            }
            else
            {
                MessageBox.Show("Введите корректные данные. " + _time1);
            }

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

        public void CreateTable(SQLiteConnection conn)
        {

            SQLiteCommand sqlcmd;
            string createTableCmd = "CREATE TABLE IF NOT EXISTS Information(ID INTEGER NOT NULL UNIQUE, NAME TEXT NOT NULL,START_DATE TEXT NOT NULL, END_DATE TEXT NOT NULL,FREQUENCY INTEGER NOT NULL, PRIMARY KEY(ID AUTOINCREMENT)); ";
            sqlcmd = conn.CreateCommand();

            sqlcmd.CommandText = createTableCmd;
            sqlcmd.ExecuteNonQuery();

        }

        public void InsertData(SQLiteConnection conn, string name, string startDate, string endDate, int frequency)
        {
            SQLiteCommand sqlcmd = new SQLiteCommand($"INSERT INTO Information (NAME, START_DATE, END_DATE, FREQUENCY) VALUES('{name}', '{startDate}', '{endDate}', {frequency});", conn);
            sqlcmd.ExecuteNonQuery();
        }

        #endregion

        #region HelpButtons

        private void NameTBox_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Введите название, которое будет отображаться в напоминании.");
        }

        private void FrequencyTBox_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Выберите как часто вы будете принимать таблетки за сутки.");

        }

        private void HistoryButton_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Window _window1;
            _window1 = new History();
            _window1.Show();
        }

        #endregion



    }

    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Field is required.")
                : ValidationResult.ValidResult;
        }
    }
}

