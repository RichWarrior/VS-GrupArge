using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;

namespace GrupArGe.SmartPower.WebApi.Authorize
{
    // Dinamik yetki vermemiz için mevcut System.Web.Http.AuthorizeAttribute sınıfını ezmemiz gerekiyor. WebApiConfig dosyasının içerisine eklenmiştir.
    public class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                System.Net.Http.HttpRequestMessage message = new System.Net.Http.HttpRequestMessage();
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    Content = new StringContent("Token yok!")

                };
            }
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {

            base.OnAuthorization(actionContext);
        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {           
            if (actionContext.Request.GetRouteData().Route.RouteTemplate == "api/Devices/AllDevices")
                if (((ClaimsIdentity)HttpContext.Current.User.Identity).FindFirst("UserID").Value == "1")
                    return true;
                else
                    return false;       
            return true;
            // return false;
            //token varsa
            //if (HttpContext.Current.User.Identity.IsAuthenticated)
            //{
            //    WebApi.Models.GLCEntities db = new Models.GLCEntities();
            //    var RouteTemplate = actionContext.Request.GetRouteData().Route.RouteTemplate;
            //    var UserID = ((ClaimsIdentity)HttpContext.Current.User.Identity).FindFirst("UserID");
            //    return db.GLC_IsAuthorize_Bool(UserID.Value, RouteTemplate).FirstOrDefault().Value;
            //}
            //else
            //{
            //    return base.IsAuthorized(actionContext);
            //    //WebApi.Models.GLCEntities db = new Models.GLCEntities();
            //    //db.GLC_IsAuthorize_Bool(,actionContext.Request.GetRouteData().Route.RouteTemplate);
            //    //return false;// Token yoksa unauthorize döner
            //}

        }
}
}