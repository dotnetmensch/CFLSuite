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
            var result = new SetupService().GetPlayers();
            return Json(result.ToDataSourceResult(req));
        }

        [HttpPost]
        public ActionResult SavePlayer([DataSourceRequest] DataSourceRequest req, Player model)
        {
            Player result = model;
            try
            {
                result = new SetupService().SavePlayer(model);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("Error", e.Message);
            }
            return Json(new[] { result }.ToDataSourceResult(req, ModelState));
        }
    }
}