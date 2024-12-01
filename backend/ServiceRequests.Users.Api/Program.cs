using Microsoft.OpenApi.Models;
using ServiceRequests.Common.Helpers;
using ServiceRequests.Common.Model.Settings;
using ServiceRequests.Common.Services;
using ServiceRequests.Users.Api.Repository;

const string ALLOW_ANY_REQUEST = "ALLOW_ALL";

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

builder.Services.AddCors(options =>
{
    options.AddPolicy(ALLOW_ANY_REQUEST, builder =>
    {
        builder.WithOrigins("*").AllowAnyHeader().WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS");
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Users API", Version = "v1" });
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
        DBName = "udemy-mf-users" 
    };
});

builder.Services.AddScoped(sp =>
{
    var dbSettings = sp.GetRequiredService<IDbSettngs>();
    return new UserRepository(dbSettings);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(ALLOW_ANY_REQUEST);
app.Run();
