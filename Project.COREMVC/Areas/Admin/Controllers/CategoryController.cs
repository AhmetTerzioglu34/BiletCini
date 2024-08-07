using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.COREMVC.Areas.Admin.Models.PageVms.Category;
using Project.COREMVC.Areas.Admin.Models.PureVms.Category;
using Project.ENTITIES.Entities;

namespace Project.COREMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public class CategoryController : Controller
    {


        readonly ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _categoryManager.GetAllAsync();

            List<GetCategoryPureVm> gCvm = categories.Select(gCvm => new GetCategoryPureVm
            {
                ID = gCvm.ID,
                CategoryName = gCvm.CategoryName,
                Status = gCvm.Status
            }).ToList();

            GetCategoryPageVm getCategory = new GetCategoryPageVm();
            getCategory.GetCategoryPureVms = gCvm;

            return View(getCategory);
        }


        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryPageVm model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.CategoryName = model.CreateCategoryPureVm.CategoryName;
                await _categoryManager.AddAsync(category);
                TempData["Message"] = $"{category.CategoryName} verisi Eklendi";
                return RedirectToAction("Index");
            }
            return View(model);
        }


        public async Task<IActionResult> DeleteCategory(int id)
        {
            TempData["Message"] =  await  _categoryManager.DeleteAsync(await _categoryManager.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DestroyCategory(int id)
        {
            TempData["Message"] = await _categoryManager.DestroyAsync(await _categoryManager.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            Category category = await _categoryManager.FindAsync(id);
            UpdateCategoryPureVm updateCategoryPureVM = new UpdateCategoryPureVm();
            updateCategoryPureVM.ID = category.ID;
            updateCategoryPureVM.CategoryName = category.CategoryName;
            UpdateCategoryPageVm updateCategoryPageVM = new UpdateCategoryPageVm();
            updateCategoryPageVM.UpdateCategoryPureVm = updateCategoryPureVM;
            return View(updateCategoryPageVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryPageVm model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.ID = model.UpdateCategoryPureVm.ID;
                category.CategoryName = model.UpdateCategoryPureVm.CategoryName;
                await _categoryManager.UpdateAsync(category);
                TempData["Message"] = $"{category.ID} ID'li veri güncellendi";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
