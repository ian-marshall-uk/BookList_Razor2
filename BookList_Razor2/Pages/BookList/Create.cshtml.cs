using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList_Razor2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookList_Razor2.Pages.BookList
{
    public class CreateModel : PageModel
    {

        private ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;

        }

        [BindProperty] // This saves having to pass a Book object into those methods which require it such as OnPost
        public Book Book { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            ;
             _db.Books.Add(Book);

            await _db.SaveChangesAsync();
            Message = "New book added successfully!";

            return RedirectToPage(nameof(Index)); // Added nameof was "Index"
        }
    }
}