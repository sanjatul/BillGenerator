using BillGenerator.Abstractions;
using BillGenerator.Abstractions.Requests;
using BillGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BillGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly BillerDemoDbContext _context;

        public HomeController(BillerDemoDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.BillerList = new SelectList(_context.Billers, "Id", "Name");
            ViewBag.FieldTypeList = new SelectList(_context.BillerFormFieldTypes, "Id", "Description");
            return View();
        }
        [HttpPost]
        public IActionResult SaveOrder([FromBody] OrderCreate orderCreate)
        {

            try
            {
                BillerFormDataset billerFormDataset = new BillerFormDataset
                {
                    DatasetName = orderCreate.DatasetName,
                    UniqueId = orderCreate.UniqueId,
                    BillerId = orderCreate.BillerId,
                    CreatedBy = orderCreate.CreatedBy,
                    CreatedAt = orderCreate.CreatedAt,
                    UpdatedBy = orderCreate.UpdatedBy,
                    UpdatedAt = orderCreate.UpdatedAt
                };

                _context.BillerFormDatasets.Add(billerFormDataset);

                foreach (OrderField orderItem in orderCreate.Order)
                {
                    int? intMandatory = orderItem.IsMandatory; // or any other integer value
                    bool boolMandatory = intMandatory != 0;
                    int? intActive = orderItem.IsActive; // or any other integer value
                    bool boolActive = intActive != 0;
                    // Create an OrderItem object and add it to the list
                    BillerFormDatasetField billerFormDatasetField = new BillerFormDatasetField
                    {

                        FieldName = orderItem.FieldName,
                        MaxLength = orderItem.MaxLength,
                        Regex = orderItem.Regex,
                        CreatedBy = orderItem.CreatedBy,
                        CreatedAt = orderItem.CreatedAt,
                        MinValue = orderItem.MinValue,
                        MaxValue = orderItem.MaxValue,
                        UpdatedBy = orderItem.UpdatedBy,
                        UpdatedAt = orderItem.UpdatedAt,
                        FieldOrder = orderItem.FieldOrder,
                        FriendlyFieldName = orderItem.FriendlyFieldName,
                        IsMandatory = boolMandatory,
                        IsActive = boolActive,
                        FieldTypeId = orderItem.FieldTypeId,
                        Dataset = billerFormDataset

                    };

                    _context.BillerFormDatasetFields.Add(billerFormDatasetField);
                }
                _context.SaveChanges();

                return Json(new { success = true, message = "Data processed successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataset = await _context.BillerFormDatasets
                .Include(d => d.Biller)
                .Include(d => d.BillerFormDatasetFields)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dataset == null)
            {
                return NotFound();
            }
            return View(dataset);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataset = await _context.BillerFormDatasets
                .Include(d => d.Biller)
                .Include(d => d.BillerFormDatasetFields)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dataset == null)
            {
                return NotFound();
            }
            ViewBag.BillerList = new SelectList(_context.Billers, "Id", "Name");
            ViewBag.FieldTypeList = new SelectList(_context.BillerFormFieldTypes, "Id", "Description");
            return View(dataset);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BillerFormDataset billerFormDataset)
        {
            if (!ModelState.IsValid)
            {
                View(billerFormDataset);
            }
            _context.BillerFormDatasets.Update(billerFormDataset);
            foreach (BillerFormDatasetField fields in billerFormDataset.BillerFormDatasetFields)
            {
                _context.BillerFormDatasetFields.Update(fields);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveDataFields(int? fieldId, int? datasetId)
        {
            if (fieldId is null || fieldId == 0 || datasetId == 0 || datasetId is null)
            {
                return Json(new { success = false });
            }
            var billerFormDatasetField = await _context.BillerFormDatasetFields.FirstOrDefaultAsync(x=>x.Id== fieldId);
            if (billerFormDatasetField == null)
            {
                return Json(new { success = false });
            }
            _context.BillerFormDatasetFields.Remove(billerFormDatasetField);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Data processed successfully" });
            //return RedirectToAction("Edit", new { id = datasetId });
        }

        [HttpPost]
        public async Task<IActionResult> AddDataFields([FromBody] UpdateOrder updateOrder)
        {
            

                foreach (var orderItem in updateOrder.Order)
                {
                    int? intMandatory = orderItem.IsMandatory; // or any other integer value
                    bool boolMandatory = intMandatory != 0;
                    int? intActive = orderItem.IsActive; // or any other integer value
                    bool boolActive = intActive != 0;
                    // Create an OrderItem object and add it to the list
                    BillerFormDatasetField billerFormDatasetField = new BillerFormDatasetField
                    {

                        FieldName = orderItem.FieldName,
                        MaxLength = orderItem.MaxLength,
                        Regex = orderItem.Regex,
                        CreatedBy = orderItem.CreatedBy,
                        CreatedAt = orderItem.CreatedAt,
                        MinValue = orderItem.MinValue,
                        MaxValue = orderItem.MaxValue,
                        UpdatedBy = orderItem.UpdatedBy,
                        UpdatedAt = orderItem.UpdatedAt,
                        FieldOrder = orderItem.FieldOrder,
                        FriendlyFieldName = orderItem.FriendlyFieldName,
                        IsMandatory = boolMandatory,
                        IsActive = boolActive,
                        FieldTypeId = orderItem.FieldTypeId,
                        DatasetId=updateOrder.Id
                    };

                    _context.BillerFormDatasetFields.Add(billerFormDatasetField);
                }
                await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Data processed successfully" });

        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           var dataset = await _context.BillerFormDatasets
          .Include(d => d.Biller)
          .Include(d => d.BillerFormDatasetFields)
          .FirstOrDefaultAsync(d => d.Id == id);
            foreach (BillerFormDatasetField billerField in dataset.BillerFormDatasetFields)
            {
                var item = await _context.BillerFormDatasetFields.FirstOrDefaultAsync(x=>x.Id==billerField.Id);
                if(item != null)
                {
                    _context.BillerFormDatasetFields.Remove(item);
                }
            }
            await _context.SaveChangesAsync();

            _context.BillerFormDatasets.Remove(dataset);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        #region API CALLS
        public  async Task<IActionResult> GetAll()
        {
            List<BillerFormDataset> billerFormDatasets = await _context.BillerFormDatasets.ToListAsync();
            return Json(new { data = billerFormDatasets });
        }
        #endregion

    }
}