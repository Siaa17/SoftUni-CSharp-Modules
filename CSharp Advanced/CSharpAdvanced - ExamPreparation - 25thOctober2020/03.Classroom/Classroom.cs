using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private readonly List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; private set; }

        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.Capacity > this.Count)
            {
                students.Add(student);

                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            bool isRemoved = students.Remove(students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName));

            if (isRemoved)
            {               
                return $"Dismissed student {firstName} {lastName}";
            }

            return $"Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsSubject = students.Where(s => s.Subject == subject).ToList();

            if (studentsSubject.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (Student student in studentsSubject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount() => this.Count;

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
