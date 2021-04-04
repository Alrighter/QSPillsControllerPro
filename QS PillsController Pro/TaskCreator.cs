using System;
using System.Windows;
using Microsoft.Win32.TaskScheduler;

namespace QS_PillsController_Pro
{
    class TaskCreator
    {

        #region fields

        static int _iD;
        static private string _pillName;
        static private int _frequency;
        static DateTime _startDate;
        static DateTime _endDate;
        static private int _time1hr;
        static private int _time1min;
        static private int _time2hr;
        static private int _time2min;
        static private int _time3hr;
        static private int _time3min;
        #endregion

        
        public TaskCreator(Pills pills)
        {

            _iD = pills.ID;
            _pillName = pills.PillName;
            _frequency = pills.Frequency;
            _startDate = pills.StartDateTime;
            _endDate = pills.EndDateTime;
            char h1 = pills.TimePicker1[0];
            char h2 = pills.TimePicker1[1];
            _time1hr = Convert.ToInt32(h1) + Convert.ToInt32(h2);
            char m1 = pills.TimePicker1[3];
            char m2 = pills.TimePicker1[4];
            _time1min = Convert.ToInt32(m1) + Convert.ToInt32(m2);
            try
            {
                h1 = pills.TimePicker2[0];
                h2 = pills.TimePicker2[1];
                _time2hr = Convert.ToInt32(h1) + Convert.ToInt32(h2);
                m1 = pills.TimePicker2[3];
                m2 = pills.TimePicker2[4];
                _time2min = Convert.ToInt32(m1) + Convert.ToInt32(m2);
            }
            catch (Exception)
            {
                Console.WriteLine();
            }

            try
            {
                h1 = pills.TimePicker3[0];
                h2 = pills.TimePicker3[1];
                _time3hr = Convert.ToInt32(h1) + Convert.ToInt32(h2);
                m1 = pills.TimePicker3[3];
                m2 = pills.TimePicker3[4];
                _time3min = Convert.ToInt32(m1) + Convert.ToInt32(m2);
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
            
        }

        public void TaskCreatorScript()
        {
            for (DateTime a = _startDate; a.Day <= _endDate.Day; a.AddDays(1))
            {

                DateTime myDate = ChangeTime(a, _time1hr, _time1min);

                    using (TaskService ts = new TaskService())
                    {
                        // Create a new task definition and assign properties
                        TaskDefinition td = ts.NewTask();
                        td.RegistrationInfo.Description = $"{_pillName} trigger";

                        // Create a trigger that will fire the task at this time every other day
                        td.Triggers.Add(new TimeTrigger(myDate));

                        // Create an action that will launch Notepad whenever the trigger fires
                        td.Actions.Add(new ExecAction("./PCNotifier/PCNotifier.exe", _pillName, null));

                        // Register the task in the root folder
                        ts.RootFolder.RegisterTaskDefinition($"{_pillName} + {_iD}", td);

                        MessageBox.Show("successsss");

                }

                if (_frequency == 2)
                {
                    try
                    {

                        myDate = ChangeTime(a, _time2hr, _time2min);

                        using (TaskService ts = new TaskService())
                        {

                            // Create a new task definition and assign properties
                            TaskDefinition td = ts.NewTask();
                            td.RegistrationInfo.Description = $"{_pillName} trigger";

                            // Create a trigger that will fire the task at this time every other day
                            td.Triggers.Add(new TimeTrigger(myDate));

                            // Create an action that will launch Notepad whenever the trigger fires
                            td.Actions.Add(new ExecAction("./PCNotifier/PCNotifier.exe", _pillName, null));

                            // Register the task in the root folder
                            ts.RootFolder.RegisterTaskDefinition($@"{_pillName} + {_iD}", td);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                else if (_frequency == 3)
                {
                    try
                    {

                        myDate = ChangeTime(a, _time3hr, _time3min);

                        using (TaskService ts = new TaskService())
                        {

                            // Create a new task definition and assign properties
                            TaskDefinition td = ts.NewTask();
                            td.RegistrationInfo.Description = $"{_pillName} trigger";

                            // Create a trigger that will fire the task at this time every other day
                            td.Triggers.Add(new TimeTrigger(myDate));

                            // Create an action that will launch Notepad whenever the trigger fires
                            td.Actions.Add(new ExecAction("./PCNotifier/PCNotifier.exe", _pillName, null));

                            // Register the task in the root folder
                            ts.RootFolder.RegisterTaskDefinition($@"{_pillName} + {_iD}", td);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

            }
        }

        public static DateTime ChangeTime(DateTime dateTime, int hours, int minutes)
        {
            return new DateTime(
                dateTime.Year,
                dateTime.Month,
                dateTime.Day,
                hours,
                minutes,
                00,
                00,
                dateTime.Kind);
        }

        public static void TaskRemover(string PillName, int ID)
        {
            try
            {
                using (TaskService ts = new TaskService())
                {
                    // Remove the task we just created
                    ts.RootFolder.DeleteTask($"{PillName} + {ID.ToString()}");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }
    }
}
