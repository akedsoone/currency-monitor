using CurrencyMonitor.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CurrencyMonitor.Web.Controllers
{
    [Controller]
    public class DepartmentController : Controller
    {
        private readonly string _jsonPath;

        public DepartmentController(IWebHostEnvironment env)
        {
            _jsonPath = Path.Combine(env.ContentRootPath, "Departments.json");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var json = await System.IO.File.ReadAllTextAsync(_jsonPath);

            var departments = JsonSerializer.Deserialize<List<DepartmentViewModel>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(departments);
        }
    }
}