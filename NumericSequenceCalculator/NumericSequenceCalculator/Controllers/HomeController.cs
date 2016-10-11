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
            string number = Request.Form["TextboxNumber"].ToString();

            if (!string.IsNullOrEmpty(number))
            {
                if (sequenceService.IdentifyNumber(number))
                {
                    SequenceModel sequences = sequenceService.GenerateSequences(number);
                }
                else
                {
                    return View("Index");
                }
            }

            return View("Index");

        }

        public ActionResult ResetFields()
        {
            return View("Index");
        }
    }
}
