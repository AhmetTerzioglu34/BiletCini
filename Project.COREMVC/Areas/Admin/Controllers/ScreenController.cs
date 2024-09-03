using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Areas.Admin.Models.PageVms.City;
using Project.COREMVC.Areas.Admin.Models.PageVms.Place;
using Project.COREMVC.Areas.Admin.Models.PageVms.Screen;
using Project.COREMVC.Areas.Admin.Models.PureVms.City;
using Project.COREMVC.Areas.Admin.Models.PureVms.Place;
using Project.COREMVC.Areas.Admin.Models.PureVms.Screen;
using Project.ENTITIES.Entities;

namespace Project.COREMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public class ScreenController : Controller
    {
        readonly IScreenManager _screenManager;
        readonly IPlaceManager _placeManager;
        public ScreenController(IScreenManager screenManager, IPlaceManager placeManager)
        {
            _screenManager = screenManager;
            _placeManager = placeManager;
        }
        public async Task<IActionResult> Index()
        {
            List<Screen> screens = await _screenManager.GetAllAsync();
            List<GetScreenAdminPureVM> pureVMs = screens.Select(pureVMs => new GetScreenAdminPureVM
            {
                ID = pureVMs.ID,
                ScreenName = pureVMs.ScreenName,
                Capacity = pureVMs.Capacity,
                PlaceName = pureVMs.Place.PlaceName,
                Status = pureVMs.Status
            } ).ToList();
            GetScreenAdminPageVM getScreenAdminPageVM = new GetScreenAdminPageVM();
            getScreenAdminPageVM.GetScreenAdminPureVMs = pureVMs;
            

            return View(getScreenAdminPageVM);
        }

        public async Task<IActionResult> CreateScreen()
        {

            List<Place> places = await _placeManager.GetActivesAsync();

            List<ScreenPlaceAdminPureVM> pureVMs = places.Select(pureVMs => new ScreenPlaceAdminPureVM
            {
                ID = pureVMs.ID,
                PlaceName = pureVMs.PlaceName
            }).ToList();

            CreateScreenAdminPageVM createScreenAdminPageVM = new CreateScreenAdminPageVM();
            createScreenAdminPageVM.ScreenPlaceAdminPureVMs = pureVMs;


            return View(createScreenAdminPageVM);
           
        }

        [HttpPost]
        public async Task<IActionResult> CreateScreen(CreateScreenAdminPageVM pageVM)
        {
            Screen screen = new Screen();
            screen.ScreenName = pageVM.CreateScreenAdminPureVM.ScreenName;
            screen.Capacity = pageVM.CreateScreenAdminPureVM.Capacity;
            screen.PlaceID = pageVM.CreateScreenAdminPureVM.PlaceID;
            await _screenManager.AddAsync(screen);
            TempData["message"] = $"{screen.ScreenName} verisi eklendi";
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> GetScreen(int id)
        {
            Place place = await _placeManager.FindAsync(id);

            List<Screen> screens = await _screenManager.WhereAsync(x => x.Place.PlaceName == place.PlaceName);

            if (screens.Count == 0)
            {
                TempData["Message2"] = $"{place.PlaceName} Salon yoktur.";
                return RedirectToAction("Index", "Place");
            }

            List<GetScreenAdminPureVM> getScreenAdminPureVMs = screens.Select(getScreenAdminPureVMs => new GetScreenAdminPureVM
            {
                ID = getScreenAdminPureVMs.ID,
                ScreenName = getScreenAdminPureVMs.ScreenName,
                PlaceName = getScreenAdminPureVMs.Place.PlaceName,
                Status = getScreenAdminPureVMs.Status,
                Capacity = getScreenAdminPureVMs.Capacity,
            }).ToList();

            GetScreenAdminPageVM pageVM = new();
            pageVM.GetScreenAdminPureVMs = getScreenAdminPureVMs;
            return View(pageVM);
        }





        public async Task<IActionResult> UpdateScreen(int id)
        {
            Screen screen = await _screenManager.FindAsync(id);

            UpdateScreenAdminPureVM pureVM = new();
            pureVM.ScreenName = screen.ScreenName;
            pureVM.ID = screen.ID;
            pureVM.Capacity = screen.Capacity;
            pureVM.PlaceID = screen.Place.ID;

           

            List<Place> places = await _placeManager.GetActivesAsync();


            List<ScreenPlaceAdminPureVM> screenPureVMs = places.Select(screenPureVMs => new ScreenPlaceAdminPureVM
            {
                ID = screenPureVMs.ID,
                PlaceName = screenPureVMs.PlaceName
            }).ToList();
            UpdateScreenAdminPageVM updateScreenAdminPageVM = new UpdateScreenAdminPageVM();
            updateScreenAdminPageVM.ScreenPlaceAdminPureVMs = screenPureVMs;
            updateScreenAdminPageVM.UpdateScreenAdminPureVM = pureVM;
            return View(updateScreenAdminPageVM);


        }
        [HttpPost]
        public async Task<IActionResult> UpdateScreen(UpdateScreenAdminPageVM pageVM)
        {
            Screen screen = await _screenManager.FindAsync(pageVM.UpdateScreenAdminPureVM.ID);

            screen.ScreenName = pageVM.UpdateScreenAdminPureVM.ScreenName;
            screen.Capacity = pageVM.UpdateScreenAdminPureVM.Capacity;
            screen.PlaceID = pageVM.UpdateScreenAdminPureVM.PlaceID;
           
            await _screenManager.UpdateAsync(screen);
            TempData["message"] = $"{screen.ScreenName} verisi güncellendi";
            return RedirectToAction("Index");
        }




        public async Task<IActionResult> DeleteScreen(int id)
        {
            TempData["Message"] = await _screenManager.DeleteAsync(await _screenManager.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DestroyScreen(int id)
        {
            TempData["Message"] = await _screenManager.DestroyAsync(await _screenManager.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}
