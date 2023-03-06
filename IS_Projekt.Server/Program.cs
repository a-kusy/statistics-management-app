using IS_Projekt.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SoapCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(auth => auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
 {
     ValidateIssuer = false,
     ValidateAudience = false,
     ValidateLifetime = true,
     ValidateIssuerSigningKey = true,
     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),

     ClockSkew = TimeSpan.Zero
 });

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IUserService, UserServiceImpl>();
builder.Services.AddSingleton<IDtoToReadableService, DtoToReadableService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

((IApplicationBuilder)app).UseSoapEndpoint<IDtoToReadableService>(options: options =>
{
    options.Path = "/Service.asmx";
    options.SoapSerializer = SoapSerializer.XmlSerializer;
});

app.UseAuthentication();
app.UseAuthorization();
app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

