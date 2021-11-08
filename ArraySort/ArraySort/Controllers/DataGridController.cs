using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Routing;
using ArraySort.Repository;

namespace ArraySort.Controllers
{
    public class DataGridController : Controller
    {
        DataGridRepository _repo;
        public DataGridController()
        {
            _repo = new DataGridRepository();
        }

        public object Index()
        {
            return View(string.Empty);
        }

        public object Convert()
        {
            dynamic data = _repo.Convert();
            return Json(data);
        }
    }
}