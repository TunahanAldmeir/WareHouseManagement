using BusinesLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Packaging.Signing;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks.Sources;
using System.Xml.Linq;
using WareHouseManagement.Models;
using Microsoft.Extensions.Hosting;
using DevExpress.XtraReports.UI;

namespace WareHouseManagement.Controllers
{
    
    public class HomeController : Controller
	{
        private IWebHostEnvironment _hostEnvironment;
        private readonly ILogger<HomeController> _logger;
        public int _id;
        UserManager usm = new UserManager(new EfUserRepository());
        UserTypeManager utypem = new UserTypeManager(new EfUserTypeRepository());

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment environment)
		{
            _hostEnvironment = environment;
            _logger = logger;
		}
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
		{
            return View();
		}
		[HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
			var values = usm.GetAlluser();
            return DataSourceLoader.Load(values, loadOptions);
        }
        [HttpPost]
        public IActionResult Post(string values)
        {
            var newEmployee = new User();
            JsonConvert.PopulateObject(values, newEmployee);

            if (!TryValidateModel(newEmployee))
                return Error();
            usm.Adduser(newEmployee);   
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var employee = usm.GetuserById(key);
            JsonConvert.PopulateObject(values, employee);

            if (!TryValidateModel(employee))
                return Error();
            usm.Updateuser(employee);
            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var employee =usm.GetuserById(key);
            usm.Deleteuser(employee);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Privacy(int id)
		{
			ViewData["id"] = id;
			return View();
        }
       
        [HttpGet]
		public object GetType(DataSourceLoadOptions loadOptions,int id)
		{
			var values = utypem.GetAllUserTypeById(id);
			return DataSourceLoader.Load(values, loadOptions);
		}
        [HttpPost]
        public IActionResult PostType(string values)
        {
            var newEmployee = new UserType();
            JsonConvert.PopulateObject(values, newEmployee);

            //if (!TryValidateModel(newEmployee))
            //    return Error();
            utypem.AddUserType(newEmployee);
            return Ok();
        }
        [HttpPut]
        public IActionResult PutType(int key, string values)
        {
            var employee = utypem.GetUserTypeById(key);
            JsonConvert.PopulateObject(values, employee);

            //if (!TryValidateModel(employee))
            //    return Error();
            utypem.UpdateUserType(employee);
            return Ok();
        }
        [HttpDelete]
        public void DeleteType(int key)
        {
            var employee = utypem.GetUserTypeById(key);
            utypem.DeleteUserType(employee);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Acces");
        }
        [HttpPost]
        public IActionResult PostPhoto()
        {
            IFormFileCollection files = Request.Form.Files;
            string uniqueFileName = "";

            if (files.Count > 0)
            {
                var file = files[0];
                uniqueFileName = string.Format("{0}{1}", Guid.NewGuid(), Path.GetExtension(file.FileName));

                try
                {
                    var path = Path.Combine(_hostEnvironment.WebRootPath, "ImageFiles/" + uniqueFileName);

                    using (Stream fileStream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }
                catch
                {
                    return BadRequest("Failed to save a file on the server");
                }
            }

            return Ok(uniqueFileName);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
        public IActionResult TestReport()
        {
            var rprpath = "WareHouseManagement.Reports.TestReport";
            XtraReport report =(XtraReport)Activator.CreateInstance(Type.GetType(rprpath));
            ViewBag.ReportName = report;
            ViewBag.ReportHeader = "Test Report";
            return View("/Views/ReportViewer.cshtml");

        }
	}
}