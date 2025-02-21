namespace CustomExceptionHandling.Controllers
{
    using CustomExceptionHandling.FilterConfig;
    using Microsoft.AspNetCore.Mvc;

    [ControllerExceptionFilter]
    public class BaseController : ControllerBase
    {
    }
}
