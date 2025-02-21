namespace CustomExceptionHandling.FilterConfig
{
    using Microsoft.AspNetCore.Mvc.Filters;

    public class MethodExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            Console.WriteLine(nameof(MethodExceptionFilterAttribute));
            base.OnException(context);
        }
    }
}
