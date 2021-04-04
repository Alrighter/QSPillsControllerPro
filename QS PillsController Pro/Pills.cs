using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace QS_PillsController_Pro
{
    public class Pills : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #region fields

        private int _iD;
        private string _pillName;
        private int _frequency;
        private DateTime _startDateTime;
        private DateTime _endDateTime;
        private string _timePicker1;
        private string _timePicker2;
        private string _timePicker3;

        #endregion

        #region properties

        public int ID
        {
            get { return _iD; }
            set { _iD = value; OnPropertyChanged("ID");}
        }

        public string PillName
        {
            get { return _pillName; }
            set { _pillName = value; OnPropertyChanged("PillName"); }
        }

        public int Frequency
        {
            get { return _frequency; }
            set { _frequency = value; OnPropertyChanged("Frequency"); }
        }

        public DateTime StartDateTime
        {
            get { return _startDateTime; }
            set { _startDateTime = value; OnPropertyChanged("StartDateTime"); }
        }

        public DateTime EndDateTime
        {
            get { return _endDateTime; }
            set { _endDateTime = value; OnPropertyChanged("EndDateTime"); }
        }

        public string TimePicker1
        {
            get { return _timePicker1; }
            set { _timePicker1 = value; OnPropertyChanged("TimePicker1");}
        }

        public string TimePicker2
        {
            get { return _timePicker2; }
            set { _timePicker2 = value; OnPropertyChanged("TimePicker2"); }
        }
        public string TimePicker3
        {
            get { return _timePicker3; }
            set { _timePicker3 = value; OnPropertyChanged("TimePicker3"); }
        }

        #endregion

        public Pills()
        {

        }

        public Pills(string PillName, int Frequency, DateTime startDateTime, DateTime endDateTime, string Time1, string Time2, string Time3)
        {
            this.PillName = PillName;
            this.Frequency = Frequency;
            this.StartDateTime = startDateTime;
            this.EndDateTime = endDateTime;
            this.TimePicker1 = Time1;
            try
            {
                this.TimePicker2 = Time2;
            }
            catch (Exception)
            {
                TimePicker2 = "";
            }

            try
            {
                this.TimePicker3 = Time3;
            }
            catch (Exception)
            {
                TimePicker3 = "";
            }
            
        }

        public ApplicationContext db = new ApplicationContext();



    }
}
