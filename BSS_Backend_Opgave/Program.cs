using System.Reflection;
using System.Text;
using BSS_Backend_Opgave.API.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using BSS_Backend_Opgave.Repositories.Data;
using BSS_Backend_Opgave.API.Extensions;
using BSS_Backend_Opgave.Repositories.Models.Seeder;
using Microsoft.OpenApi.Models;
using BSS_Backend_Opgave.Models;
using Microsoft.AspNetCore.Identity;
using BSS_Backend_Opgave.API;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<BSS_Backend_OpgaveAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BSS_Backend_OpgaveAPIContext") ?? throw new InvalidOperationException("Connection string 'BSS_Backend_OpgaveAPIContext' not found.")));


// Add services to the container.

builder.Services.AddControllers();
builder.Services.RegisterServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,

    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },

            Array.Empty<string>()
        }
    });
});

#region SignalRSetup

builder.Services.AddSignalR(opt =>
{
    opt.HandshakeTimeout = TimeSpan.FromSeconds(3);
});

#endregion

#region JWT Setup

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWTSettings:Issuer"],
        ValidAudience = builder.Configuration["JWTSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:Key"] ??
                           throw new ArgumentException("SigningKey not found!")))
    };
});

builder.Services.AddAuthorization();

#endregion


var app = builder.Build();

#region SeederConfig

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
SeedData.Initialize(services);

#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHub<EventHub>("/event");

app.UseAuthentication();

app.UseAuthorization();

app.UseSensorRequestValidator();

app.MapControllers();

app.UseCors();

app.Run();