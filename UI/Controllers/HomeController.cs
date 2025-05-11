using BLL.Interface;
using BLL.Servies;

using DAL;
using DAL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.ComponentModel;
using System.Diagnostics;
using UI.Models;


namespace UI.Controllers
{
    [TimeoutFilter]
    public class HomeController : Controller
    {
        private readonly IImportRep repository;
        private readonly IRequest request1;
        private readonly Icontect contectdata;
        private readonly IServucesVM export11;
        private readonly IQuestions export111;
        private readonly IHomepage export1;  
        private readonly IAbout AbouTOPERTAION;
        private readonly IRepliescostomercs repliescostomercs;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IImportRep repository, IRequest _request, Icontect _contect,IServucesVM _export1, IQuestions _export11, IAbout _About, IRepliescostomercs _repliescostomercs, IHomepage _export,ILogger<HomeController> logger)
        {
            this.repository = repository;
            request1 = _request;
            contectdata = _contect;
            export11 = _export1;
            export111 = _export11;
            export1 = _export; AbouTOPERTAION = _About;
            this.repliescostomercs = _repliescostomercs;
            _logger = logger;
           
        }
        public IActionResult test()
        {

            return View();
        }
        public IActionResult Index()
        {
           
            return View();
        }
        #region Homepage
        [HttpGet]
        public IActionResult export()
        {
            return View();
        }
        [HttpGet]
        public IActionResult getexport()
        {
            var data = export1.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var data = export1.Delete(id);
            return RedirectToAction("getexport");
        }
        [HttpPost]
        public async Task<IActionResult> upexport(filebbookViewModel model)
        {
            bool data1 = export1.Edit(model);
            return RedirectToAction("getexport");
        }
        [HttpGet]
        public IActionResult editeexport(Guid id)
        {
            var data = export1.GetById(id);
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> export(HomepageViewModel model, List<Data> files)
        {
            int data1 = export1.Add(model, files);
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
        public IActionResult getAbout()
        {
            var data = AbouTOPERTAION.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult DeleteAbout(Guid id)
        {
            var data = AbouTOPERTAION.Delete(id);
            return RedirectToAction("getAbout");
        }
        [HttpPost]
        public async Task<IActionResult> upeAbout(AboutVM model)
        {
            bool data1 = AbouTOPERTAION.Edit(model);
            return RedirectToAction("getAbout");
            
        }
        [HttpGet]
        public IActionResult editeAbout(Guid id)
        {
            var data = AbouTOPERTAION.GetById(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> About(AboutVM model)
        {
            int data1 = AbouTOPERTAION.Add(model);
            return RedirectToAction("getAbout");
        }
        #endregion
        #region import
        [HttpGet]
        public IActionResult Import()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetImport()
        {
            var data = repository.GetAll();
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Import(ImportViewModel model)
        {
            int data1 = repository.Add(model);
            return View();
        }
        [HttpGet]
        public IActionResult UpdateImport(Guid id)
        {
            var data = repository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateImport(ImportViewModel model)
        {
            bool data1 = repository.Edit(model);
            if (data1 == true)
            {
                return RedirectToAction("GetImport");
            }
            return View();
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
        #region Repliescostomercs
        [HttpGet]
        public IActionResult Repliescostomercs()
        {
            var data = repliescostomercs.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult ADDRepliescostomercs()
        {
           
            return View();
        }
        [HttpGet]
        public IActionResult DeleteRepliescostomercs(Guid id)
        {
            var data = repliescostomercs.Delete(id);
            return RedirectToAction("Repliescostomercs");
        }
        [HttpPost]
        public async Task<IActionResult> upexportRepliescostomercs(RepliescostomerVm model)
        {
            int data1 = repliescostomercs.Add(model);
            return RedirectToAction("Repliescostomercs");
        }
        #endregion #region side
        #region services
        [HttpGet]
        public IActionResult side()
        {
            var data = export11.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult ADDside()
        {
           
            return View();
        }
        [HttpGet]
        public IActionResult Deleteside(Guid id)
        {
            var data = export11.Delete(id);
            return RedirectToAction("side");
        }
        [HttpPost]
        public async Task<IActionResult> upexportside(ServicesVM model)
        {
            int data1 = export11.Add(model);
            return RedirectToAction("side");
        }
        #endregion
        #region circle
        [HttpGet]
        public IActionResult circle()
        {
            var data = export111.GetAll();

            return View(data);
        }
        [HttpGet]
        public IActionResult ADDcircle()
        {
            ViewBag.data = export11.GetAll();

            return View();
        }
        [HttpGet]
        public IActionResult Deletecircle(Guid id)
        {
            var data = export111.Delete(id);
            return RedirectToAction("circle");
        }
        [HttpPost]
        public async Task<IActionResult> upexporcircle(QuestionsVM model)
        {
            int data1 = export111.Add(model);
            return RedirectToAction("circle");
        }
        #endregion
        #region contect
        [HttpGet]
        public IActionResult contect()
        {
            return View();
        }
        [HttpGet]
        public IActionResult getcontect()
        {
            var data = contectdata.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Deletecontect(Guid id)
        {
            var data = contectdata.Delete(id);
            return RedirectToAction("getcontect");
        }
        [HttpPost]
        public async Task<IActionResult> upecontect(ContactVM model)
        {
            bool data1 = contectdata.Edit(model);
            return RedirectToAction("getcontect");

        }
        [HttpGet]
        public IActionResult editecontect(Guid id)
        {
            var data = contectdata.GetById(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> contect(ContactVM model)
        {
            int data1 = contectdata.Add(model);
            return RedirectToAction("getcontect");
        }
        #endregion
        #region request
        [HttpGet]
        public IActionResult request()
        {
            
            return View();
        }  [HttpGet]
        public IActionResult requestcustmer()
        {
            
            return View();
        }  [HttpGet]
        public IActionResult massage()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult LoadCategoriesGrid1()
        {
           var data = request1.GetAll();
            return Json(new { data = data });
        }  [HttpPost]
        public IActionResult LoadCategoriesGrid()
        {
           var data = request1.GetAllrequet();
            return Json(new { data = data });
        }
       public IActionResult DownloadExcel()
       {
           // Set license context
           ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // or LicenseContext.Commercial

           // Fetch data
           var data = request1.GetAllrequet();

           using (var package = new ExcelPackage())
           {
               // Add a new worksheet to the empty workbook
               var worksheet = package.Workbook.Worksheets.Add("Requests");

               // Add headers
               worksheet.Cells[1, 1].Value = "اسم";
               worksheet.Cells[1, 2].Value = "رقم التعريفي ";
               worksheet.Cells[1, 3].Value = "التلفون";
               worksheet.Cells[1, 4].Value = "النوع";
               worksheet.Cells[1, 5].Value = "مقيم";
               worksheet.Cells[1, 6].Value = "التاريخ";
               worksheet.Cells[1, 7].Value = "الحاله";
            

               // Populate data rows
               int row = 2;
               foreach (var item in data)
               {
                   worksheet.Cells[row, 1].Value = item.name;         // Adjust based on property names
                   worksheet.Cells[row, 2].Value = item.idcustomer;
                   worksheet.Cells[row, 3].Value = item.phone;
                   worksheet.Cells[row, 4].Value = item.type;
                   worksheet.Cells[row, 5].Value = item.livesin;
                   worksheet.Cells[row, 6].Value = item.CreationDate.ToString("yyyy-MM-dd");
                   worksheet.Cells[row, 7].Value = item.Status.ToString();
         
                   row++;
               }

               // Auto-fit columns
               worksheet.Cells.AutoFitColumns();

               // Save to memory stream
               using (var stream = new MemoryStream())
               {
                   package.SaveAs(stream);
                   stream.Position = 0; // Reset stream position

                   // Return the Excel file
                   return File(
                       stream.ToArray(),
                       "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                       "RequestsReport.xlsx"
                   );
               }
           }
       }
        public IActionResult LoadCategoriesGriduser()
        {
            var  UserId  = HttpContext.Session.GetString("UserId");
            
           var data = request1.GetAllrequet(UserId.ToString());
            return Json(new { data = data });
        }
        [HttpGet]
        public IActionResult Deleterequest(int id)
        {
            var isDeleted = request1.Deleterequet(id);
            
            if (isDeleted)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "فشل في حذف الفئة." });
        } [HttpGet]
        public IActionResult Deletemassage(Guid id)
        {
            var isDeleted = request1.Deletemassage(id);
            
            if (isDeleted)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "فشل في حذف الفئة." });
        }
   
    
        
        [HttpPost]
        public async Task<IActionResult> uperequest(RequestVM model)
        {
            bool data1 = request1.Edit(model);
            return RedirectToAction("request");

        }
        [HttpGet]
        public IActionResult editerequest(int id)
        {
            var data = request1.GetById(id);
            return View(data);
        }

        #endregion
    }

}
