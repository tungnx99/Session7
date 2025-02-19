namespace Service.Implement
{
    using Domain.DTOs.Users;
    using Infrastructure.Auth;
    using Microsoft.AspNetCore.Http;
    using Microsoft.IdentityModel.Tokens;
    using Service.Interface;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;

    public class UserManager : IUserManager
    {
        private readonly JwtTokenConfig _jwtTokenConfig;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly byte[] _secret;

        public UserManager(JwtTokenConfig jwtTokenConfig, IHttpContextAccessor httpContextAccessor)
        {
            _jwtTokenConfig = jwtTokenConfig;
            _secret = Encoding.ASCII.GetBytes(jwtTokenConfig.Secret); // Secret key
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerateToken(IEnumerable<Claim> claims, DateTime now)
        {
            // Setup JWT generate parameters
            var jwtToken = new JwtSecurityToken(
                issuer: _jwtTokenConfig.Issuer,
                audience: _jwtTokenConfig.Audience,
                expires: now.AddMinutes(_jwtTokenConfig.ExpirationMinutes),
                claims: claims,
                notBefore: now,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return accessToken;
        }

        public Guid AuthorizedUserId
        {
            get
            {
                try
                {
                    var claims = _httpContextAccessor.HttpContext.User.Claims;
                    return Guid.Parse(claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);
                }
                catch
                {
                    return Guid.Empty;
                }
            }
        }

        //public UserDataReturnDTO GetInformationAuth(Guid userId)
        //{
        //    try
        //    {
        //        var data = _userRepository.Find(userId);
        //        var result = _mapper.Map<Domain.Entities.User, UserDataReturnDTO>(data);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new UserDataReturnDTO();
        //    }
        //}

        public UserInformationDTO GetInformationUser()
        {
            try
            {
                //var user = _userRepository.Queryable().Include(it => it.Customer).Where(it => !it.IsDeleted && it.Id == AuthorizedUserId).FirstOrDefault();
                //if (user.IsNullOrEmpty())
                //{
                //    return new UserInformationDTO();
                //}
                //var result = _mapper.Map<User, UserInformationDTO>(user);

                var result = new UserInformationDTO
                {
                    FirstName = "Tony"
                };

                return result;
            }
            catch
            {
                return new UserInformationDTO();
            }
        }
    }
}
