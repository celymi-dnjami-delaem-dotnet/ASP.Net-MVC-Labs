using System.Web.Mvc;

namespace LB_5_2.Filters
{
    public class CustomResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p>Executing</p>");
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("<p>Executed</p>");
        }
    }
}