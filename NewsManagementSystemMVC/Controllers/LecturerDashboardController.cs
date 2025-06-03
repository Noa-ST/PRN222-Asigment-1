using Microsoft.AspNetCore.Mvc;
using NewsManagementSystemMVC.Filters;

namespace NewsManagementSystemMVC.Controllers
{
    [AuthorizeUser("Lecturer")]
    public class LecturerDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
