using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Product_Ratings_Core_Web_App.Models;
using Product_Ratings_MVC.Models;

namespace Product_Ratings_Core_Web_App.Pages.Products
{
    //Deletes the product.
    public class DeleteModel : PageModel
    {
        private readonly Product_Ratings_Core_Web_App.Models.Product_Ratings_Core_Web_AppDataContext _context;

        public DeleteModel(Product_Ratings_Core_Web_App.Models.Product_Ratings_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds the product model.
        [BindProperty]
        public Product Product { get; set; }

        //Gets the product for delete using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product =  _context.Product.FirstOrDefault(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes the product uses a linq query tp get the product
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = (from product in _context.Product
                       where product.Id == id
                       select product).FirstOrDefault();

            if (Product != null)
            {
                _context.Product.Remove(Product);
               _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
