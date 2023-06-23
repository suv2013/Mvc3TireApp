using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
namespace Mvc3TireApp.Controllers
{
    public class CountryController : Controller
    {
        //
        // GET: /Country/

        Country Obj_Country = new Country();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            Obj_Country.CountryID = 0;
            List<Country> CountryList = Obj_Country.GetCountries().ToList();
            return View(CountryList);
        }

    }
}
