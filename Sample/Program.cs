using User.Host.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.RegistrationService();

var app = builder.Build();

app.MapControllers();

app.Use(ExceptionMiddleware.Handle);

app.Run();
