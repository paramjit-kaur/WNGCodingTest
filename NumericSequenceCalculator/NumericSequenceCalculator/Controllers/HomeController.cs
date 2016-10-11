using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NumericSequenceCalculator.Models;
using NumericSequenceCalculator.Service;

namespace NumericSequenceCalculator.Controllers
{
    public class HomeController : Controller
    {

        private ISequenceService sequenceService;

        public HomeController()
        {

        }
        public HomeController(ISequenceService sequence)
        {
            sequenceService = sequence;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NumberResult(int id = 0)
        {
            if (ModelState.IsValid)
            {
                TempData["message"] = "";
                string number = Request.Form["Number"].ToString();

                if (!string.IsNullOrEmpty(number))
                {
                    if (!sequenceService.IsDecimalNumber(number))
                    {
                        if (!sequenceService.IsZeroNumber(number))
                        {
                            if (sequenceService.IdentifyNumber(number))
                            {
                                SequenceModel sequences = sequenceService.GenerateSequences(Convert.ToInt32(number));
                                return View("Index", sequences);
                            }
                            else
                            {
                                TempData["message"] = "Please enter a positive whole number.";
                                return View("Index");
                            }
                        }
                        else
                        {
                            TempData["message"] = "Please enter another number except 0 to obtain the series.";
                            return View("Index");
                        }
                    }
                    else
                    {
                        TempData["message"] = "Please do not enter a decimal number.";
                        return View("Index");
                    }
                }
            }

            return View("Index");

        }

        public ActionResult ResetFields()
        {
            TempData["message"] = "";
            return View("Index");
        }
    }
}
