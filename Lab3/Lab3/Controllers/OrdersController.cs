using Lab3.Logics;
using Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult List(int Id)
        {
            EmployeeManager emManager = new EmployeeManager();
            List<Employee> listEm = emManager.GetEmployees();
            OrdersManager ordersManager = new OrdersManager();
            List<Order> listOrder = ordersManager.GetOrders(Id);
            DateTime minOD = ordersManager.minOrderDate();
            DateTime maxOD = ordersManager.maxOrderDate();
            ViewBag.listEm = listEm;
            ViewBag.minOrD = minOD;
            ViewBag.maxOrD = maxOD;
            return View(listOrder);
        }

        public IActionResult Edit(int Id)
        {
            CustomerManager cusManager = new CustomerManager();
            EmployeeManager emManager = new EmployeeManager();
            OrdersManager ordersManager = new OrdersManager();
            Order or = ordersManager.GetOrder(Id);
            ViewBag.listEm = emManager.GetEmployees();
            ViewBag.listCus = cusManager.GetCustomers();
            return View(or);
        }

        public IActionResult DoEdit(Order order)
        {
            OrdersManager ordersManager = new OrdersManager();
            ordersManager.EditOrder(order);
            return RedirectToAction("List");
        }
        public IActionResult DoDelete(int Id)
        {
            OrdersManager ordersManager = new OrdersManager();
            ordersManager.DeleteOrder(Id);
            return RedirectToAction("List");
        }
    }
}
