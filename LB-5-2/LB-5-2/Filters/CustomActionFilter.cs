using System.Web.Mvc;

namespace LB_5_2.Filters
{
    public class CustomActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p>Executing</p>");
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p>Executed</p>");
        }
    }
}