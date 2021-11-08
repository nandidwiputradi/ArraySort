using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Routing;
using Newtonsoft.Json;

namespace ArraySort.Controllers
{
    public class DefaultController : Controller
    {
        public DefaultController()
        {

        }

        public object Index()
        {
            return View(string.Empty);
        }

        public object TestAction()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            dict["Controller"] = ControllerName;
            dict["Action"] = ActionName;
            
            string data = JsonConvert.SerializeObject(dict);
            return Json(data);
        }
    }
}