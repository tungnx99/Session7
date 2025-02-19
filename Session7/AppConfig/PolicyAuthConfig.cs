using System.Security.Claims;

namespace Session7.AppConfig
{
    public static class PolicyAuthConfig
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsTony", policy =>
                    policy.RequireClaim(ClaimTypes.UserData, "Tony"));
            });
        }
    }
}
