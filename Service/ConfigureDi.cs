namespace Service
{
    using Microsoft.Extensions.DependencyInjection;
    using Service.Implement;
    using Service.Interface;

    public static class ConfigureDi
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserManager, UserManager>();
        }
    }
}
