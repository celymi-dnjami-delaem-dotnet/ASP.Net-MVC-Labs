using System;
using System.IO;
using System.Web;
using LB_1.Models;
using Newtonsoft.Json;

namespace LB_1.Handlers
{
    public class MultiAjax : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (string.Equals(context.Request.HttpMethod, HttpMethods.Get, StringComparison.OrdinalIgnoreCase))
            {
                context.Response.Redirect("/HTML/AjaxMulti.html");
            }
            else if (string.Equals(context.Request.HttpMethod, HttpMethods.Post, StringComparison.OrdinalIgnoreCase))
            {
                var jsonBody = new StreamReader(context.Request.InputStream).ReadToEnd();
                var deserializedObject = JsonConvert.DeserializeObject<MultiParams>(jsonBody);

                var x = deserializedObject.X;
                var y = deserializedObject.Y;

                var multi = x * y;

                context.Response.ContentType = "text/plain";
                context.Response.Write(multi);
            }
        }
    }
}
