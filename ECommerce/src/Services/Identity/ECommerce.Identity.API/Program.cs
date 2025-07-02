using ECommerce.Service.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices(builder.Configuration);

//builder.Configuration.GetSection("JwtTokenSettings").Bind(new JwtTokenSettings());
//{


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapPost("/login", (IAuthenticationService authService, UserLoginReuest request) =>
{
    // Here you would typically validate the user credentials against a database
    // and generate an access token and refresh token.
    // For simplicity, we are returning a dummy response.
    // Varsayın ki kullanıcı adı ve şifre kontrolü başarılı oldu.
    var response = authService.Login(request.Username, request.Password);
    return Results.Ok(response);
});


app.Run();

public record UserLoginReuest(string Username, string Password);
