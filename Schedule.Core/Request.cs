using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule.Core
{
    public class Request
    {
        public DayOfWeek Day { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public string GroupName { get; set; }

        public int GroupPriority { get; set; }

        public string TeacherName { get; set; }
    }
}
