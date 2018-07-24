using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace GrupArGe.SmartPower.WebApi.Exceptions
{
    public class MyExceptionHandler : ExceptionHandler
    {
        private DbInteraction.DbContext dbContext;
        private class ErrorInformation
        {
            public string Message { get; set; }
            public DateTime ErrorDate { get; set; }
        }
        public override void Handle(ExceptionHandlerContext context)
        {
            if (dbContext == null)
            {
                dbContext = new DbInteraction.DbContext();
            }
            try
            {
                //dbContext.InsertData(new ErrorInformation
                //{
                //    Message = context.Exception.ToString(),
                //    ErrorDate = DateTime.Now
                //});
                Logging.Logger.Log(context.Exception.ToString());
                
            }
            catch
            {

            }
            // data varsa true / 

            var obj = new
            {
                data = "",
                issuccess = false,
                header = "Uyarı",
                body = "Geçici bir süre hizmet veremiyoruz.."
            };
            context.Result = new System.Web.Http.Results.ResponseMessageResult(context.Request.CreateResponse(System.Net.HttpStatusCode.OK, obj));
        }
    }
}