﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebCoreApp.Pages
{
    public class IndexModel : PageModel
    {

        private readonly AppDbContext _db;
        [TempData]
        public string Message { get; set; }
        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public IList<Customer> Customers { get; private set; }
        public async Task OnGet()
        {
            Customers = await _db.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var customer = await _db.Customers.FindAsync(id);

            if (customer != null)
            {
                _db.Customers.Remove(customer);
                await _db.SaveChangesAsync();
            }

            Message = $"Customer {customer.Name} deleted!";
            return RedirectToPage();
        }
    }
}
