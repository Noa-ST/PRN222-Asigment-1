using Microsoft.AspNetCore.Mvc;
using NewsManagementSystemMVC.Filters;
using Repositories.Interface;

namespace NewsManagementSystemMVC.Controllers
{
    [AuthorizeUser("Lecturer")]
    public class LecturerNewsController : Controller
    {
        private readonly INewsArticleRepository _newsRepo;

        public LecturerNewsController(INewsArticleRepository newsRepo)
        {
            _newsRepo = newsRepo;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _newsRepo.GetActiveArticlesAsync();
            return View(articles);
        }
    }

}
