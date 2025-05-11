using BLL.Interface;
using BLL.Servies;
using DAL;
using DAL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class Viewcustomer : Controller
    {
        private readonly IImportRep repository;
        private readonly IRequest request;
        private readonly Icontect contectdata;
        private readonly IServucesVM export11;
        private readonly IQuestions export111;
        private readonly IHomepage export1;
        private readonly IAbout AbouTOPERTAION;
        private readonly IRepliescostomercs repliescostomercs;
        private readonly ILogger<Viewcustomer> _logger;

        public Viewcustomer(IImportRep repository, IRequest _request, Icontect _contect, IServucesVM _export1, IQuestions _export11, IAbout _About, IRepliescostomercs _repliescostomercs, IHomepage _export, ILogger<Viewcustomer> logger)
        {
            this.repository = repository;
            request = _request;
            contectdata = _contect;
            export11 = _export1;
            export111 = _export11;
            export1 = _export; AbouTOPERTAION = _About;
            this.repliescostomercs = _repliescostomercs;
            _logger = logger;

        }
     
        public IActionResult Index()
        {
            ViewBag.data= export111.GetAll();
            return View();
        }
        #region Homepage
       
        [HttpGet]
        public IActionResult getexport()
        {
            var data = export1.GetAll().FirstOrDefault(); ;
            return Json(data);
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var data = export1.Delete(id);
            return RedirectToAction("getexport");
        }
        
       
        #endregion
        #region About
        
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult request1()
        {
            return View();
        }  [HttpGet]
        public IActionResult viewservice(string contect,string sidename )
        {
            ViewBag.contect = contect;    ViewBag.sidename = sidename;
            return View();
        }[HttpGet]
        public IActionResult getAbout()
        {
            var data = AbouTOPERTAION.GetAll().FirstOrDefault();
            return Json(data);
        }[HttpGet]
        public IActionResult sreachrequest(string id)
        {
            var data = request.screachrequet(id);
            return Json(data);
        }
        [HttpGet]
        public IActionResult DeleteAbout(Guid id)
        {
            var data = AbouTOPERTAION.Delete(id);
            return RedirectToAction("getAbout");
        }
       
        [HttpGet]
        public IActionResult editeAbout(Guid id)
        {
            var data = AbouTOPERTAION.GetById(id);
            return Json(data);
        }
      
        #endregion
        #region import
      

        [HttpGet]
        public IActionResult GetImport()
        {
            var data = repository.GetAll().FirstOrDefault();
            return Json(data);
        }
       
        [HttpGet]
        public IActionResult UpdateImport(Guid id)
        {
            var data = repository.GetById(id);
            return Json(data);
        }
       
        [HttpPost]
        public IActionResult DeleteImports(Guid id)
        {
            var data = repository.Delete(id);
            return Json(data);
        }
        [HttpPost]
        public IActionResult Getcile(string Name)
        {
            var data = export111.GetById(Name);
            return Json(data);
        }

       

       
        #endregion
        #region Repliescostomercs
        [HttpGet]
        public IActionResult Repliescostomercs()
        {
            var data = repliescostomercs.GetAll();
            return Json(data);
        }
        [HttpGet]
      
      
        public IActionResult DeleteRepliescostomercs(Guid id)
        {
            var data = repliescostomercs.Delete(id);
            return RedirectToAction("Repliescostomercs");
        }
       
        #endregion #region side
        #region services
        [HttpGet]
        public IActionResult side()
        {
            var data = export11.GetAll();
            return Json(data);
        }
       
        [HttpGet]
        public IActionResult Deleteside(Guid id)
        {
            var data = export11.Delete(id);
            return RedirectToAction("side");
        }
      
        #endregion
        #region circle
        [HttpGet]
        public IActionResult circle()
        {
            var data = export111.GetAll();

            return Json(data);
        }
       
        [HttpGet]
        public IActionResult Deletecircle(Guid id)
        {
            var data = export111.Delete(id);
            return RedirectToAction("circle");
        }
      
        #endregion
        #region contect
        [HttpGet]
      
        [HttpGet]
        public IActionResult getcontect()
        {
            var data = contectdata.GetAll().FirstOrDefault();
            return Json(data);
        }
        [HttpGet]
        public IActionResult Deletecontect(Guid id)
        {
            var data = contectdata.Delete(id);
            return RedirectToAction("getcontect");
        }
       
        [HttpGet]
        public IActionResult editecontect(Guid id)
        {
            var data = contectdata.GetById(id);
            return Json(data);
        }

        #endregion
        #region requestes
        [HttpPost]
        public async Task<IActionResult> Addrequest(RequestVM model)
        {
            
            try
            {model.CreationDate = DateTime.Now;
                int data1 = request.Addrequest(model);// Assuming async operation
                if (data1==1)
                {
                    ViewBag.ShowSuccess = true;
                }
                else
                {
                    ViewBag.ShowError = true;
                }
            }
            catch (Exception)
            {
                ViewBag.ShowError = true;
            }

            return View("Index");
        } [HttpPost]
        public async Task<IActionResult> Addrmassage(MassagerUesrsVM model)
        {
            try
            {
                int isSuccess =  request.Addmassage(model); // Assuming async operation
                if (isSuccess==1)
                {
                    ViewBag.ShowSuccess = true;
                }
                else
                {
                    ViewBag.ShowError = true;
                }
            }
            catch (Exception)
            {
                ViewBag.ShowError = true;
            }

            return View("Index"); // Adjust to return to the correct view
        }

        #endregion
    }
}
