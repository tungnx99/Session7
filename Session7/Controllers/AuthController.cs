using Common.Enums;
using Common.Http;
using Domain.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace Session7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService,
            IUserManager authManager)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserLoginDTO data)
        {
            var result = _authService.CheckLogin(data);
            return CommonResponse(result);
        }

        [Authorize(Roles = AccountRole.Constants.Admin, Policy = "IsTony")]
        [HttpGet]
        public IActionResult GetInformation()
        {
            var userDataReturn = _authService.GetInformationUser();
            return CommonResponse(userDataReturn);

        }

        public IActionResult CommonResponse<T>(ReturnMessage<T> data)
        {
            if (data.HasError)
            {
                return BadRequest(data);
            }
            return Ok(data);
        }
    }
}
