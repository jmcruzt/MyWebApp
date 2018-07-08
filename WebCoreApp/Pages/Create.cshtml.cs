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
        public Customer Customer { get; set; }

        public CreateModel(AppDbContext db)
        {
            _db = db;
        }

        private readonly AppDbContext _db;

        public void OnGet()
        {

        }
    }
}