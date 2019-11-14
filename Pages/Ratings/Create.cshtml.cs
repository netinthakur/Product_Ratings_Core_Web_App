using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Ratings_Core_Web_App.Models;
using Product_Ratings_MVC.Models;

namespace Product_Ratings_Core_Web_App.Pages.Ratings
{
    //Creates a  rating .
    public class CreateModel : PageModel
    {
        private readonly Product_Ratings_Core_Web_App.Models.Product_Ratings_Core_Web_AppDataContext _context;

        public CreateModel(Product_Ratings_Core_Web_App.Models.Product_Ratings_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Gets the create rating form
        public IActionResult OnGet()
        {
        ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Name");
        ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Name");
            return Page();
        }

        //Binds the rating model
        [BindProperty]
        public Rating Rating { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Creates the rating.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rating.Add(Rating);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
