namespace Session7.AppConfig
{
    using Infrastructure.Auth;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    public static class JwtAuthConfig
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            //jwt
            var jwtConfig = configuration.GetSection("JwtConfig").Get<JwtTokenConfig>();
            services.AddSingleton(jwtConfig); // Dependancy Injection!!
            // Enable Authentication
            services.AddAuthentication(it =>
            {
                // Use JWT Bearer schema
                it.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                it.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(it =>
            {
                // Setup JWT validation options

                var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret); // Keys use to validate signature

                it.RequireHttpsMetadata = true; // Not mandatory => may be skip
                it.SaveToken = true; // Not mandatory => may be skip

                // Token validation parameters
                it.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, // Require validate issuer, if true then mis specify ValidIssuer
                    ValidIssuer = jwtConfig.Issuer, // Issuer of token

                    ValidateIssuerSigningKey = true, // Verify signature, if false then no need Secret Key to verify token
                    IssuerSigningKey = new SymmetricSecurityKey(secret),

                    ValidateAudience = true, // Validate audience, if true, must specify ValidAudience
                    ValidAudience = jwtConfig.Audience,

                    ValidateLifetime = true, // Validate JWT lifetime, if false will not check nbf and exp

                    ClockSkew = TimeSpan.Zero // Tolerance to validate JWT lifetime
                };
            });
        }
    }
}
