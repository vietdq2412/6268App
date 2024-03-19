using _6262App.Business.Services;
using _6282App.core.Models;
using Microsoft.AspNetCore.Mvc;

namespace beverageHelper.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        public Task<IActionResult> Index()
        {
            List<Supplier> list = supplierService.FindAll();
            return Task.FromResult<IActionResult>(View(list));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            await supplierService.Save(supplier);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(long id)
        {
            if (supplierService.Delete(id).IsCompleted)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}