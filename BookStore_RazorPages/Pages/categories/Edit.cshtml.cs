using BookStore_RazorPages.Data;
using BookStore_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStore_RazorPages.Pages.Categories
{
    [BindProperties]

    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
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
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category edited successfully";
                return RedirectToPage("Index");
            }
            return RedirectToPage("Index");
        }
    }
}
