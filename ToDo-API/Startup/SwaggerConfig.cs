namespace ToDo_API.Startup
{
    public static class SwaggerConfig
    {
        public static void UseSwaggerDocs(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
