using Sample.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fop.Tests
{
    public class DataInitializer
    {
        public static IQueryable<Student> GenerateStudentList()
        {
            var departments = new List<Department>
            {
                new()
                {
                    Id = 1,
                    Name = "Software Engineering"
                },
                new()
                {
                    Id = 2,
                    Name = "Architecture"
                },
                new()
                {
                    Id = 3,
                    Name = "Zoology"
                }
            };

            var studentList = new List<Student>();
            var identityNumber = 100000;
            var removeMonths = 0;
            for (var i = 0; i < 100; i++)
            {
                var departmentId = new Random().Next(1, 3);
                var student = new Student
                {
                    Name = Guid.NewGuid().ToString().Replace("-", string.Empty)[..8],
                    Surname = Guid.NewGuid().ToString().Replace("-", string.Empty)[..8],
                    Midterm = new Random().Next(0, 100),
                    Final = new Random().Next(0, 100),
                    Birthday = DateTime.Now.AddMonths(--removeMonths),
                    IdentityNumber = (++identityNumber).ToString(),
                    Level = Convert.ToChar(Guid.NewGuid().ToString().Replace("-", string.Empty)[..1]),
                    Department = departments.FirstOrDefault(x => x.Id == departmentId),
                    Bonus = Convert.ToDecimal(new Random().Next(0, 100)),
                };

                student.Average = student.Final + student.Midterm / 100;
                studentList.Add(student);
            }

            studentList.Add(new Student
            {
                Name = "Mohammad Sadeq",
                Surname = "Sirjani",
                Midterm = 100,
                Final = 90,
                Birthday = new DateTime(1995, 04, 06),
                IdentityNumber = (++identityNumber).ToString(),
                Level = 'a',
                DepartmentId = 1,
                Average = 55.6d,
                Bonus = 85.5m
            });

            return studentList.AsQueryable();
        }
    }
}
