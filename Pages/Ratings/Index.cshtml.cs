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
    //Gets all ratings
    public class IndexModel : PageModel
    {
        private readonly Product_Ratings_Core_Web_App.Models.Product_Ratings_Core_Web_AppDataContext _context;

        public IndexModel(Product_Ratings_Core_Web_App.Models.Product_Ratings_Core_Web_AppDataContext context)
        {
            _context = context;
        }

        //Rate list
        public IList<Rating> Rating { get;set; }

        //Gets all rating using a lamda query.
        public void OnGet()
        {
            Rating =  _context.Rating
                .Include(r => r.Customer)
                .Include(r => r.Product).ToList();
        }
    }
}
