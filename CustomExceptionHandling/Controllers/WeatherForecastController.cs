namespace CustomExceptionHandling.Controllers
{
    using CustomExceptionHandling.BusinessExceptionCustom;
    using CustomExceptionHandling.FilterConfig;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
        [HttpGet]
        [MethodExceptionFilter]
        public IActionResult ExceptionTest()
        {
            throw new BusinessException("TEST");
        }
    }
}
