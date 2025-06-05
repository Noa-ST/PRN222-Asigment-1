using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Mvc;
using NewsManagementSystemMVC.Filters;
using Services.Interface;

namespace NewsManagementSystemMVC.Controllers
{
    [AuthorizeUser("Admin")]
    public class SystemAccountController : Controller
    {
        private readonly ISystemAccountService _service;

        public SystemAccountController(ISystemAccountService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _service.GetAllAsync();
            return View(users);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateSystemAccountDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _service.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var getDto = await _service.GetByIdAsync(id);
            if (getDto == null) return NotFound();

            var updateDto = new UpdateSystemAccountDto
            {
                ID = getDto.ID,
                FullName = getDto.FullName,
                Email = getDto.Email,
                Password = getDto.Password,
                Role = getDto.Role
            };

            return View(updateDto); 
        }


        [HttpPost]
        public async Task<IActionResult> Edit(UpdateSystemAccountDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            await _service.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _service.GetByIdAsync(id);
            return View(user);
        }

        [HttpPost, ActionName("DeleteConfirmed")] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
