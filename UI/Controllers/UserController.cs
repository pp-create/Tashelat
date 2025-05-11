using BLL.Interface;
using DAL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [TimeoutFilter]
    public class UserController : Controller
    {
        private readonly IImportRep repository;
        private readonly Iusers export1;


        public UserController(IImportRep repository, Iusers _export, ILogger<HomeController> logger)
        {
            this.repository = repository;
            export1 = _export;
            
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> adduser(UserVM model)
        {
            if (model.RoleId == 1)
            {
                model.RoleName = "مدير";
            }
            else
            {
                model.RoleName = "موطف";
            }
           

            int data1 = export1.Add(model);
            return RedirectToAction("Getuser");
        }
        [HttpGet]
        public IActionResult Getuser()
        {
          var daata =  export1.GetAll();
            return View(daata);
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var data = export1.Delete(id);
            return RedirectToAction("Getuser");
        }


    }
}
