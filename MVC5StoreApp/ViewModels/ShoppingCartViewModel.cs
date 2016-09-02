using System.Collections.Generic;
using MVC5StoreApp.Models;

namespace MVC5StoreApp.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}