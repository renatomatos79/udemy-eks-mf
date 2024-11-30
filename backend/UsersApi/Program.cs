using UsersApi.Model.Settings;
using UsersApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddSingleton<IDbSettngs>(_ =>
{
    return new DbSettngs 
    { 
        ConnectionString = "mongodb://admin:m0ng0d4t4@localhost:27018/", 
        DBName = "frota" 
    };
});

builder.Services.AddScoped(sp =>
{
    var dbSettings = sp.GetRequiredService<IDbSettngs>();
    return new UserRepository(dbSettings);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
