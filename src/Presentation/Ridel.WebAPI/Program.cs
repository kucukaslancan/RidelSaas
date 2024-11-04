using Ridel.Application;
using Ridel.Domain.Enums;
using Ridel.Persistence;
using Ridel.Infrastructure;
using Ridel.Persistence.Seeds;
using System.Text.Json.Serialization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterPersistence(builder.Configuration);
builder.Services.RegisterInfrastructure(builder.Configuration);
builder.Services.RegisterApplication(builder.Configuration);



 
builder.Services.AddControllers()
          .AddJsonOptions(options =>
          {
              options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
              options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
          });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "RidelSaaS API", Version = "v1" });

    // JWT Bearer Konfigürasyonu
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Lütfen 'Bearer {token}' formatýnda giriniz",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});



// Authorization Policy'leri ekleyin
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireDriverRole", policy => policy.RequireRole(UserRoles.Driver.ToString()));
    options.AddPolicy("RequireDispatcherRole", policy => policy.RequireRole(UserRoles.Dispatcher.ToString()));
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole(UserRoles.Admin.ToString()));
});

builder.Services.AddHttpContextAccessor();  
 

var app = builder.Build();

using (IServiceScope? scope = app.Services.CreateScope())
{
    IServiceProvider? services = scope.ServiceProvider;
    await SeedRolesService.SeedRolesAsync(services);
}


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
