using MVC5StoreApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC5StoreApp.Controllers
{
    public class HomeController : Controller
    {
        MVC5StoreAppDBContext storeDb = new MVC5StoreAppDBContext();

        public ActionResult Index()
        {
            var items = GetTopSellingItems(10);
            return View(items);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // Group the order details by Item and 
        // Return the Items with the Higest count
        private List<Item> GetTopSellingItems(int count)
        {
            return storeDb.Items.OrderByDescending(i => i.OrderDetails.Count()).Take(count).ToList();
        }
    }
}