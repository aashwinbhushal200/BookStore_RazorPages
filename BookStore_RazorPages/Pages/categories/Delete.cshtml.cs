using BookStore_RazorPages.Data;
using BookStore_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookStore_RazorPages.Pages.Categories
{
    //bind all properties
    [BindProperties]
    public class DeleteModel : PageModel
    {
        
        private readonly ApplicationDbContext _db;
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category category { get; set; }
        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                category = _db?.Categories?.FirstOrDefault(u => u.Id == id);
            }

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }
            return RedirectToPage("Index");
        }
    }
}
