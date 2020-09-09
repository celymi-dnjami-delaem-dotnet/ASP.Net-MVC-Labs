using System.IO;
using System.Web;
using LB_1.Models;
using Newtonsoft.Json;

namespace LB_1.Handlers
{
    public class YdsPost : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var jsonBody = new StreamReader(context.Request.InputStream).ReadToEnd();
            var deserializedObject = JsonConvert.DeserializeObject<SumParams>(jsonBody);

            var parmA = deserializedObject.ParmA;
            var parmB = deserializedObject.ParmB;

            context.Response.ContentType = "text/plain";
            context.Response.Write($"POST-Http-YDS:ParmA = {parmA},ParmB = {parmB}");
        }
    }
}
