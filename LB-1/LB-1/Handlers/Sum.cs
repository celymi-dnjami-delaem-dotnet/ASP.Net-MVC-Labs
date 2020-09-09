using System.Web;

namespace LB_1.Handlers
{
    public class Sum : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var parmA = context.Request.Form.Get("ParmA");
            var parmB = context.Request.Form.Get("ParmB");

            var sum = int.Parse(parmA) + int.Parse(parmB);
            context.Response.Write($"Sum of {parmA} and {parmB}: {sum}");
        }
    }
}
