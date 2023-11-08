using DataTablesParser;
using Microsoft.AspNetCore.Mvc;
using FakeDateGen.Data;
using FakeDateGen.Models;
using FakeDateGen.Service;
using Microsoft.EntityFrameworkCore;

namespace PersonalDataMNG.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFakeDataService _iFakeDataService;

        public ProductController(ApplicationDbContext context, IFakeDataService iFakeDataService)
        {
            _context = context;
            _iFakeDataService = iFakeDataService;
        }

        public async Task<IActionResult> Index()
        {
            var _Product = await _context.Product.ToListAsync();
            if (_Product.Count < 1)
            {
                await GenerateOneMillionData();
            }
            return View();
        }

        public IActionResult Data()
        {
            var listCategory = _context.Product.OrderByDescending(x => x.Id).AsQueryable();
            var parser = new Parser<Product>(Request.Form, listCategory);
            return Json(parser.Parse());
        }
        public async Task GenerateOneMillionData()
        {
            var batches = _iFakeDataService.GetFakeProductList();
            foreach (var batch in batches)
            {
                await _context.Product.AddRangeAsync(batch);
                await _context.SaveChangesAsync();
            }
        }
    }
}
