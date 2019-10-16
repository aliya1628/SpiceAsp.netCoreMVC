using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpiceAsp.netCoreMVC.Data;

namespace SpiceAsp.netCoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET
        public async Task<IActionResult> Index()
        {

            return View(await _context.Category.ToListAsync());
        }
    }
}