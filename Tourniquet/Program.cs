using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.Caching.Abstract;
using Core.Caching.Concrate;
using Core.RabbitMQ.Abstract;
using Core.RabbitMQ.Concrate;
using Core.Security.Jwt;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using NLog;
using NLog.Web;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(services =>
{
    services.AddScoped<IPublisherService , PublisherManager>();
    services.AddScoped<IRabbitMQService , RabbitMQManager>();
    services.AddScoped<IConsumerService, ConsumerManager>();
});

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ICacheManager, MemoryCacheManager>();

builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.AddHttpContextAccessor();

//autofac ile bagimliliklari azaltiyorum.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = tokenOptions.Audience,
            ValidIssuer = tokenOptions.Issuer,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();