using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_app.Models;
using System.Linq;

namespace MVC_app.Controllers
{
    public class CodeController : Controller
    {
        // GET: Code

        NorthwindEntities db = new NorthwindEntities();
        public ActionResult CustomersInGermany()
        {
            var customersInGermany = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customersInGermany);
        }

        public ActionResult CustomerDetails()
        {
            int orderId = 10248;
            var customerDetails = db.Orders.Where(o => o.OrderID == orderId).Select(o => o.Customer).FirstOrDefault();

            return View(customerDetails);
        }
        public ActionResult Index()
        {
            List<Category> list = db.Categories.ToList();
            return View(list);
        }
    }
}
