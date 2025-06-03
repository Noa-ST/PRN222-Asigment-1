using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using BusinessObjects.DTOs;
using NewsManagementSystemMVC.Filters;

namespace NewsManagementSystemMVC.Controllers
{
    [AuthorizeUser("Staff")]
    public class TagController : Controller
    {
        private readonly ITaqService _taqService;

        public TagController(ITaqService taqService)
        {
            _taqService = taqService;
        }

        public async Task<IActionResult> Index()
        {
            var taqs = await _taqService.GetAllAsync();
            return View(taqs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaqDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _taqService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var taq = await _taqService.GetByIdAsync(id);
            if (taq == null) return NotFound();

            var updateDto = new UpdateTaqDto
            {
                ID = taq.ID,
                Name = taq.Name
            };
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateTaqDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _taqService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _taqService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
