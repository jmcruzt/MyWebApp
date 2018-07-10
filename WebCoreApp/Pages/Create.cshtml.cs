using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebCoreApp.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; }
        private readonly AppDbContext _db;
        
        [TempData]
        public string Message { get; set; }

        public CreateModel(AppDbContext db)
        {
            _db = db;
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            Message = $"Customer {Customer.Name} Added!";
            return RedirectToPage("/Index");
        }
    }
}