using System;
using System.IO;
using System.Web.Mvc;
using System.Text;

namespace LB_5.Controllers
{
    public class CResearchController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get|HttpVerbs.Post)]
        public ActionResult C01()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(HttpContext.Request.HttpMethod);
            stringBuilder.AppendLine(HttpContext.Request.Url?.AbsolutePath);

            if (HttpContext.Request.QueryString.HasKeys())
            {
                stringBuilder.AppendLine("---Request query params---");
                for (var i = 0; i < HttpContext.Request.QueryString.AllKeys.Length; i++)
                {
                    stringBuilder.AppendLine($"{HttpContext.Request.QueryString.GetKey(i)}: {HttpContext.Request.QueryString.Get(i)}");
                }
            }

            stringBuilder = ReadHeadersAndBody(stringBuilder);

            return Content(stringBuilder.ToString());
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult C02()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(HttpContext.Response.Status);
            stringBuilder = ReadHeadersAndBody(stringBuilder);

            return Content(stringBuilder.ToString());
        }


        private StringBuilder ReadHeadersAndBody(StringBuilder stringBuilder)
        {
            stringBuilder.AppendLine("---Request headers---");
            for (var i = 0; i < HttpContext.Request.Headers.AllKeys.Length; i++)
            {
                stringBuilder.AppendLine($"{HttpContext.Request.Headers.GetKey(i)}: {HttpContext.Request.Headers.Get(i)}");
            }

            stringBuilder.AppendLine("---Response headers---");
            for (var i = 0; i < HttpContext.Response.Headers.AllKeys.Length; i++)
            {
                stringBuilder.AppendLine($"{HttpContext.Response.Headers.GetKey(i)}: {HttpContext.Response.Headers.Get(i)}");
            }

            if (!string.Equals(HttpContext.Request.HttpMethod, "POST", StringComparison.OrdinalIgnoreCase))
            {
                return stringBuilder;
            }

            stringBuilder.AppendLine("---Request body---");
            stringBuilder.AppendLine(new StreamReader(HttpContext.Request.InputStream).ReadToEnd());

            return stringBuilder;
        }
    }
}