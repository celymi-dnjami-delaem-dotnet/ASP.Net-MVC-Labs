using System.Web.Mvc;

namespace LB_3.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return Content($"{HttpContext.Request.HttpMethod}: {HttpContext.Request.Url?.ToString().Split(';')[1]} is not supported");
        }
    }
}