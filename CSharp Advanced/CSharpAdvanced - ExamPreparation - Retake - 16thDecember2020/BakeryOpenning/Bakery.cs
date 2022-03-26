using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> employees;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.employees = new List<Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.employees.Count;

        public void Add(Employee employee)
        {
            if (this.Capacity > this.Count)
            {
                this.employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            if (this.employees.Any(e => e.Name == name))
            {
                this.employees.Remove(this.employees.FirstOrDefault(e => e.Name == name));
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            Employee oldestEmployee = this.employees.OrderByDescending(e => e.Age).FirstOrDefault();
            return oldestEmployee;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = this.employees.FirstOrDefault(e => e.Name == name);
            return employee;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (Employee employee in this.employees)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
