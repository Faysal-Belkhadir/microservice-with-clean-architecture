// ©2023 https://www.linkedin.com/in/faysal-belkhadir | Product: Faysal Belkhadir
#region usings

using Microsoft.OpenApi.Models;

#endregion

var builder = WebApplication.CreateBuilder(args);

var serviceCollection = builder.Services;
serviceCollection.AddEndpointsApiExplorer();
serviceCollection.AddSwaggerGen(_ => _.SwaggerDoc("v1", new OpenApiInfo { Title = "Microservice with Clean Architecture", Version = "v1" }));
serviceCollection.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
