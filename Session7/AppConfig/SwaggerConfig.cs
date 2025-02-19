using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Swagger
{
    public class SwaggerConfig
    {
        public static SwaggerGenOptions Setup(SwaggerGenOptions result)
        {
            result.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Session 7 API",
                Version = "v1",
                Description = "Description for the API goes here.",
                Contact = new OpenApiContact
                {
                    Name = "ShopClothing",
                    Email = string.Empty,
                },
            });
            // Include 'SecurityScheme' to use JWT Authentication
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Please enter into field the word 'Bearer' following by space and JWT",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            result.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            result.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { jwtSecurityScheme, Array.Empty<string>() }
            });

            return result;
        }
    }
}
