using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.Students = new List<Student>();
        }

        public string RegisterStudent(Student student)
        {
            StringBuilder registrationResult = new StringBuilder();

            if (this.Capacity > this.students.Count)
            {
                this.students.Add(student);
                registrationResult.AppendLine($"Added student {student.FirstName} {student.LastName}");
            }

            else
            {
                registrationResult.AppendLine("No seats in the classroom");
            }

            return registrationResult.ToString().Trim();
        }

        public string DismissStudent(string firstName, string lastName)
        {
            StringBuilder dismissingResult = new StringBuilder();

            if (students.Exists(s => s.FirstName == firstName && s.LastName == lastName))
            {
                Student currentStudent = students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
                students.Remove(currentStudent);
                dismissingResult.AppendLine($"Dismissed student {firstName} {lastName}");
            }

            else
            {
                dismissingResult.AppendLine("Student not found");
            }

            return dismissingResult.ToString().Trim();
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder subjectInfo = new StringBuilder();

            if (students.Exists(s => s.Subject == subject))
            {
                subjectInfo.AppendLine($"Subject: {subject}");
                subjectInfo.AppendLine("Students:");

                foreach (var current in students)
                {
                    if (current.Subject == subject)
                    {
                        subjectInfo.AppendLine($"{current.FirstName} {current.LastName}");
                    }
                }
            }

            else
            {
                subjectInfo.AppendLine("No students enrolled for the subject");
            }

            return subjectInfo.ToString().Trim();
        }

        public int GetStudentsCount()
        {
            return this.students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return this.students.Find(s => s.FirstName == firstName && s.LastName == lastName);
        }

        public List<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public int Capacity { get; set; }
        public int Count { get { return this.students.Count; } }
    }
}
