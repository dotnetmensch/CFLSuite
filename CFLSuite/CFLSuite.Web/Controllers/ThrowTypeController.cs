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
    public class ThrowTypeController : Controller
    {
        // GET: ThrowType
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetThrowTypes([DataSourceRequest] DataSourceRequest req)
        {
            List<ThrowType> result = new SetupService().GetThrowTypes();
            return Json(result.ToDataSourceResult(req));
        }

        [HttpPost]
        public ActionResult SaveThrowType([DataSourceRequest] DataSourceRequest req, ThrowType model)
        {
            ThrowType result = null;
            try
            {
                result = new SetupService().SaveThrowType(model);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("Error", e.Message);
            }
            return Json(new[] { result }.ToDataSourceResult(req, ModelState));
        }

        [HttpGet]
        public ActionResult GetThrowTypes()
        {
            var result = new SetupService().GetThrowTypes();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
