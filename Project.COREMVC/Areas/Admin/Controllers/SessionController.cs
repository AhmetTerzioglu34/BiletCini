using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Managers.Abstracts;
using Project.BLL.Managers.Concretes;
using Project.COREMVC.Areas.Admin.Models.PageVms.Screen;
using Project.COREMVC.Areas.Admin.Models.PageVms.Session;
using Project.COREMVC.Areas.Admin.Models.PureVms.Screen;
using Project.COREMVC.Areas.Admin.Models.PureVms.Session;
using Project.ENTITIES.Entities;

namespace Project.COREMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [AutoValidateAntiforgeryToken]
    public class SessionController : Controller
    {
        readonly ISessionManager _sessionManager;

        public SessionController( ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }
        public async Task<IActionResult> Index()
        {
            List<Session> sessions = await _sessionManager.GetAllAsync();
            List<GetSessionAdminPureVM> pureVMs = sessions.Select(pureVMs => new GetSessionAdminPureVM
            {
                ID = pureVMs.ID,
                ShowTime = pureVMs.ShowTime,
                Price = pureVMs.Price,
                Status = pureVMs.Status
            }).ToList();
            GetSessionAdminPageVM getSessionAdminPageVM = new GetSessionAdminPageVM();
            getSessionAdminPageVM.GetSessionAdminPureVMs = pureVMs;


            return View(getSessionAdminPageVM);



        }


        public async Task<IActionResult> CreateSession()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSession(CreateSessionAdminPageVM pageVM)
        {
            Session session  = new Session();   
            session.ShowTime = pageVM.CreateSessionAdminPureVM.ShowTime;    
            session.Price = pageVM.CreateSessionAdminPureVM.Price;
            await _sessionManager.AddAsync(session);

            TempData["message"] = $"{session.ShowTime} saati eklendi";
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> UpdateSession(int id)
        {
            Session session = await _sessionManager.FindAsync(id);

            UpdateSessionAdminPureVM pureVM = new();
            pureVM.ShowTime = session.ShowTime;
            pureVM.Price = session.Price;
            pureVM.ID = session.ID;

            UpdateSessionAdminPageVM updateSessionAdminPageVM = new UpdateSessionAdminPageVM();
            updateSessionAdminPageVM.UpdateSessionAdminPureVM = pureVM;
            return View(updateSessionAdminPageVM);



        }

        [HttpPost]
        public async Task<IActionResult> UpdateSession(UpdateSessionAdminPageVM pageVM)
        {
            Session session = await _sessionManager.FindAsync(pageVM.UpdateSessionAdminPureVM.ID);

            session.ShowTime = pageVM.UpdateSessionAdminPureVM.ShowTime;
            session.Price = pageVM.UpdateSessionAdminPureVM.Price;
            await _sessionManager.UpdateAsync(session);
            TempData["Message"] = $"{session.ShowTime} saati Güncelledi";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSession(int id)
        {
            TempData["Message"] = await _sessionManager.DeleteAsync(await _sessionManager.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DestroySession(int id)
        {
            TempData["Message"] = await _sessionManager.DestroyAsync(await _sessionManager.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}
