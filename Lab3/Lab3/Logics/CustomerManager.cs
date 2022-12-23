using Lab3.Models;

namespace Lab3.Logics;

public class CustomerManager
{
    public List<Customer> GetCustomers()
    {
        using (var context = new NorthwindContext())
        {
            return context.Customers.ToList();
        }
    }
}
