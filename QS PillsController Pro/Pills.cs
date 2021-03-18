using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QS_PillsController_Pro
{
    public class Pills
    {
        #region fields

        private int _iD;
        private string _pillName;
        private int _frequency;
        private DateTime _startDateTime;
        private DateTime _endDateTime;

        #endregion

        #region properties

        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        public string PillName
        {
            get { return _pillName; }
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
        #endregion

        public ApplicationContext db = new ApplicationContext();

    }
}
