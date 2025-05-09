namespace ToDo_API.Startup
{
    public static class SwaggerConfig
    {
        public static void UseSwaggerDocs(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
