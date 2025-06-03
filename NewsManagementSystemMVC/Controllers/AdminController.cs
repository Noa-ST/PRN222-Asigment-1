using Microsoft.AspNetCore.Mvc;
using NewsManagementSystemMVC.Filters;
using Services.Interface;

namespace NewsManagementSystemMVC.Controllers
{
    [AuthorizeUser("Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminReportService _reportService;

        public AdminController(IAdminReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<IActionResult> Report()
        {
            var report = await _reportService.GetAdminReportAsync();
            return View(report);
        }
    }

}
