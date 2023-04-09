// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir

#region usings

using MicroserviceWithCleanArchitecture.API.Extensions;
using MicroserviceWithCleanArchitecture.Persistence;
using MicroserviceWithCleanArchitecture.Persistence.Seeding;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

#endregion


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var serviceCollection = builder.Services;
serviceCollection.AddDatabase(configuration);
serviceCollection.AddEndpointsApiExplorer();
serviceCollection.AddSwaggerGen(_ => _.SwaggerDoc("v1", new OpenApiInfo { Title = "Microservice with Clean Architecture", Version = "v1" }));
serviceCollection.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    dbContext.Database.Migrate();
    await Seeder.SeedDatabase(dbContext, app.Logger);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
