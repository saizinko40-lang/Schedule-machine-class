using System;
using System.Collections.Generic;
using System.Linq;

namespace Schedule.Core
{
    public class Scheduler
    {
        private readonly int _computersCount;

        public Scheduler(int computersCount)
        {
            _computersCount = computersCount;
        }

        public ScheduleResult BuildSchedule(IEnumerable<Request> requests)
        {
            var result = new ScheduleResult();

            // 1️⃣ Group by Day
            var byDay = requests.GroupBy(r => r.Day);

            foreach (var dayGroup in byDay)
            {
                // 2️⃣ Sort by start time
                var sorted = dayGroup
                    .OrderBy(r => r.StartTime)
                    .ToList();

                foreach (var request in sorted)
                {
                    // 3️⃣ Find overlapping accepted requests
                    var overlapping = result.Accepted
                        .Where(r =>
                            r.Day == request.Day &&
                            IsOverlapping(r, request))
                        .ToList();

                    // 4️⃣ If free computers exist → accept
                    if (overlapping.Count < _computersCount)
                    {
                        result.Accepted.Add(request);
                    }
                    else
                    {
                        // 5️⃣ Conflict: resolve by priority
                        var lowestPriority = overlapping
                            .OrderByDescending(r => r.GroupPriority)
                            .First();

                        if (request.GroupPriority < lowestPriority.GroupPriority)
                        {
                            // replace lower-priority request
                            result.Accepted.Remove(lowestPriority);
                            result.Rejected.Add(lowestPriority);
                            result.Accepted.Add(request);
                        }
                        else
                        {
                            result.Rejected.Add(request);
                        }
                    }
                }
            }

            return result;
        }

        private bool IsOverlapping(Request a, Request b)
        {
            return a.StartTime < b.EndTime && b.StartTime < a.EndTime;
        }
    }
}