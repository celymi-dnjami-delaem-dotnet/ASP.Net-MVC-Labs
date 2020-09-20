using System;
using System.Web.Mvc;
using LB_5_2.Filters;

namespace LB_5_2.Controllers
{
    public class AResearchController : Controller
    {
        [HttpGet] 
        [CustomActionFilter]
        public ActionResult AA()
        {
            HttpContext.Response.Write("<b>AA achieved</b>");

            return new EmptyResult();
        }

        [HttpGet]
        [CustomResultFilter]
        public ActionResult AR()
        {
            HttpContext.Response.Write("<b>AR achieved</b>");

            return new EmptyResult();
        }

        [HttpGet]
        [CustomExceptionFilter]
        public ActionResult AE()
        {
            throw new NullReferenceException("custom null reference");
        }
    }
}