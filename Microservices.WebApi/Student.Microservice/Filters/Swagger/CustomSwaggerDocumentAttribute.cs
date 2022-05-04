using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Student.Microservice.Filters.Swagger
{
    public class CustomSwaggerDocumentAttribute : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Info = new OpenApiInfo
            {
                Title = "Student Microservice",
                Version = "v1.0.0",
                Description = "Student Manager Microservice (Student management service etc.)",
                Contact = new OpenApiContact
                {
                    Name = "Development Engineer",
                    Email = "freedom.khanyile@adaptit.com"
                }
            };
        }
    }
}
