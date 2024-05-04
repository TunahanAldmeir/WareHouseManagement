using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using BusinesLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using System.Data;
using Microsoft.AspNetCore.Mvc.Routing;

namespace WareHouseManagement.Controllers
{
    public class AccesController : Controller
    {
        UserManager bm = new UserManager(new EfUserRepository());
        public IActionResult Index()
        {
            ClaimsPrincipal principal = HttpContext.User;
            if (principal.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            User user2 = bm.logUser(user);
            if (user2 != null && user2.Status==true)
            {
                List<string> userroles=new List<string>();
                foreach (var role in user2.UserTypes)
                {
                    userroles.Add(role.TypeName); 
                }
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user2.Id.ToString()),
                    new Claim("OtherProperties","Example Role"),
                };
                foreach ( string role in userroles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                ClaimsIdentity identity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = false,
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity), properties);
                foreach (var item in userroles)
                {
                    if (item=="SaleMan")
                    {
                        return RedirectToAction("Index", "Sales");
                    }
                }
                return RedirectToAction("WareHouse", "WareHouse");

            }
            ViewData["ValidateMessage"] = "Kullanıcı Bulunamadı";
            return View();
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
