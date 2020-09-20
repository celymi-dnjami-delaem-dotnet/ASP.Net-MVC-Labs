using System.Web.Mvc;
using System.Web.UI;

namespace LB_5_2.Controllers
{
    public class CHResearchController : Controller
    {
        private static int _counter = 1;

        [HttpGet]
        [OutputCache(Duration = 5, Location = OutputCacheLocation.Server)]
        public ActionResult AD(int a)
        {
            _counter++;
            return Content((a * _counter).ToString());
        }

        [HttpPost]
        [OutputCache(Duration = 7, Location = OutputCacheLocation.Server)]
        public ActionResult AP(int a)
        {
            _counter++;
            return Content((a * _counter).ToString());
        }
    }
}