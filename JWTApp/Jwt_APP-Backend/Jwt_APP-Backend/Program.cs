using Jwt_APP_Backend;
using Jwt_APP_Backend.Identity;
using Jwt_APP_Backend.Services;
using Jwt_APP_Backend.ServicesContract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

string cs = builder.Configuration.GetConnectionString("conStr");
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ApplicationDbContext>
 (option => option.UseSqlServer(cs, b =>
 b.MigrationsAssembly("Jwt_APP-Backend")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IRoleStore<ApplicationRole>, ApplicationRoleStore>();
builder.Services.AddTransient<UserManager<ApplicationUser>, ApplicationUserManager>();
builder.Services.AddTransient<SignInManager<ApplicationUser>, ApplicationSignInManager>();
builder.Services.AddTransient<RoleManager<ApplicationRole>, ApplicationRoleManager>();
builder.Services.AddTransient<IUserStore<ApplicationUser>, ApplicationUserStore>();
builder.Services.AddTransient<IUserService, UserServices>();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddUserStore<ApplicationUserStore>()
.AddUserManager<ApplicationUserManager>()
.AddRoleManager<ApplicationRoleManager>()
.AddSignInManager<ApplicationSignInManager>()
.AddRoleStore<ApplicationRoleStore>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<ApplicationRoleStore>();
builder.Services.AddScoped<ApplicationUserStore>();

var appSettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingSection);
var appSetting = appSettingSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSetting.Secret);
builder.Services.AddAuthentication(x =>
{
  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
  x.RequireHttpsMetadata = false;
  x.SaveToken = true;
  x.TokenValidationParameters = new TokenValidationParameters()
  {
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(key),
    ValidateIssuer = false,
    ValidateAudience = false
  };
});


builder.Services.AddCors(options =>
{
  options.AddPolicy("Suraj", builder =>
  {
    builder.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
  });
});
//builder.Services.ConfigureApplicationCookie(options =>
//{
//  options.Events.OnRedirectToLogin = context =>
//  {
//    context.Response.StatusCode = 401;
//    return Task.CompletedTask;
//  };
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("Suraj");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
//IServiceScopeFactory serviceScopeFactory=app.Services.GetRequiredService<IServiceScopeFactory>();
//using (IServiceScope scope=serviceScopeFactory.CreateScope())
//{
//  var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
//  var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
  //if (!await roleManager.RoleExistsAsync("Admin"))
  //{
  //  var role = new ApplicationRole();
  //  role.Name = "Admin";
  //  await roleManager.CreateAsync(role);
  //}
  //if (!await roleManager.RoleExistsAsync("Employee"))
  //{
  //  var role = new ApplicationRole();
  //  role.Name = "Employee";
  //  await roleManager.CreateAsync(role);
  //}
//  if (await userManager.FindByNameAsync("Admin") == null)
//  {
//    var user = new ApplicationUser();
//    user.UserName = "Admin";
//    user.Email = "admin@gmail.com";
//    var checkUser=await userManager.CreateAsync(user,"Admin@123");
//    if (checkUser.Succeeded)
//    {
//      await userManager.AddToRoleAsync(user, "Admin");
//    }
//  }
//  if (await userManager.FindByNameAsync("Employee") == null)
//  {
//    var user = new ApplicationUser();
//    user.UserName = "Employee";
//    user.Email = "employee@gmail.com";
//    var checkUser = await userManager.CreateAsync(user, "Admin@123");
//    if (checkUser.Succeeded)
//    {
//      await userManager.AddToRoleAsync(user, "Employee");
//    }
//  }
//}
app.MapControllers();

app.Run();
