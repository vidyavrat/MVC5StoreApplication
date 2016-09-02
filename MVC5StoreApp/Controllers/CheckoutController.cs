using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5StoreApp.Models;

namespace MVC5StoreApp.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        MVC5StoreAppDBContext storedb = new MVC5StoreAppDBContext();
        const string PromoCode = "FREE";

        // GET: Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //
        //POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndpayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                if (String.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    // Save order
                    storedb.Orders.Add(order);
                    storedb.SaveChanges();

                    // Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete", new { id = order.OrderId });
                }
            }
            catch
            {
                // Invalid - redisplay with Errors
                return View(order);
            }
        }

        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // validate customer owns this order before Completion
            bool isValid = storedb.Orders.Any(o => o.OrderId == id && o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}