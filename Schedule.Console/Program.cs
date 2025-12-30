using System;
using System.Collections.Generic;
using Schedule.Core;

namespace Schedule.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1️⃣ Demo requests (hardcoded)
            var requests = new List<Request>
            {
                new Request
                {
                    Day = DayOfWeek.Monday,
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(11, 30, 0),
                    GroupName = "Group A",
                    GroupPriority = 2,
                    TeacherName = "Ivanov"
                },
                new Request
                {
                    Day = DayOfWeek.Monday,
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(11, 30, 0),
                    GroupName = "Group B",
                    GroupPriority = 1,
                    TeacherName = "Petrov"
                },
                new Request
                {
                    Day = DayOfWeek.Monday,
                    StartTime = new TimeSpan(12, 0, 0),
                    EndTime = new TimeSpan(13, 30, 0),
                    GroupName = "Group C",
                    GroupPriority = 3,
                    TeacherName = "Sidorov"
                }
            };

            // 2️⃣ Scheduler (N computers)
            var scheduler = new Scheduler(computersCount: 1);

            var result = scheduler.BuildSchedule(requests);

            // 3️⃣ Output result
            System.Console.WriteLine("=== ACCEPTED REQUESTS ===");
            foreach (var r in result.Accepted)
            {
                PrintRequest(r);
            }

            System.Console.WriteLine();
            System.Console.WriteLine("=== REJECTED REQUESTS ===");
            foreach (var r in result.Rejected)
            {
                PrintRequest(r);
            }

            System.Console.WriteLine();
            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }

        static void PrintRequest(Request r)
        {
            System.Console.WriteLine(
                $"{r.Day} | {r.StartTime:hh\\:mm}-{r.EndTime:hh\\:mm} | " +
                $"{r.GroupName} | Priority {r.GroupPriority} | {r.TeacherName}");
        }
    }
} 