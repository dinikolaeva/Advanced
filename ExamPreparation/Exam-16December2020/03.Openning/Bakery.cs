using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Employee>();
        }

        public void Add(Employee employee)
        {
            if (data.Count < this.Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {

            int index = data.FindIndex(x => x.Name == name);

            if (index >= 0)
            {
                data.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Employee GetOldestEmployee()
        {
            Employee oldestEmployee = new Employee("", -1, "");

            foreach (var employe in data)
            {
                if (employe.Age > oldestEmployee.Age)
                {
                    oldestEmployee = employe;
                }
            }

            return oldestEmployee;
        }

        public Employee GetEmployee(string name)
        {
            Employee searchedName = new Employee();

            foreach (var employee in data)
            {
                if (employee.Name == name)
                {
                    searchedName = employee;
                }
            }

            return searchedName;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var item in data)
            {
                sb.AppendLine($"Employee: {item.Name}");
            }
            return sb.ToString();
        }

        public int Count { get => data.Count; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
