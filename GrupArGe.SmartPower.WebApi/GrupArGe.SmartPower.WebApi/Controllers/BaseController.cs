using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace GrupArGe.SmartPower.WebApi.Controllers
{
  public class BaseController : ApiController
  {
    public DbInteraction.DbContext dbContext;
    public ResultItem result { get; set; }
        public string UserId;
    public BaseController() {
      result = new ResultItem();
      dbContext = new DbInteraction.DbContext();
      if(User.Identity.IsAuthenticated)
                UserId = ((ClaimsIdentity)HttpContext.Current.User.Identity).FindFirst("UserID").Value;
    }
  }
  public class ResultItem
  {
    public object Data { get; set; }
    public bool IsSuccess { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }    
  }
}
