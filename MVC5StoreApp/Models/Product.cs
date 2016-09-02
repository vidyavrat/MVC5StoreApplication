using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC5StoreApp.Models
{
    public class Product
    {
        public virtual int ProductId { get; set; }
        public virtual string Name { get; set; }
    }
}
