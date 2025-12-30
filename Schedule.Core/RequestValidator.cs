using System;

namespace Schedule.Core
{
    public class RequestValidator
    {
        public bool IsValid(Request request)
        {
            if (request == null)
                return false;

            if (string.IsNullOrWhiteSpace(request.GroupName))
                return false;

            if (string.IsNullOrWhiteSpace(request.TeacherName))
                return false;

            var start = request.StartTime;
            var end = request.EndTime;

            if (start < new TimeSpan(8, 0, 0))
                return false;

            if (end > new TimeSpan(18, 0, 0))
                return false;

            if (end <= start)
                return false;

            var duration = end - start;

            if (duration.TotalMinutes % 90 != 0)
                return false;

            return true;
        }
    }
} 