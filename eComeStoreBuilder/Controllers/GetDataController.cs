using eComeStoreBuilder.Data;
using eComeStoreBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace YourApplication.Controllers
{
    public class GetDataController : Controller
    {
        private readonly eComeStoreBuilderContext _dbContext;

        public GetDataController(eComeStoreBuilderContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult GetDropdownData(string input)
        {
            List<WebsiteType> dropdownItems = _dbContext.WebsiteType
                .Where(w => w.StoreType.Contains(input))
                .ToList();

            return Json(dropdownItems.Select(w => new { id = w.Id, storeType = w.StoreType }));
        }
    }
}
