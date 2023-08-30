using BillGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Linq;

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
            ViewBag.BillerList = new SelectList(_context.Billers, "Id", "Name");
            ViewBag.FieldTypeList = new SelectList(_context.BillerFormFieldTypes, "Id", "Description");
            ViewBag.DatasetList = new SelectList(_context.BillerFormDatasets, "Id", "DatasetName");
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
                foreach (var (dataFields, bFDF) in from dataFields in model.BillerFormDatasetFields
                                                   let bFDF = new BillerFormDatasetField()
                                                   select (dataFields, bFDF))
                {
                    bFDF.IsMandatory = dataFields.IsMandatory;
                    bFDF.MaxLength = dataFields.MaxLength;
                    bFDF.Regex = dataFields.Regex;
                    bFDF.FieldTypeId = dataFields.FieldTypeId;
                    bFDF.CreatedBy = dataFields.CreatedBy;
                    bFDF.CreatedAt = dataFields.CreatedAt;
                    bFDF.UpdatedBy = dataFields.UpdatedBy;
                    bFDF.UpdatedAt = dataFields.UpdatedAt;
                    bFDF.DatasetId = dataFields.DatasetId;
                    bFDF.MinValue = dataFields.MinValue;
                    bFDF.MaxValue = dataFields.MaxValue;
                    bFDF.FieldOrder = dataFields.FieldOrder;
                    bFDF.FieldName = dataFields.FieldName;
                    bFDF.FriendlyFieldName = dataFields.FriendlyFieldName;
                    bFDF.IsActive = dataFields.IsActive;
                    _context.BillerFormDatasetFields.Add(bFDF);
                }

                
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