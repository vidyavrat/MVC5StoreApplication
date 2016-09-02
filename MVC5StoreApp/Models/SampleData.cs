using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC5StoreApp.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<MVC5StoreApp.Models.MVC5StoreAppDBContext>
    {
        //ToDo: Fix the sample data as shown in MVC3Music Store especially Items values in the collection.
        protected override void Seed(MVC5StoreApp.Models.MVC5StoreAppDBContext context)
        {
            //context.Genres.Add(new Genre { Name = "Electronics" });
            //context.Genres.Add(new Genre { Name = "Music" });
            //context.Genres.Add(new Genre { Name = "Food" });
            //context.Genres.Add(new Genre { Name = "Books" });
            //context.Genres.Add(new Genre { Name = "Clothing" });
            //context.Genres.Add(new Genre { Name = "Computer" });
            //context.Genres.Add(new Genre { Name = "Hardware" });


            //context.Products.Add(new Product { Name = "Sony HandyCam" });
            //context.Products.Add(new Product { Name = "Ghazals DVD" });
            //context.Products.Add(new Product { Name = "Indian Bread" });
            //context.Products.Add(new Product { Name = "C# 2012 Databases" });
            //context.Products.Add(new Product { Name = "T-Shirt" });
            //context.Products.Add(new Product { Name = "Thinkpad T-520" });
            //context.Products.Add(new Product { Name = "LCD PC Monitor" });

           
            context.Items.Add(new Item { Title = "Cool Cam", Genre = new Genre { Name = "Electronics" }, Price = 8.99M, Product = new Product { Name = "Sony 18mp camera" }, ItemUrl = "/Content/Images/placeholder.gif" });
            context.Items.Add(new Item { Title = "Music", Genre = new Genre { Name = "Music" }, Price = 4.009M, Product = new Product { Name = "Ghazals" }, ItemUrl = "/Content/Images/placeholder.gif" });
            context.Items.Add(new Item { Title = "Indian Food", Genre = new Genre { Name = "Food" }, Price = 1.95M, Product = new Product { Name = "Fresh Indian Bread" }, ItemUrl = "/Content/Images/placeholder.gif" }); 
            context.Items.Add(new Item { Title = "Computer Books", Genre = new Genre { Name = "Books" }, Price = 39.99M, Product = new Product { Name = "Beginning C# 2012 Databases" }, ItemUrl = "/Content/Images/placeholder.gif" });
            context.Items.Add(new Item { Title = "Clothes", Genre = new Genre { Name = "Clothing" }, Price = 14.99M, Product = new Product { Name = "Men's T-Shirt" }, ItemUrl = "/Content/Images/placeholder.gif" });
            context.Items.Add(new Item { Title = "Computer", Genre = new Genre { Name = "Computer" }, Price = 1270.00M, Product = new Product { Name = "zLenovo Thinkpad T-520" }, ItemUrl = "/Content/Images/placeholder.gif" }); 
            context.Items.Add(new Item { Title = "Hardware", Genre = new Genre { Name = "Hardware" }, Price = 55.00M, Product = new Product { Name = "LCD Monitor" }, ItemUrl = "/Content/Images/placeholder.gif" });
            base.Seed(context);
        }
    }
}