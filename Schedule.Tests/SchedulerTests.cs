using NUnit.Framework;
using Schedule.Core;
using System;
using System.Collections.Generic;

namespace Schedule.Tests
{
    public class SchedulerTests
    {
        [Test]
        public void HigherPriorityRequest_ShouldWinConflict()
        {
            var requests = new List<Request>
            {
                new Request
                {
                    Day = DayOfWeek.Monday,
                    StartTime = new TimeSpan(10,0,0),
                    EndTime = new TimeSpan(11,30,0),
                    GroupName = "Group A",
                    GroupPriority = 2,
                    TeacherName = "Ivanov"
                },
                new Request
                {
                    Day = DayOfWeek.Monday,
                    StartTime = new TimeSpan(10,0,0),
                    EndTime = new TimeSpan(11,30,0),
                    GroupName = "Group B",
                    GroupPriority = 1, // higher priority
                    TeacherName = "Petrov"
                }
            };

            var scheduler = new Scheduler(computersCount: 1);

            var result = scheduler.BuildSchedule(requests);

            Assert.AreEqual(1, result.Accepted.Count);
            Assert.AreEqual("Group B", result.Accepted[0].GroupName);
            Assert.AreEqual(1, result.Rejected.Count);
        }
        [Test]
        public void EqualPriority_FirstRequestShouldRemainAccepted()
        {
            var requests = new List<Request>
    {
        new Request
        {
            Day = DayOfWeek.Tuesday,
            StartTime = new TimeSpan(10,0,0),
            EndTime = new TimeSpan(11,30,0),
            GroupName = "Group A",
            GroupPriority = 1,
            TeacherName = "Ivanov"
        },
        new Request
        {
            Day = DayOfWeek.Tuesday,
            StartTime = new TimeSpan(10,0,0),
            EndTime = new TimeSpan(11,30,0),
            GroupName = "Group B",
            GroupPriority = 1,
            TeacherName = "Petrov"
        }
    };

            var scheduler = new Scheduler(1);
            var result = scheduler.BuildSchedule(requests);

            Assert.AreEqual(1, result.Accepted.Count);
            Assert.AreEqual("Group A", result.Accepted[0].GroupName);
        }
        [Test]
        public void BoundaryTime_MorningSlot_ShouldBeAccepted()
        {
            var request = new Request
            {
                Day = DayOfWeek.Wednesday,
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(9, 30, 0),
                GroupName = "Group A",
                GroupPriority = 1,
                TeacherName = "Ivanov"
            };

            var validator = new RequestValidator();
            Assert.IsTrue(validator.IsValid(request));
        }
        [Test]
        public void InvalidBoundaryTime_ShouldBeRejected()
        {
            var request = new Request
            {
                Day = DayOfWeek.Thursday,
                StartTime = new TimeSpan(16, 45, 0),
                EndTime = new TimeSpan(18, 0, 0),
                GroupName = "Group A",
                GroupPriority = 1,
                TeacherName = "Ivanov"
            };

            var validator = new RequestValidator();
            Assert.IsFalse(validator.IsValid(request));
        }
    }
}