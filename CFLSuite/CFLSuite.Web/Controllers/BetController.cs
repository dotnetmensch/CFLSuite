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
    public class BetController : Controller
    {
        // GET: Bet
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetBetGridModels([DataSourceRequest] DataSourceRequest req)
        {
            var result = new BetService().GetBetGridModels();
            return Json(result.ToDataSourceResult(req));
        }
    }
}