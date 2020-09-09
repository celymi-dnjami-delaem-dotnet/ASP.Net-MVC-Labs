using System.Web;

namespace LB_1.Handlers
{
    public class YdsGet : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var parmA = context.Request.QueryString.Get("ParmA");
            var parmB = context.Request.QueryString.Get("ParmB");

            context.Response.ContentType = "text/plain";
            context.Response.Write($"GET-Http-YDS:ParmA = {parmA},ParmB = {parmB}");
        }
    }
}
