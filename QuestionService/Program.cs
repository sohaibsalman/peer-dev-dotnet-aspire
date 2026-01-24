var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.AddServiceDefaults(); // Setup things like Metrics and OpenTelemetry
builder.Services.AddAuthentication()
    .AddKeycloakJwtBearer("keycloak", "peer-dev", options =>
    {
        options.RequireHttpsMetadata = false;
        options.Audience = "peerdev";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.MapDefaultEndpoints();

app.Run();