using BusinessObjects.DTOs;
using BusinessObjects.Entities;
using DataAccessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewsManagementSystemMVC.Filters;
using Services.Interface;
using System;

namespace NewsManagementSystemMVC.Controllers
{
    [AuthorizeUser("Staff")]
    public class NewsArticleController : Controller
    {
        private readonly INewsArticleService _naService;
        private readonly ICategoryService _cateService;
        private readonly ITaqService _taqService;
        private readonly FUNewsDbContext _context;

        public NewsArticleController(INewsArticleService service, ICategoryService categoryService, ITaqService taqService, FUNewsDbContext context)
        {
            _naService = service;
            _cateService = categoryService;
            _taqService = taqService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var articles = await _naService.GetAllAsync();
            return View(articles);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                }).ToList();

            ViewBag.Taqs = _context.Taqs
                .Select(t => new SelectListItem
                {
                    Value = t.ID.ToString(),
                    Text = t.Name
                }).ToList();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewsArticleDto dto)
        {
            if (ModelState.IsValid)
            {
                await _naService.CreateAsync(dto); // 

                return RedirectToAction(nameof(Index));
            }

            await LoadSelectListsAsync();

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var article = await _naService.GetByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            var dto = new UpdateNewsArticleDto
            {
                ID = article.ID,
                Title = article.Title,
                Content = article.Content,
                CategoryID = article.CategoryID,
                NewsStatus = article.NewsStatus,
                TaqIDs = article.Taqs.Select(t => t.ID).ToList()
            };

            await LoadSelectListsAsync();
            return View(dto);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(UpdateNewsArticleDto dto)
        {
            if (!ModelState.IsValid)
            {
                await LoadSelectListsAsync();
                return View(dto);
            }

            await _naService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var article = await _naService.GetByIdAsync(id);
            return View(article);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _naService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        private async Task LoadSelectListsAsync()
        {
            ViewBag.Categories = new SelectList(await _cateService.GetAllAsync(), "ID", "Name");
           ViewBag.Taqs = new MultiSelectList(await _taqService.GetAllAsync(), "ID", "Name");
        }

    }

}
