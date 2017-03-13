using CFLSuite.DataContracts.Models;
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
    public class RedemptionController : Controller
    {
        // GET: Redemption
        public ActionResult Index(int betID)
        {
            return View(betID);
        }

        [HttpGet]
        public ActionResult GetRedeemedThrowModels(int betID)
        {
            var result = new BetService().GetRedeemedThrowModels(betID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetRedemptionsByParentBet([DataSourceRequest]DataSourceRequest req, int betID)
        {
            var result = new BetService().GetRedemptionsByParentBet(betID);
            return Json(result.ToDataSourceResult(req));
        }

        [HttpPost]
        public ActionResult SaveRedemptionModel([DataSourceRequest]DataSourceRequest req, RedemptionModel model)
        {
            var result = model;
            try
            {
                result = new BetService().SaveRedemptionModel(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e.Message);
            }

            return Json(new[] { result }.ToDataSourceResult(req, ModelState));
        }

    }
}