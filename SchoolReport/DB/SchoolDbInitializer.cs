﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using SchoolReport.DB.Entities;

namespace SchoolReport.DB
{
    public class SchoolDbInitializer : DropCreateDatabaseAlways<SchoolDbContext>
    {
        protected override void Seed(SchoolDbContext context)
        {
            //Add Schools
            var firstSchool = new School()
            {
                SchoolName = "First School"
            };

            context.Schools.Add(firstSchool);

            //Add Subjects
            List<Subject> subjects = new List<Subject>()
            {
                new Subject()
                {
                    SubjectName = "Language Arts"
                },
                new Subject()
                {
                    SubjectName = "Mathematics"
                },
                new Subject()
                {
                    SubjectName = "Music"
                },
                new Subject()
                {
                    SubjectName = "Geography"
                },
                new Subject()
                {
                    SubjectName = "Computer Science or Lab"
                },
                new Subject()
                {
                    SubjectName = "Physics"
                },
                new Subject()
                {
                    SubjectName = "Biology"
                },
            };

            context.Subjects.AddRange(subjects);

            //Add Students
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    School = firstSchool,
                    DayOfBirth = new DateTime(1999, 2, 13),
                    FirstName = "Lara",
                    LastName = "Steem",
                    HomeAdress = "QR. St Person st. House 9.",
                    Phone = "+1 789 567 4237",
                    SchoolYear = 3,
                    Subjects = new List<Subject>() {subjects[0], subjects[1], subjects[4]}
                },

                new Student()
                {
                    School = firstSchool,
                    DayOfBirth = new DateTime(1999, 2, 13),
                    FirstName = "Jini",
                    LastName = "Steem",
                    HomeAdress = "QR. St Person st. House 9.",
                    Phone = "+1 789 167 6276",
                    SchoolYear = 3,
                    Subjects = new List<Subject>() {subjects[2], subjects[4]}
                },

                new Student()
                {
                    School = firstSchool,
                    DayOfBirth = new DateTime(1997, 2, 13),
                    FirstName = "Mark",
                    LastName = "Green",
                    HomeAdress = "QR. Malony st. House 11.",
                    Phone = "+1 790 542 4132",
                    SchoolYear = 4,
                    Subjects = new List<Subject>() {subjects[5], subjects[0], subjects[2]}
                },

                new Student()
                {
                    School = firstSchool,
                    DayOfBirth = new DateTime(2001, 2, 13),
                    FirstName = "Jhon",
                    LastName = "Crow",
                    HomeAdress = "QR. Malony st. House 28.",
                    Phone = "+1 790 647 8473",
                    SchoolYear = 1,
                    Subjects = new List<Subject>() {subjects[3], subjects[4]}
                },

                new Student()
                {
                    School = firstSchool,
                    DayOfBirth = new DateTime(2001, 12, 13),
                    FirstName = "Sansa",
                    LastName = "Kein",
                    HomeAdress = "QR. Lagos st. House 47.",
                    Phone = "+1 790 647 8473",
                    SchoolYear = 1,
                    Subjects = new List<Subject>() {subjects[3], subjects[4]}
                },
            };

            context.Students.AddRange(students);
        }
    }
}