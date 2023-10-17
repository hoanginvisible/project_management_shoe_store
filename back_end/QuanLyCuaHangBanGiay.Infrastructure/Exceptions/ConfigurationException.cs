using Microsoft.AspNetCore.Builder;

namespace Infrastructure.Exceptions;

public static class ConfigurationException
{
    public static void Configuration(this IApplicationBuilder app)
    {
        // if (env.IsDevelopment())
        // {
        //     app.UseDeveloperExceptionPage();
        //     app.UseSwagger();
        //     app.UseSwaggerUI(c => c.SwaggerEndpoint("swagger/v1/swagger.json", "WebApi RESTful v1"));
        // }

        app.UseHttpsRedirection();


        app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(_ => true)
            .AllowCredentials());

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();
        // app.UseEndpoints(endpoints =>
        //     {
        //         endpoints.MapControllers();
        //         endpoints.MapControllerRoute()
        //     }
        // );
        app.UseMiddleware<ExceptionMiddleware>();
    }
}