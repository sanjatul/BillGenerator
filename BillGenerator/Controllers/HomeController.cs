using BillGenerator.Abstractions.Requests;
using BillGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                        FieldTypeId = orderItem.DatasetId,
                        DatasetId = orderItem.DatasetId

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

    }
}