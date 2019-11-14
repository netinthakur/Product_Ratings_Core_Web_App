using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product_Ratings_MVC.Models;

namespace Product_Ratings_Core_Web_App.Models
{
    //Connects the business layer to the database.
    public class Product_Ratings_Core_Web_AppDataContext : DbContext
    {
        public Product_Ratings_Core_Web_AppDataContext (DbContextOptions<Product_Ratings_Core_Web_AppDataContext> options)
            : base(options)
        {
        }

        public DbSet<Product_Ratings_MVC.Models.Customer> Customer { get; set; }

        public DbSet<Product_Ratings_MVC.Models.Product> Product { get; set; }

        public DbSet<Product_Ratings_MVC.Models.Rating> Rating { get; set; }
    }
}
