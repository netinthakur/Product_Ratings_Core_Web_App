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
    //Removes a customer
    public class DeleteModel : PageModel
    {
        private readonly Product_Ratings_Core_Web_App.Models.Product_Ratings_Core_Web_AppDataContext _context;

        public DeleteModel(Product_Ratings_Core_Web_App.Models.Product_Ratings_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        //Gets the customer for delete using a lamda query
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = _context.Customer.FirstOrDefault(m => m.Id == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes a customer . Uses  a linq query to select the customer.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = (from customers in _context.Customer
                        where customers.Id == id
                        select customers).FirstOrDefault();

            if (Customer != null)
            {
                _context.Customer.Remove(Customer);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
