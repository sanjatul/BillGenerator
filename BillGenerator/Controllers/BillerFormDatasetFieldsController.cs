using BillGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BillGenerator.Controllers
{
    public class BillerFormDatasetFieldsController : Controller
    {
        private readonly BillerDemoDbContext _context;
        public BillerFormDatasetFieldsController(BillerDemoDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<BillerFormDatasetField> billerFormDatasetFields = _context.BillerFormDatasetFields.Include(u=>u.BillerFormDatasetFieldValues).Include(u => u.FieldType).Include(u=>u.Dataset).ToList();
            return View(billerFormDatasetFields);
        }
        public IActionResult Create()
        {
            ViewBag.FieldTypeList = new SelectList(_context.BillerFormFieldTypes, "Id", "Description");
            ViewBag.DatasetList = new SelectList(_context.BillerFormDatasets, "Id", "DatasetName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BillerFormDatasetField model)
        {
            if (ModelState.IsValid)
            {
                _context.BillerFormDatasetFields.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FieldTypeList = new SelectList(_context.BillerFormFieldTypes, "Id", "TypeName", model.FieldTypeId);
            ViewBag.DatasetList = new SelectList(_context.BillerFormDatasets, "Id", "DatasetName", model.DatasetId);
            return View(model);
        }

    }
}
