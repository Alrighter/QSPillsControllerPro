using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SQLite;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ValidationResult = System.Windows.Controls.ValidationResult;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.IO;

namespace QS_PillsController_Pro
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") 
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public MainWindow()
        {
            InitializeComponent();
            Settings.init();
            DataContext = this;
        }

        #region Fields

        private string _pillName;
        private int _frequency;
        private string _startDateTime;
        private string _endDateTime = DateTime.Now.ToString();
        private string _time1;
        private string _time2;
        private string _time3;

        #endregion

        private bool FrCheck(int a) => Frequency >= a;

        #region Properties

        public dynamic isEnabled1
        {
            get => _isEnabled1;
            set { _isEnabled1 = value; OnPropertyChanged("isEnabled1");}
    }

        public dynamic isEnabled2
        {
            get => _isEnabled2;
            set { _isEnabled2 = value; OnPropertyChanged("isEnabled2"); }
        }

        public dynamic isEnabled3
        {
            get => _isEnabled3;
            set { _isEnabled3 = value; OnPropertyChanged("isEnabled3"); }
        }
        private dynamic _isEnabled1, _isEnabled2, _isEnabled3;

        public string PillName
        {
            get { return _pillName;}
            set { _pillName = value; }
        }

        public int Frequency
        {
            get { return _frequency; }
            set { _frequency = value; OnPropertyChanged("Frequency");
                isEnabled1 = FrCheck(1);
                isEnabled2 = FrCheck(2);
                isEnabled3 = FrCheck(3);
            }
        }

        public string StartDateTime
        {
            get => _startDateTime;
            set { _startDateTime = value; 
                OnPropertyChanged("StartDateTime");}
        }

        public string EndDateTime
        {
            get => _endDateTime;
            set { _endDateTime = value; OnPropertyChanged("EndDateTime"); }
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
            MessageBox.Show(_startDateTime);
            
            if (_pillName != null & _time1 != null)
            {
                var Pill = new Pills(PillName, Frequency, StartDateTime, EndDateTime, Time1, Time2, Time3);
                SQLiteConnection sqLite_connection = db.CreateConnection();
                db.CreateTable(sqLite_connection);
                Settings.DataContext.Information.Add(Pill);
                Settings.DataContext.SaveChanges();
                TaskCreator rc = new TaskCreator(Settings.DataContext.Information.Find(Pill.ID));
                rc.TaskCreatorScript();
            }
            else
            {
                MessageBox.Show("Введите корректные данные. ");
            }

        }

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


        private void EndDatePicker_OnSourceUpdated(object sender, DataTransferEventArgs e)
        {
            EndDateTime = StartDateTime;
        }
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

