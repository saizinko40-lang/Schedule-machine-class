using NUnit.Framework;
using Schedule.Core;
using System;

namespace Schedule.Tests
{
    public class RequestValidatorTests
    {
        [Test]
        public void ValidRequest_ShouldBeValid()
        {
            var request = new Request
            {
                Day = DayOfWeek.Monday,
                StartTime = new TimeSpan(10, 0, 0),
                EndTime = new TimeSpan(11, 30, 0),
                GroupName = "Group A",
                GroupPriority = 1,
                TeacherName = "Ivanov"
            };

            var validator = new RequestValidator();

            var result = validator.IsValid(request);

            Assert.IsTrue(result);
        }
            [Test]
            public void InvalidDuration_ShouldBeInvalid()
            {
                var request = new Request
                {
                    Day = DayOfWeek.Monday,
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(11, 0, 0), // 60 minutes ❌
                    GroupName = "Group A",
                    GroupPriority = 1,
                    TeacherName = "Ivanov"
                };

                var validator = new RequestValidator();

                var result = validator.IsValid(request);

                Assert.IsFalse(result);
            }
    }
}