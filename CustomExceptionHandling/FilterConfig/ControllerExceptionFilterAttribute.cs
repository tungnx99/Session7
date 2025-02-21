namespace CustomExceptionHandling.FilterConfig
{
    using CustomExceptionHandling.BusinessExceptionCustom;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Newtonsoft.Json;
    using System.Net;

    public class ControllerExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Console.WriteLine(nameof(ControllerExceptionFilterAttribute));

            // handle custom response message
            var error = context.Exception;

            if (error != null)
            {
                if (error.GetType() == typeof(BusinessException))
                {
                    var errorBusiness = (BusinessException)error;
                    var message = new
                    {
                        Code = "Contact Admin!",
                        Message = errorBusiness.MessageBussinessException
                    };

                    context.Result = new ContentResult
                    {
                        Content = JsonConvert.SerializeObject(message),
                        ContentType = "application/json",
                        // change to whatever status code you want to send out
                        StatusCode = (int?)HttpStatusCode.BadRequest
                    };
                }
            }

            base.OnException(context);
        }
    }
}
