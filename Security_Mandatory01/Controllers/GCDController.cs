using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Security_Mandatory01.ViewModels;

namespace Security_Mandatory01.Controllers
{
    public class GCDController : Controller
    {
        // GET: GCD
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(GCDViewModel model)
        {
            int r;
            while (model.b > 0)
            {
                r = model.a % model.b; //this means (modulo) in both c# and javascript.

                model.a = model.b;

                model.b = r;
            }
            
            model.result = model.a;


            return View("Index", model);
        }


    }
}