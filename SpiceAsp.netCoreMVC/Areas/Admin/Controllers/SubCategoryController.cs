using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpiceAsp.netCoreMVC.Data;
using SpiceAsp.netCoreMVC.Models;
using SpiceAsp.netCoreMVC.Models.ViewModels;

namespace SpiceAsp.netCoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SubCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET- INDEX
        public async Task<IActionResult> Index()
        {
            var subCategories = await _context.SubCategory.Include(x => x.Category).ToListAsync();
            return View(subCategories);
        }

        //GET - CREATE
        public async Task<IActionResult> Create()
        {
            var model = new SubcategoryAndCategory() {

                CategoryList = await _context.Category.ToListAsync(),
                SubCategory = new SubCategory(),
                SubcategoryList = await _context.SubCategory.OrderBy(o => o.Name).Select(s => s.Name).Distinct().ToListAsync()
            };
            return View(model);
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubcategoryAndCategory viewModel)
        {
            if (ModelState.IsValid)
            {
                var doesSubcategoryExist =  _context.SubCategory.Include(i => i.Category).Where(w => w.Name == viewModel.SubCategory.Name && w.Category.Id == viewModel.SubCategory.CategoryId);
                if (doesSubcategoryExist.Count() > 0)
                {
                    //Error
                }
                else
                {
                    _context.SubCategory.Add(viewModel.SubCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            SubcategoryAndCategory modelVM = new SubcategoryAndCategory()
            {
                CategoryList = await _context.Category.ToListAsync(),
                SubCategory = viewModel.SubCategory,
                SubcategoryList = await _context.SubCategory.OrderBy(o => o.Name).Select(s => s.Name).ToListAsync()

            };
            return View(modelVM);
        }
    }
}