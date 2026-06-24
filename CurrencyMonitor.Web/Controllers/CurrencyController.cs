using CurrencyMonitor.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CurrencyMonitor.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController(ICurrencyMonitorDbContext db) : ControllerBase
    {
        private readonly ICurrencyMonitorDbContext _db = db;

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrent()
        {
            var latest = await _db.AvailabilityRecords
                .GroupBy(r => new { r.DepartmentId, r.Currency })
                .Select(g => g.OrderByDescending(r => r.CheckedAt).First())
                .ToListAsync();

            return Ok(latest);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory(
            [FromQuery] int departmentId,
            [FromQuery] string currency,
            [FromQuery] string period = "day")
        {
            var from = period switch
            {
                "week" => DateTime.UtcNow.AddDays(-7),
                "month" => DateTime.UtcNow.AddMonths(-1),
                _ => DateTime.UtcNow.AddDays(-1)
            };

            var records = await _db.AvailabilityRecords
                .Where(r => r.DepartmentId == departmentId
                         && r.Currency == currency
                         && r.CheckedAt >= from)
                .OrderBy(r => r.CheckedAt)
                .Select(r => new { r.CheckedAt, r.Amount })
                .ToListAsync();

            return Ok(records);
        }
    }
}