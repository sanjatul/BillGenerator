using BillGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BillGenerator.Controllers
{
    public class BillerFormDatasetsController : Controller
    {
        private readonly BillerDemoDbContext _context;
        public BillerFormDatasetsController(BillerDemoDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<BillerFormDataset> billerFormDatasets=_context.BillerFormDatasets.Include(u=>u.Biller).ToList();
            return View(billerFormDatasets);
        }
        public IActionResult Create()
        {
            ViewBag.BillerList = new SelectList(_context.Billers, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BillerFormDataset model)
        {
            if (ModelState.IsValid)
            {
                _context.BillerFormDatasets.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BillerList = new SelectList(_context.Billers, "Id", "Name", model.BillerId);
            return View(model);
        }


    }
}
