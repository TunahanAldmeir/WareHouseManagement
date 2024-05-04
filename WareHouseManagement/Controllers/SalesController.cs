using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using EntityLayer.Concrete;
using System.Security.Claims;
using DataAccessLayer.EntityFrameWork;
using BusinesLayer.Concrete;
using System.Diagnostics;
using WareHouseManagement.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;

namespace WareHouseManagement.Controllers
{
    [Authorize(Roles = "Admin,SaleMan")]
    public class SalesController : Controller
    {
        UserManager bm = new UserManager(new EfUserRepository());
        CostumerManager cmm= new CostumerManager(new EfCostumerRepository());
        public IActionResult Index()
        {
            string userıd = null;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            userıd = userIdClaim.Value;
            var values = bm.GetuserById(Convert.ToInt32(userıd));
            return View(values);
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            string userıd = null;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            userıd = userIdClaim.Value;
            var values = cmm.GetAllCostumerByuserId(Convert.ToInt32(userıd));
            return DataSourceLoader.Load(values, loadOptions);
        }
        [HttpPost]
        public IActionResult Post(string values)
        {
            var newcostumer = new Costumer();
            string userıd = null;
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            userıd = userIdClaim.Value;
            JsonConvert.PopulateObject(values, newcostumer);

            if (!TryValidateModel(newcostumer))
                return Error();
            cmm.AddCostumerwithUserId(newcostumer,Convert.ToInt32(userıd));
            return Ok();
        }
        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            var newcostumer = cmm.GetCostumerById(key);
            JsonConvert.PopulateObject(values, newcostumer);

            if (!TryValidateModel(newcostumer))
                return Error();
            cmm.UpdateCostumerCategory(newcostumer);
            return Ok();
        }
        [HttpDelete]
        public void Delete(int key)
        {
            var newcostumer = cmm.GetCostumerById(key);
            cmm.DeleteCostumerCategory(newcostumer);
        }
        public IActionResult Depo()
        {
            return RedirectToAction("WareHouse", "WareHouse");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
