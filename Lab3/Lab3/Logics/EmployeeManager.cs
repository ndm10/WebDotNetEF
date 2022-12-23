using Lab3.Models;

namespace Lab3.Logics
{
    public class EmployeeManager
    {
        public List<Employee> GetEmployees()
        {
            using (var context = new NorthwindContext())
            {
                return context.Employees.ToList();
            }
        }
    }
}
