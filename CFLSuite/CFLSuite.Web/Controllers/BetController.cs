using CFLSuite.DataContracts.Entities;
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

        [HttpPost]
        public ActionResult SaveBetGridModel([DataSourceRequest] DataSourceRequest req, BetGridModel model)
        {
            var result = model;
            try
            {
                result = new BetService().SaveBetGridModel(model);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("Error", e);
            }
            return Json(new[] { result }.ToDataSourceResult(req));
        }

        [HttpGet]
        public ActionResult AddThrows(int id)
        {
            var result = new BetService().GetBet(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult GetThrowModels([DataSourceRequest] DataSourceRequest req, int id)
        {
            var result = new List<ThrowModel>();
            result = new BetService().GetThrowModels(id);
            return Json(result.ToDataSourceResult(req));
        }

        [HttpPost]
        public ActionResult SaveThrowModel([DataSourceRequest] DataSourceRequest req, ThrowModel model)
        {
            var result = model;
            try
            {
                result = new BetService().SaveThrowModel(model);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("Error", e);
            }

            return Json(new[] { result }.ToDataSourceResult(req, ModelState));
        }

        [HttpPost]
        public ActionResult DeleteThrowModel([DataSourceRequest] DataSourceRequest req, ThrowModel model)
        {
            var result = model;
            try
            {
                result = new BetService().DeleteThrowModel(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e);
            }

            return Json(new[] { result }.ToDataSourceResult(req, ModelState));
        }

        public ActionResult EditBet(int id)
        {
            var result = new BetService().GetBet(id);
            return View(result);
        }

        public ActionResult FinishBet()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult SaveParticpant([DataSourceRequest] DataSourceRequest req, ParticipantModel model)
        {
            var result = model;
            try
            {
                result = new BetService().SaveParticipantModel(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e);
            }

            return Json(new[] {result}.ToDataSourceResult(req, ModelState));
        }

        public ActionResult GetBetParticipants([DataSourceRequest] DataSourceRequest req, int id)
        {
            var result = new List<ParticipantModel>();
            result = new BetService().GetBetParticipantModels(id);
            return Json(result.ToDataSourceResult(req));
        }

        [HttpPost]
        public ActionResult DeleteParticipant([DataSourceRequest] DataSourceRequest req, ParticipantModel model)
        {
            var result = model;
            try
            {
                result = new BetService().DeleteParticipantModel(model);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e);
            }

            return Json(new[] {result}.ToDataSourceResult(req, ModelState));
        }
    }
}