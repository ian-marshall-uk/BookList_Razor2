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
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;

        }

        [BindProperty]
        public Book Book { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet(int id)
        {
            Book = _db.Books.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return RedirectToPage(Book); // No parameter as using the Edit page (this page)

            var bookInDb = _db.Books.Find(Book.Id);

            bookInDb.ISBN = Book.ISBN;
            bookInDb.Title= Book.Title;
            bookInDb.Author = Book.Author;
            bookInDb.Price = Book.Price;
            bookInDb.Availability = Book.Availability;

            await _db.SaveChangesAsync();

            Message = "Book updated successfully";

            return RedirectToPage(nameof(Index));
        }
    }
}