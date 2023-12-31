using Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Database
builder.Services.RegisterContextDb(builder.Configuration);

// Register Dependency Injection (add repository)
builder.Services.RegisterDi();

// Register handler MediatR
builder.Services.RegisterMediatR();

builder.Services.AddCors(p => p.AddPolicy("myCors", policyBuilder =>
{
    // builder.WithOrigins("http://localhost:3000");
    policyBuilder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
// Register fluentvalidation
// builder.Services.RegisterFluentValidation();

// Register Authentication Token
// builder.Services.RegisterTokenBear(builder.Configuration);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("myCors");

app.UseHttpsRedirection();
app.UseAuthentication(); // Add authentication
app.UseAuthorization(); // add

app.MapControllers();

app.Run();