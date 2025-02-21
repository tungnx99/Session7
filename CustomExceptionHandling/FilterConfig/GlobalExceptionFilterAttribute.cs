namespace CustomExceptionHandling.FilterConfig
{
    using Microsoft.AspNetCore.Mvc.Filters;

    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Console.WriteLine(nameof(GlobalExceptionFilterAttribute));
            base.OnException(context);
        }
    }
}
