using CFLSuite.DataContracts.Models;
using CFLSuite.Service;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using System;

namespace CFLSuite.Web.Controllers
{
    public class PrizeController : Controller
    {
        // GET: Prize
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetPrizeModelsByLosingParticipant([DataSourceRequest] DataSourceRequest req, int id)
        {
            List<PrizeModel> result = new PrizeService().GetPrizeModelsByLosingParticipant(id);
            return Json(result.ToDataSourceResult(req));
        }

        [HttpPost]
        public ActionResult SavePrizeModel([DataSourceRequest]DataSourceRequest req, PrizeModel model)
        {
            var result = model;
            try
            {
                result = new PrizeService().SavePrizeModel(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e.Message);
            }

            return Json(new[] { result }.ToDataSourceResult(req, ModelState));
        }

        [HttpPost]
        public ActionResult DeletePrizeModel([DataSourceRequest]DataSourceRequest req, PrizeModel model)
        {
            var result = model;
            try
            {
                result = new PrizeService().DeletePrizeModel(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e.Message);
            }

            return Json(new[] { result }.ToDataSourceResult(req, ModelState));
        }
    }
}