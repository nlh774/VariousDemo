using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Commtools;

namespace Commtools.Test_Web.Controllers
{
    public class InterfaceController : Controller
    {
        [HttpGet]
        public JsonResult CityServiceGet()
        {
            int id = Request.QueryString["id"].ToInt32(0);
            List<City> cities = GetCities();
            if (id > 0) cities = cities.FindAll(t => t.Id == id);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CityServicePost()
        {
            string name = Request.Form["name"];
            List<City> cities = GetCities();
            if (name.IsNotNullOrWhiteSpace()) cities = cities.FindAll(t => t.Name == name);
            return Json(cities, JsonRequestBehavior.DenyGet);
        }

        public ActionResult WebHelperTest()
        {
            string msg = string.Empty;
            try
            {
                //get 无参
                WebHelper target = new WebHelper("http://localhost:1444/Interface/CityServiceGet", HttpMethod.Get);
                var expected = new List<City> 
                {
                    new City{Id=1,Name="上海"},
                    new City{Id=2,Name="北京"},
                    new City{Id=3,Name="苏州"},
                    new City{Id=4,Name="重庆"},
                    new City{Id=3,Name="南京"},
                    new City{Id=4,Name="嘉兴"},
                };
                List<City> actual;
                actual = target.GetResponse<List<City>>();
                //get 有参
                target.RequestParam = "id=4";
                expected = new List<City> 
                {
                    new City{Id=4,Name="嘉兴"},
                };
                actual = target.GetResponse<List<City>>();

                //post 必须有参
                target = new WebHelper("http://localhost:1444/Interface/CityServicePost", HttpMethod.Post);
                target.RequestParam = "name=上海";
                expected = new List<City> 
                {
                    new City{Id=1,Name="上海"},
                };
                actual = target.GetResponse<List<City>>();

                msg = "ok";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return Content(msg);
        }

        private static List<City> GetCities()
        {
            return new List<City> 
            {
                new City{Id=1,Name="上海"},
                new City{Id=2,Name="北京"},
                new City{Id=3,Name="苏州"},
                new City{Id=4,Name="重庆"},
                new City{Id=5,Name="南京"},
                new City{Id=6,Name="嘉兴"},
            };
        }

    }


    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
