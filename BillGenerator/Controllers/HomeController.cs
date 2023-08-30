using BillGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BillGenerator.Controllers
{
    public class HomeController : Controller
    {
      private readonly BillerDemoDbContext _context;

        public HomeController(BillerDemoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Create()
        {
            ViewBag.BillerList = new SelectList(_context.Billers, "Id", "Name");
            ViewBag.FieldTypeList = new SelectList(_context.BillerFormFieldTypes, "Id", "Description");
            ViewBag.DatasetList = new SelectList(_context.BillerFormDatasets, "Id", "DatasetName");
            BillerFormDataset billerFormDataset = new BillerFormDataset();
            billerFormDataset.BillerFormDatasetFields.Add(new BillerFormDatasetField());
            
            return View(billerFormDataset);
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

            ViewBag.BillerList = new SelectList(_context.Billers, "Id", "Name");
            ViewBag.FieldTypeList = new SelectList(_context.BillerFormFieldTypes, "Id", "Description");
            ViewBag.DatasetList = new SelectList(_context.BillerFormDatasets, "Id", "DatasetName");
            return View(model);
        }

    }
}