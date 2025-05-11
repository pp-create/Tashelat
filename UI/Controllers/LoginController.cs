using BLL.Interface;
using DAL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly Iusers iusers;

        public LoginController(Iusers _Iusers)
        {
            iusers = _Iusers;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserVM mode)
        {
            try
            {
                var userId = iusers.login(mode);
                var data = iusers.GetById(userId.Value);
                HttpContext.Session.SetString("Roleid", data.RoleId.ToString());
                var Roleid = HttpContext.Session.GetString("Roleid");

                if (userId.HasValue)
                {
                    // Login successful, you can set session or authentication token here
                    // For example, setting user ID in session:
                    HttpContext.Session.SetString("UserId", userId.Value.ToString());

                    // Redirect to a different page after successful login
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Login failed, show an error message
                    // Set a property on ViewBag
                    ViewBag.contact = "اسم المستخدم أو كلمة المرور غير صحيحة.";
                    return View(mode); // Return to the login view with the model
                }

            }
            catch (Exception)
            {   // Set a property on ViewBag
                ViewBag.contact = "اسم المستخدم أو كلمة المرور غير صحيحة.";
                return View(mode); // Return to the login view with the model
            }
          
        }
        public IActionResult Logout()
        {
            // Clear the session on logout
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }

}
