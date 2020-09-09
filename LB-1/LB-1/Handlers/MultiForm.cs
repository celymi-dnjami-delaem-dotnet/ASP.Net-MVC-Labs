using System;
using System.Web;
using LB_1.Models;

namespace LB_1.Handlers
{
    public class MultiForm : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (string.Equals(context.Request.HttpMethod, HttpMethods.Get, StringComparison.OrdinalIgnoreCase))
            {
                context.Response.RedirectToRoute("/HTML/MultiForm.html");
            }
            else if (string.Equals(context.Request.HttpMethod,HttpMethods.Post, StringComparison.OrdinalIgnoreCase))
            {
                var x = context.Request.Form.Get("x");
                var y = context.Request.Form.Get("y");

                var multi = int.Parse(x) * int.Parse(y);

                context.Response.ContentType = "text/plain";
                context.Response.Write($"Multiplication of {x} and {y}: {multi}");
            }
        }
    }
}
