// ===================================================
// Copyright (c) Coalition of Good-Hearted programmers
// Developed by SmartEssayChecker devs
// ===================================================


using Microsoft.OpenApi.Models;
using SmartEssayChecker.Brokers.Storages;

namespace SmartEssayChecker;

public class Startup
{
    public Startup(IConfiguration configuration)=>
        Configuration = configuration;
        

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddDbContext<StorageBroker>();
        
        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc(
                name:"v1", 
                info:new OpenApiInfo { Title = "CashOverflow", Version = "v1" });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
            
        app.UseSwagger();
                
        app.UseSwaggerUI(config => 
            config.SwaggerEndpoint(url:"/swagger/v1/swagger.json", name:"CashOverflow v1"));

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => 
            { endpoints.MapControllers(); });
    }
}