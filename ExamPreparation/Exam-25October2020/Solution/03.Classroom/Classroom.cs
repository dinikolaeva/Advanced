using System;
using System.Collections.Generic;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> data;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Student>();
        }

        public string RegisterStudent(Student student)
        {
            if (data.Count < Capacity)
            {
                data.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return $"No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            bool isInTheRoom = data.Exists(x => x.FirstName == firstName
                                             && x.LastName == lastName);

            if (isInTheRoom)
            {
                int index = data.FindIndex(x => x.FirstName == firstName && x.LastName == lastName);
                data.RemoveAt(index);
                return $"Dismissed student {firstName} {lastName}";
            }
            return $"Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            int count = 0;

            foreach (Student student in data)
            {
                if (student.Subject == subject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                    count++;
                }
            }

            if (count > 0)
            {
                return sb.ToString().TrimEnd();
            }
            else
            {
                return $"No students enrolled for the subject";
            }
        }

        public int GetStudentsCount()
        {
            return data.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            var searchedStudent = new Student();

            foreach (Student student in data)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    searchedStudent = student;
                }
            }
            return searchedStudent;
        }

        public int Capacity { get; set; }
        public int Count { get => data.Count; }
    }
}
