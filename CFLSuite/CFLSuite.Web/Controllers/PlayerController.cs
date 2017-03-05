using CFLSuite.DataContracts.Entities;
using CFLSuite.Service;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CFLSuite.Web.Controllers
{
    public class PlayerController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetPlayers([DataSourceRequest] DataSourceRequest req)
        {
            var result = new PlayerService().GetPlayers();
            return Json(result.ToDataSourceResult(req));
        }

        [HttpPost]
        public ActionResult SavePlayer([DataSourceRequest] DataSourceRequest req, Player model)
        {
            var result = new PlayerService().SavePlayer(model);
            return Json(new[] { result }.ToDataSourceResult(req));
        }

        [HttpPost]
        public ActionResult DeletePlayer([DataSourceRequest] DataSourceRequest req, Player model)
        {
            var result = new PlayerService().DeletePlayer(model);
            return Json(new[] { result }.ToDataSourceResult(req));
        }
    }
}