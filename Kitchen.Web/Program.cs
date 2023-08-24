using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Kitchen.Data.Context;
using Kitchen.Framework.Infrastructure.Extension;
using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Formatting.Compact;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureApplicationServices(builder.Configuration);
////// *SeriLog
builder.Host.UseSerilog(((context, provider, logger) =>
{
    logger.MinimumLevel.Information().WriteTo.File("log.txt",
        rollingInterval: RollingInterval.Day,
        rollOnFileSizeLimit: true, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error
    ).WriteTo.File(new RenderedCompactJsonFormatter(), "log.ndjson", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning);
}));
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Masood",
        Version = "V1",
        Description = "My App For Kitchen",
        Contact = new OpenApiContact
        {
            Name = "Masood",
            Email = "masoodtalebi93@gmail.com",
            Url = new Uri("http://masood-tmp.ir/"),
        },
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});


var app = builder.Build();
//app.UseCors(x => x
//                    .AllowAnyMethod()
//                    .AllowAnyHeader()
//                    .SetIsOriginAllowed(origin => true) // allow any origin
//                    .AllowCredentials());

app.UseStaticFiles();
app.ConfigureRequestPipeline();

app.Run();