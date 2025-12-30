using System.Collections.Generic;

namespace Schedule.Core
{
    public class ScheduleResult
    {
        public List<Request> Accepted { get; } = new();
        public List<Request> Rejected { get; } = new();
    }
}