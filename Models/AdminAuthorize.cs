using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BursumMobil.Models
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.IsAuthenticated)
            {
                httpContext.Response.Redirect("/Admin/Index");
            }
                        
            return base.AuthorizeCore(httpContext);

        }
    }
}