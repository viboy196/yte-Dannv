using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Xcomp.Api
{
    public class AddApiVersionExampleValueOperationFilter : IOperationFilter
    {
        private const string ApiVersionQueryParameter = "v";
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiVersionParameter = operation.Parameters.SingleOrDefault(p => p.Name == ApiVersionQueryParameter);
            if (apiVersionParameter == null)
            {
                // maybe we should warn the user if they are using this filter without applying the QueryStringApiVersionReader as the ApiVersionReader
                return;
            }
            // get the [ApiVersion("VV")] attribute
            var attribute = context?.MethodInfo?.DeclaringType?
              .GetCustomAttributes(typeof(ApiVersionAttribute), false)
              .Cast<ApiVersionAttribute>()
              .SingleOrDefault();
            // extract the value of the api version
            var version = attribute?.Versions?.SingleOrDefault()?.ToString();
            // may be we should warn if we find un-versioned ApiControllers/ operations?
            if (version != null)
            {
                apiVersionParameter.Example = new OpenApiString(version);
                apiVersionParameter.Schema.Example = new OpenApiString(version);
            }
        }
    }

    public class SwaggerGenConfigurationOptions : IConfigureOptions<SwaggerGenOptions>
    {
        // https://codingfreaks.de/dotnet-core-api-versioning/
        private readonly IApiVersionDescriptionProvider provider;
        public SwaggerGenConfigurationOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    new OpenApiInfo
                    {
                        Title = "BachDuongIot.Web.Api",
                        Version = description.ApiVersion.ToString()
                    });
            }
            options.OperationFilter<AddApiVersionExampleValueOperationFilter>();
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        }
    }

}
