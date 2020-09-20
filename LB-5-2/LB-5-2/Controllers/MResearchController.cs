using System.Web.Mvc;

namespace LB_5_2.Controllers
{
    public class MResearchController : Controller
    {
        [HttpGet]
        public ActionResult M01B(int n, string stringg)
        {
            return Content($"GET:M01/{n}/{stringg}");
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult M02(bool b, string letter)
        {
            return Content($"{HttpContext.Request.HttpMethod}:M02/{b}/{letter}");
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Delete)]
        public ActionResult M03(float f, string stringg)
        {
            return Content($"{HttpContext.Request.HttpMethod}:M03/{f}/{stringg}");
        }

        [HttpPut]
        public ActionResult M04(string letters, int n)
        {
            return Content($"PUT:M04/{letters}/{n}");
        }

        [HttpPost]
        public ActionResult M04(string email)
        {
            return Content($"POST:M04/{email}");
        }
    }
}