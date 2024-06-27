using BookStore_RazorPages.Data;
using BookStore_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore_RazorPages.Pages.Categories
{
    //bind all properties
    //[BindProperties]
    public class CreateModel : PageModel
    {
        
        private readonly ApplicationDbContext _db;
        //instead of passing it from page, it will bind so that Post can work. 
        [BindProperty]
        public Category category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost() 
        {
            _db.Categories.Add(category);    
            _db.SaveChanges();
            return RedirectToPage("Index");

        }
    }
}
