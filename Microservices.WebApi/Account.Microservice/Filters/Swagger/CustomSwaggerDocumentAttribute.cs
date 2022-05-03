using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Account.Microservice.Filters.Swagger
{
    public class CustomSwaggerDocumentAttribute : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Info = new OpenApiInfo
            {
                Title = "Account Microservice",
                Version = "v1.0.0",
                Description = "Account Manager Microservice (User logins and registration etc.)",
                Contact = new OpenApiContact
                {
                    Name = "Development Engineer",
                    Email = "freedom.khanyile@adaptit.com"
                }
            };
        }
    }
}
