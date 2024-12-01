using Microsoft.OpenApi.Models;
using PoliceStationsApi.Helpers;
using PoliceStationsApi.Model.Settings;
using PoliceStationsApi.Repository;
using PoliceStationsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
});

// Add services to the container.
builder.Services.AddScoped<ITokenService, TokenService>(sp =>
{
    return new TokenService(
        secretKey: builder.GetSecretKey(),
        issuer: builder.GetSecretIssuer(),
        audience: builder.GetSecretAudience()
    );
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Police Stations API", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Authenticated", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});

// Add services to the container.
builder.Services.AddSingleton<IDbSettngs>(_ =>
{
    return new DbSettngs 
    { 
        ConnectionString = builder.GetMongoDbConnectionString(), 
        DBName = "frota" 
    };
});

builder.Services.AddScoped(sp =>
{
    var dbSettings = sp.GetRequiredService<IDbSettngs>();
    return new PoliceStationRepository(dbSettings);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
