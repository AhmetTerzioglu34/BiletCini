using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.COREMVC.Models;
using Project.COMMON.Tools;
using Project.COREMVC.Models.PageVms.AppUserPageVms;
using Project.ENTITIES.Entities;
using System.Diagnostics;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Project.BLL.Managers.Abstracts;
using Project.COREMVC.Models.PureVms.AppUserPureVms;
using Project.COREMVC.Models.PageVms.CategoryCityPlacePageVms;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Models.PureVms.CityPureVms;

namespace Project.COREMVC.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly RoleManager<AppRole> _roleManager;
        readonly IAppUserProfileManager _appUserProfileManager;
        readonly ICityManager _cityManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IAppUserProfileManager appUserProfileManager, ICityManager cityManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _appUserProfileManager = appUserProfileManager;
            _cityManager = cityManager;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<City> cities = await _cityManager.GetAllAsync();

            List<GetCityPureVm> cityPureVMs = cities.Select(cityPureVM => new GetCityPureVm
            {
                CityName = cityPureVM.CityName

            }).ToList();


            CategoryCityPlacePageVm categoryCityPlacePageVM = new()
            {
                GetCityPureVms = cityPureVMs
            };
            return View(categoryCityPlacePageVM);
        }


        public IActionResult SignIn(string returnUrl)
        {
            UserSignInPageVm userSignInPageVm = new()
            {
                UserSignInRequestModel = new()
                {
                    ReturnUrl = returnUrl
                }
            };
            return View(userSignInPageVm);
        }



        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInPageVm pageVm)
        {


            AppUser appUser = await _userManager.FindByNameAsync(pageVm.UserSignInRequestModel.UserName);


            if (appUser != null)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(appUser, pageVm.UserSignInRequestModel.Password, pageVm.UserSignInRequestModel.RememberMe, true);


                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(pageVm.UserSignInRequestModel.ReturnUrl))
                    {
                        return Redirect(pageVm.UserSignInRequestModel.ReturnUrl);
                    }


                    IList<string> roles = await _userManager.GetRolesAsync(appUser);

                    if (roles.Contains("Admin"))
                    {
                        //                   Action ismi  Controller ismi  Route Value's�
                        return RedirectToAction("Index", "User", new { Area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                   
                }
                else if (result.IsLockedOut)
                {
                    DateTimeOffset? lockOutEndDate = await _userManager.GetLockoutEndDateAsync(appUser);
                    ModelState.AddModelError("", $"Hesab�n�z {(lockOutEndDate.Value.UtcDateTime - DateTime.UtcNow).TotalSeconds:0.00} boyunca kilitlenmi�tir l�tfen bekleyiniz");
                }
                else if (result.IsNotAllowed) // Mail onayl� de�ildir
                {
                    return RedirectToAction("RedirectPanel");
                }
                else
                {
                    string message = "";
                    if (appUser != null)
                    {
                        int maxFailed = _userManager.Options.Lockout.MaxFailedAccessAttempts;
                        message = $" E�er {maxFailed - await _userManager.GetAccessFailedCountAsync(appUser)} kez daha yanl�� girerseniz hesab�n�z {_userManager.Options.Lockout.DefaultLockoutTimeSpan} s�reyle kapat�lacakt�r";
                    }
                    //else
                    //{
                    //    message = "Kullan�c� bulunamad�";
                    //}
                    ModelState.AddModelError("", message);
                }

            }
            else
            {
                TempData["Message"] = "Kullan�c� bulunamad�";
                
            }
            return View(pageVm);

        }


        public  IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterPageVm userRegisterPageVm, IFormFile formFile)
        {
            Guid specId = Guid.NewGuid();
            AppUser appUser = new()
            {
                UserName = userRegisterPageVm.UserRegisterReguestModel.UserName,
                Email = userRegisterPageVm.UserRegisterReguestModel.Email,
                ActivationCode = specId
            };
            IdentityResult result = await _userManager.CreateAsync(appUser, userRegisterPageVm.UserRegisterReguestModel.Password);

            if (result.Succeeded)
            {
                AppUserProfile userProfile = new()
                {
                    ID = appUser.Id,
                    FirstName = userRegisterPageVm.UserRegisterReguestModel.FirstName,
                    LastName = userRegisterPageVm.UserRegisterReguestModel.LastName,
                    PhoneNumber = userRegisterPageVm.UserRegisterReguestModel.PhoneNumber,
                    Country = userRegisterPageVm.UserRegisterReguestModel.Country,
                    City = userRegisterPageVm.UserRegisterReguestModel.City,
                    ProfilePhoto = userRegisterPageVm.UserRegisterReguestModel.ProfilePhoto
                };
                await _appUserProfileManager.AddAsync(userProfile);


                AppRole appRole = await _roleManager.FindByNameAsync("Member");
                if (appRole == null)
                {
                    await _roleManager.CreateAsync(new() { Name = "Member" });
                }
                await _userManager.AddToRoleAsync(appUser, "Member");

                string body = $"Hesab�n�z olu�turulmu�tur. L�tfen �yeli�inizi onaylamak i�in http://localhost:5015/Home/ConfirmEmail?specId={specId}&id={appUser.Id} linkine t�klay�n� iyi g�nler dileriz...";

                MailService.Send(userRegisterPageVm.UserRegisterReguestModel.Email, body: body);
                TempData["message"] = "Mailinizi kontrol ediniz";
                return RedirectToAction("RedirectPanel");
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }


            return View(userRegisterPageVm);
        }

        public async Task<IActionResult> ConfirmEmail(Guid specId, int id)
        {
            AppUser user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                TempData["message"] = "Kullan�c� bulunamad�";
                return RedirectToAction("RedirectPanel");
            }
            else if (user.ActivationCode == specId)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                TempData["message"] = "Emailiniz ba�ar�l� bir �ekilde onaylanm��t�r";
                return RedirectToAction("SignIn");
            }
            return RedirectToAction("Register");
        }

        public async Task< IActionResult> RedirectPanel()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Home");
        }

        public IActionResult AccessDenied()
        {

            return View();
        }



        public async Task<IActionResult> ForgotPassword(UserSignInPageVm model)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(model.Email);

            if (appUser != null)
            {
                Guid token = Guid.NewGuid();
                appUser.ActivationCode = token;
                await _userManager.UpdateAsync(appUser);

                string body = $"�ifre Yenileme i�in  http://localhost:5015/Home/ResetPassword?token={token}&id={appUser.Id} linkine t�klay�n�z";

                MailService.Send(model.Email, body: body);
                TempData["Message"] = "Mailinizi kontrol ediniz";
                return RedirectToAction("SignIn");
            }
            else
            {
                TempData["Message"] = "Bu Maile Ait Kullan�c� Bulunamad�";
                return RedirectToAction("SignIn");
            }
        }



        public async Task<IActionResult> ResetPassword(int id, Guid token)
        {
            AppUser user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                TempData["Message"] = "Kullan�c� bulunamad�";
                return RedirectToAction("SignIn");
            }
            else if (user.ActivationCode == token)
            {
                return View();
            }
            TempData["Message"] = "�ifre s�f�rlama i�lemi ba�ar�s�z oldu. L�tfen daha sonra tekrar deneyin.";
            return RedirectToAction("Signin");
        }

        [IgnoreAntiforgeryToken]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(UserPasswordPureVm pureVm)
        {
           
                AppUser user = await _userManager.FindByIdAsync(pureVm.Id.ToString());


                IdentityResult result1 = await _userManager.RemovePasswordAsync(user);
                IdentityResult result = await _userManager.AddPasswordAsync(user, pureVm.NewPassword);

                if (result.Succeeded)
                {
                    // �ifre s�f�rlama i�lemi ba�ar�l� olduysa
                    TempData["Message"] = "�ifreniz ba�ar�yla s�f�rland�.";
                    return RedirectToAction("SignIn"); // Kullan�c�y� giri� sayfas�na y�nlendir
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
            
           
        }
    }
}
