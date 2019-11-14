using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Product_Ratings_Core_Web_App.Models;
using Product_Ratings_MVC.Models;

namespace Product_Ratings_Core_Web_App.Pages.Customers
{
    //Gets all customers
    public class IndexModel : PageModel
    {
        private readonly Product_Ratings_Core_Web_App.Models.Product_Ratings_Core_Web_AppDataContext _context;

        public IndexModel(Product_Ratings_Core_Web_App.Models.Product_Ratings_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Customer list.
        public IList<Customer> Customer { get;set; }

        //Gets all customers using a linq query
        public void OnGet()
        {
            Customer = (from customers in _context.Customer
                        select customers).ToList();
        }
    }
}
