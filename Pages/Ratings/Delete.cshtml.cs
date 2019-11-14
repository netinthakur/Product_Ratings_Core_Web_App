using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Product_Ratings_Core_Web_App.Models;
using Product_Ratings_MVC.Models;

namespace Product_Ratings_Core_Web_App.Pages.Ratings
{
    //Deletes a rating
    public class DeleteModel : PageModel
    {
        private readonly Product_Ratings_Core_Web_App.Models.Product_Ratings_Core_Web_AppDataContext _context;

        public DeleteModel(Product_Ratings_Core_Web_App.Models.Product_Ratings_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Binds the model.
        [BindProperty]
        public Rating Rating { get; set; }

        //Gets the rating for delete using a ldam query

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rating =  _context.Rating
                .Include(r => r.Customer)
                .Include(r => r.Product).FirstOrDefault(m => m.Id == id);

            if (Rating == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Deletes the rating 
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rating = (from rating in _context.Rating
                      where rating.Id == id
                      select rating).FirstOrDefault();

            if (Rating != null)
            {
                _context.Rating.Remove(Rating);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
