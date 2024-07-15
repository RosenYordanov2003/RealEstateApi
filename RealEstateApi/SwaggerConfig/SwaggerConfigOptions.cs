namespace RealEstate.SwaggerConfig
{
    using Microsoft.Extensions.Options;
    using Asp.Versioning.ApiExplorer;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using Microsoft.OpenApi.Models;

    /// Configures Swagger to generate API documentation for multiple API versions, indicating deprecated versions.
    public class SwaggerConfigOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;
        public SwaggerConfigOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var desc in _apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                OpenApiInfo openApiInfo = new OpenApiInfo()
                {
                    Title = "RealEstate",
                    Version = desc.ApiVersion.ToString()
                };
                if (desc.IsDeprecated)
                {
                    openApiInfo.Description = "This API version has been depricated";
                }
                options.SwaggerDoc(desc.GroupName, openApiInfo);
            }
        }
    }
}
