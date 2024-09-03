using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Areas.Admin.Models.PageVms.City;
using Project.COREMVC.Areas.Admin.Models.PageVms.Place;
using Project.COREMVC.Areas.Admin.Models.PureVms.City;
using Project.COREMVC.Areas.Admin.Models.PureVms.Place;
using Project.ENTITIES.Entities;

namespace Project.COREMVC.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public class PlaceController : Controller
    {
        readonly IPlaceManager _placeManager;
        readonly ICityManager _cityManager;

        public PlaceController(IPlaceManager placeManager, ICityManager cityManager)
        {
            _placeManager = placeManager;
            _cityManager = cityManager;
        }
        public async Task<IActionResult> Index()
        {
            List<Place> places = await _placeManager.GetAllAsync();

            List<GetPlaceAdminPureVM> getPlaceAdminPureVM = places.Select(getPlaceAdminPureVM => new GetPlaceAdminPureVM
            {
                ID = getPlaceAdminPureVM.ID,
                PlaceName = getPlaceAdminPureVM.PlaceName,
                CityName = getPlaceAdminPureVM.City.CityName,
                Status = getPlaceAdminPureVM.Status
            }).ToList();

            GetPlaceAdminPageVM getPlaceAdminPageVM = new GetPlaceAdminPageVM();
            getPlaceAdminPageVM.GetPlaceAdminPureVMs = getPlaceAdminPureVM;




            return View(getPlaceAdminPageVM);


        }

        public async Task<IActionResult> CreatePlace()
        {
            List<City> city = await _cityManager.GetActivesAsync();
            List<PlaceCityAdminPureVM> pureVMs = city.Select(pureVMs => new PlaceCityAdminPureVM 
            {
                ID = pureVMs.ID,
                CityName = pureVMs.CityName
            }).ToList();

            CreatePlaceAdminPageVM createPlaceAdminPageVM = new CreatePlaceAdminPageVM();
            createPlaceAdminPageVM.PlaceCityPureVMs = pureVMs;


            return View(createPlaceAdminPageVM);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlace(CreatePlaceAdminPageVM pageVM)
        {
            Place place = new Place();
            place.PlaceName = pageVM.CreatePlaceAdminPureVM.PlaceName;
            place.CityID = pageVM.CreatePlaceAdminPureVM.CityID;
            await _placeManager.AddAsync(place);
            TempData["message"] = $"{place.PlaceName} verisi eklendi";
            return RedirectToAction("Index");

          
        }

        public async Task<IActionResult> UpdatePlace(int id)
        {
            Place place  = await _placeManager.FindAsync(id);

            List<City> city = await _cityManager.GetActivesAsync();
            List<PlaceCityAdminPureVM> pureVMs = city.Select(pureVMs => new PlaceCityAdminPureVM
            {
                ID = pureVMs.ID,
                CityName = pureVMs.CityName
            }).ToList();
            UpdatePlaceAdminPureVM updatePlaceAdminPureVM = new UpdatePlaceAdminPureVM();
            updatePlaceAdminPureVM.ID = place.ID;
            updatePlaceAdminPureVM.PlaceName = place.PlaceName;
            updatePlaceAdminPureVM.CityID = place.City.ID;


            UpdatePlaceAdminPageVM updatePlaceAdminPage = new UpdatePlaceAdminPageVM();
            updatePlaceAdminPage.PlaceAdminPureVMs = pureVMs;
            updatePlaceAdminPage.UpdatePlaceAdminPureVM = updatePlaceAdminPureVM;
            return View(updatePlaceAdminPage);

        }
        [HttpPost]
        public async Task<IActionResult> UpdatePlace(UpdatePlaceAdminPageVM pageVM)
        {
            Place place = await _placeManager.FindAsync(pageVM.UpdatePlaceAdminPureVM.ID);
            place.PlaceName = pageVM.UpdatePlaceAdminPureVM.PlaceName;
            place.CityID = pageVM.UpdatePlaceAdminPureVM.CityID;
            await _placeManager.UpdateAsync(place);
            TempData["message"] = $"{place.PlaceName} verisi güncellendi";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePlace(int id)
        {
            TempData["Message"] = await _placeManager.DeleteAsync(await _placeManager.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DestroyPlace(int id)
        {
            TempData["Message"] = await _placeManager.DestroyAsync(await _placeManager.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}
