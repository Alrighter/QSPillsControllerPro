using Microsoft.Win32.TaskScheduler;
using System;
using System.IO;

namespace QS_PillsController_Pro
{
    class TaskCreator
    {

        #region fields

        static int _iD;
        static private string _pillName;
        static private int _frequency;
        static string _startDate;
        static string _endDate;
        static private int _time1hr;
        static private int _time1min;
        static private int _time2hr;
        static private int _time2min;
        static private int _time3hr;
        static private int _time3min;
        #endregion

        private static string startDateTime
        {
            get => _startDate;
            set => _startDate = value;
        }

        public static string EndDateTime
        {
            get => _endDate;
            set => _endDate = value;
        }


        public TaskCreator(Pills pills)
        {
            _iD = pills.ID;
            _pillName = pills.PillName;
            _frequency = pills.Frequency;
            _startDate = pills.StartDateTime;
            _endDate = pills.EndDateTime;
            dynamic time1 = pills.TimePicker1.Split(':');
            _time1hr = Convert.ToInt32(time1[0]);
            _time1min = Convert.ToInt32(time1[1]);
            if (pills.TimePicker2 != null)
            {
                dynamic time2 = pills.TimePicker2.Split(':');
                _time2hr = Convert.ToInt32(time2[0]);
                _time2min = Convert.ToInt32(time2[1]);
            }
            if (pills.TimePicker3 != null)
            {
                dynamic time3 = pills.TimePicker2.Split(':');
                _time3hr = Convert.ToInt32(time3[0]);
                _time3min = Convert.ToInt32(time3[1]);
            }

        }

        public void TaskCreatorScript()
        {
            try
            {

                dynamic ed = _endDate.Split('.');
                var a = Convert.ToDateTime(_startDate);
                for (var i = 0; a.Day <= Int32.Parse(ed[0]); i++)
                {
                    DateTime myDate = ChangeTime(a.Year, a.Month, a.Day, _time1hr, _time1min);
                    using (TaskService ts = new TaskService())
                    {
                        var path = Directory.GetCurrentDirectory();
                        a = new DateTime(a.Year, a.Month, a.Day + 1);
                        TaskDefinition td = ts.NewTask();
                        td.RegistrationInfo.Description = $"{_pillName} trigger";
                        td.Actions.Add(new ExecAction(Settings.NotPath, _pillName, null));
                        td.Triggers.Add(new TimeTrigger(myDate));
                        ts.RootFolder.RegisterTaskDefinition($"{_pillName}{_iD}", td);
                    }
                    if (_frequency == 2)
                    {
                        try
                        {
                            myDate = ChangeTime(a.Year, a.Month, a.Day, _time2hr, _time2min);
                            using (TaskService ts = new TaskService())
                            {
                                TaskDefinition td = ts.NewTask();
                                td.RegistrationInfo.Description = $"{_pillName} trigger";
                                td.Triggers.Add(new TimeTrigger(myDate));
                                td.Actions.Add(new ExecAction(Settings.NotPath, _pillName, null));
                                ts.RootFolder.RegisterTaskDefinition($@"{_pillName} + {_iD}", td);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    if (_frequency == 3)
                    {
                        try
                        {
                            myDate = ChangeTime(a.Year, a.Month, a.Day, _time3hr, _time3min);
                            using (TaskService ts = new TaskService())
                            {
                                TaskDefinition td = ts.NewTask();
                                td.RegistrationInfo.Description = $"{_pillName} trigger";
                                td.Triggers.Add(new TimeTrigger(myDate));
                                td.Actions.Add(new ExecAction(Settings.NotPath, _pillName, null));
                                ts.RootFolder.RegisterTaskDefinition($@"{_pillName}{_iD}", td);

                            }
                        }
                        catch (Exception er)
                        {
                            throw er;
                        }
                    }
                }
            }
            catch (Exception er) { throw er; }
        }

        public static DateTime ChangeTime(int year, int month, int day, int hours, int minutes)
        {
            return new DateTime(
                year,
                month,
                day,
                hours,
                minutes,
                00,
                00);
        }

        public static void TaskRemover(string PillName, int ID)
        {
            try
            {
                using (TaskService ts = new TaskService()) ts.RootFolder.DeleteTask($"{PillName}{ID.ToString()}");
            }
            catch (Exception)
            {
            }

        }
    }
}
