using BillGenerator.Models;
using Microsoft.AspNetCore.Mvc;

namespace BillGenerator.Controllers
{
    public class BillersController : Controller
    {
        private readonly BillerDemoDbContext _context;
        public BillersController(BillerDemoDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Biller> billers=_context.Billers.ToList();
            return View(billers);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Biller biller)
        {
            if(ModelState.IsValid)
            {
                _context.Billers.Add(biller);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(biller);
        }
    }
}
