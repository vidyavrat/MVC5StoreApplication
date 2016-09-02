using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5StoreApp.ViewModels;
using MVC5StoreApp.Models;

namespace MVC5StoreApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        MVC5StoreAppDBContext storeDB = new MVC5StoreAppDBContext();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the item from the database
            var addedItem = storeDB.Items.Single(item => item.ItemId == id);

            // Add item to the Shopping Cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedItem);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public JsonResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string itemName = storeDB.Carts.Single(Item => Item.RecordId == id).Item.Title;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            //Display the Confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = $"{Server.HtmlEncode(itemName)} has been Removed from your Shopping Cart",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }

        // GET: / ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewBag.CartCount = cart.GetCount();

            return PartialView("CartSummary");
        }
    }
}