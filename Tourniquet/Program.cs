using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

//autofac ile bagimliliklari azaltiyorum.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

app.UseAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => 
{
    options.TokenVdalidationParameters = new TokenVdalidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateSignigKey = true,
        ValidateLiftetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,

    };
});    

app.UseAuthorization();

app.MapControllers();

app.Run();