using System.Web.Mvc;

namespace LB_5_2.Filters
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.Write("Exception message: " + filterContext.Exception.Message);
            filterContext.ExceptionHandled = true;
        }
    }
}