using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Areas.Admin.Models.PageVms.Movie;
using Project.COREMVC.Areas.Admin.Models.PureVms.Movie;
using Project.ENTITIES.Entities;

namespace Project.COREMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public class MovieController : Controller
    {
        readonly IMovieManager _movieManager;
        readonly IMovieCategoryManager _movieCategoryManager;
        readonly ICategoryManager _categoryManager;
        public MovieController(IMovieManager movieManager, IMovieCategoryManager movieCategoryManager, ICategoryManager categoryManager)
        {
            _movieManager = movieManager;
            _movieCategoryManager = movieCategoryManager;
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Movie> movies = await _movieManager.GetAllAsync();

            List<GetMoviePureVm> moviePureVMs = movies.Select(moviePureVMs => new GetMoviePureVm
            {
                ID = moviePureVMs.ID,
                MovieName = moviePureVMs.MovieName,
                Description = moviePureVMs.Description,
                VisionDate = moviePureVMs.VisionDate,
                StartingDate = moviePureVMs.StartingDate,
                EndDate = moviePureVMs.EndDate,
                Time = moviePureVMs.Time,
                ImagePath1 = moviePureVMs.ImagePath1,
                ImagePath2 = moviePureVMs.ImagePath2,
                Status = moviePureVMs.Status

            }).ToList();


            GetMoviePageVm getMoviePage = new GetMoviePageVm();
            getMoviePage.GetMoviePureVms = moviePureVMs;
            return View(getMoviePage);
        }





        [HttpGet]
        public IActionResult CreateMovie()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMoviePageVm pageVm , IFormFile formFile1 , IFormFile formFile2)
        {
            Guid uniqueName = Guid.NewGuid();
            string extension = Path.GetExtension(formFile1.FileName); //dosyanın uzantısını ele gecirdik...
            pageVm.CreateMoviePureVm.ImagePath1 = $"/images/{uniqueName}{extension}";

            string path = $"{Directory.GetCurrentDirectory()}/wwwroot{pageVm.CreateMoviePureVm.ImagePath1}";
            FileStream stream = new(path, FileMode.Create);
            formFile1.CopyTo(stream);

            Guid uniqueName2 = Guid.NewGuid();
            string extension2 = Path.GetExtension(formFile2.FileName); //dosyanın uzantısını ele gecirdik...
            pageVm.CreateMoviePureVm.ImagePath2 = $"/images/{uniqueName2}{extension2}";

            string path2 = $"{Directory.GetCurrentDirectory()}/wwwroot{pageVm.CreateMoviePureVm.ImagePath2}";
            FileStream stream2 = new(path2, FileMode.Create);
            formFile2.CopyTo(stream2);

            Movie movie = new Movie()
            {
                MovieName = pageVm.CreateMoviePureVm.Name,
                Description = pageVm.CreateMoviePureVm.Description,
                EndDate = pageVm.CreateMoviePureVm.EndDate,
                ImagePath1 = pageVm.CreateMoviePureVm.ImagePath1,
                ImagePath2 = pageVm.CreateMoviePureVm.ImagePath2,
                VisionDate = pageVm.CreateMoviePureVm.VisionDate,
                StartingDate = pageVm.CreateMoviePureVm.StartingDate,
                Time = pageVm.CreateMoviePureVm.Time
            };
            await _movieManager.AddAsync(movie);
            TempData["message"] = $"{movie.MovieName} isimli film eklenmiştir";
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> AssignCategory(int id)
        {
            Movie movie = await _movieManager.FindAsync(id);

            List<MovieCategory> movieCategories = await _movieCategoryManager.WhereAsync(x => x.MovieID == id);

            List<Category> categories = await _categoryManager.GetAllAsync();

            List<string> categoryNames = categories.Where(c => movieCategories.Any(mc => mc.CategoryID == c.ID)).Select(c => c.CategoryName).ToList();
            List<GetMovieCategoryPureVm> getMovieCategories = new List<GetMovieCategoryPureVm>();

            foreach (Category item in categories)
            {
                getMovieCategories.Add(new()
                {
                    CategoryID = item.ID,
                    CategoryName = item.CategoryName,
                    Checked = categoryNames.Contains(item.CategoryName)
                });
            }

            GetMovieCategoryPageVm pageVM = new GetMovieCategoryPageVm();
            pageVM.GetMovieCategoryPureVms = getMovieCategories;
            pageVM.MovieID = id;

            TempData["Message"] = $" {movie.MovieName} isimli film'in kategorileri";
            return View(pageVM);
        }

        [HttpPost]
        public async Task<IActionResult> AssignCategory(GetMovieCategoryPageVm model)
        {
            Movie movie = await _movieManager.FindAsync(model.MovieID);

            List<MovieCategory> movieCategories = await _movieCategoryManager.WhereAsync(x => x.MovieID == model.MovieID);

            List<Category> categories = await _categoryManager.GetAllAsync();

            List<string> categoryNames = categories.Where(c => movieCategories.Any(mc => mc.CategoryID == c.ID)).Select(c => c.CategoryName).ToList();

            foreach (GetMovieCategoryPureVm category in model.GetMovieCategoryPureVms)
            {
                if (category.Checked && !categoryNames.Contains(category.CategoryName))
                {
                    MovieCategory AddMovieCategory = new();
                    AddMovieCategory.MovieID = model.MovieID;
                    AddMovieCategory.CategoryID = category.CategoryID;
                    await _movieCategoryManager.AddAsync(AddMovieCategory);       
                }
                else if (!category.Checked && categoryNames.Contains(category.CategoryName))
                {
                    MovieCategory RemoveMovieCategory = await _movieCategoryManager.FirstOrDefaultAsync(x => x.MovieID == movie.ID && x.CategoryID == category.CategoryID);
                    await _movieCategoryManager.DeleteAsync(RemoveMovieCategory);
                    await _movieCategoryManager.DestroyAsync(RemoveMovieCategory);
                }
               
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> UpdateMovie(int id)
        {
            Movie movie = await _movieManager.FindAsync(id);
            UpdateMoviePureVm updateMovie = new()
            {
                ID = id,
                MovieName = movie.MovieName,
                Description = movie.Description,
                StartingDate = movie.StartingDate,
                EndDate = movie.EndDate,
                Time = movie.Time,
                VisionDate = movie.VisionDate,
                ImagePath1 = movie.ImagePath1,
                ImagePath2 = movie.ImagePath2
            };
            UpdateMoviePageVm updateMoviePageVm = new();
            updateMoviePageVm.UpdateMoviePureVm = updateMovie;
            return View(updateMoviePageVm);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateMovie(UpdateMoviePageVm model , IFormFile formFile1 , IFormFile formFile2)
        {
            Movie movie = await _movieManager.FindAsync(model.UpdateMoviePureVm.ID);
            if (formFile1 != null)
            {
                Guid uniqueName = Guid.NewGuid();
                string extension = Path.GetExtension(formFile1.FileName); //dosyanın uzantısını ele gecirdik...
                model.UpdateMoviePureVm.ImagePath1 = $"/images/{uniqueName}{extension}";

                string path = $"{Directory.GetCurrentDirectory()}/wwwroot{model.UpdateMoviePureVm.ImagePath1}";
                FileStream stream = new(path, FileMode.Create);
                formFile1.CopyTo(stream);
            }
            if (formFile2 != null)
            {
                Guid uniqueName2 = Guid.NewGuid();
                string extension2 = Path.GetExtension(formFile2.FileName); //dosyanın uzantısını ele gecirdik...
                model.UpdateMoviePureVm.ImagePath2 = $"/images/{uniqueName2}{extension2}";

                string path2 = $"{Directory.GetCurrentDirectory()}/wwwroot{model.UpdateMoviePureVm.ImagePath2}";
                FileStream stream2 = new(path2, FileMode.Create);
                formFile2.CopyTo(stream2);
            }


            movie.MovieName = model.UpdateMoviePureVm.MovieName;
            movie.Description = model.UpdateMoviePureVm.Description;
            movie.Time = model.UpdateMoviePureVm.Time;
            movie.StartingDate = model.UpdateMoviePureVm.StartingDate;
            movie.EndDate = model.UpdateMoviePureVm.EndDate;
            movie.VisionDate = model.UpdateMoviePureVm.VisionDate;
            movie.ImagePath1 = model.UpdateMoviePureVm.ImagePath1;
            movie.ImagePath2 = model.UpdateMoviePureVm.ImagePath2;
            await _movieManager.UpdateAsync(movie);
            TempData["Message"] = $"{movie.MovieName} verisi Güncelledi";

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> DeleteMovie(int id)
        {
            TempData["Message"] = await _movieManager.DeleteAsync(await _movieManager.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DestroyMovie(int id)
        {
            TempData["Message"] = await _movieManager.DestroyAsync(await _movieManager.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}
