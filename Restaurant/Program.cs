using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using Restaurant.ViewModels;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc();

builder.Services.AddDbContext<ApplicationDbContext>(x => {
    x.UseSqlServer(builder.Configuration.GetConnectionString("sqlcon"));


    });

builder.Services.Configure<IdentityOptions>(x =>
{
    x.Password.RequiredUniqueChars = 1;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireDigit=true;
    x.Password.RequireUppercase = true;
   

});
//builder.Services.Configure<IdentityOptions>(options =>
//{
//    options.Password.RequireDigit = true;
//    options.Password.RequiredLength = 6;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequireLowercase = true;
//    options.Password.RequiredUniqueChars = 1;
//});


builder.Services.AddIdentity<AdminUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IRepository<MasterCategoryMenu>, MasterCategoryMenuRepository>();
builder.Services.AddScoped<IRepository<MasterItemMenu>, MasterItemMenuRepository>();
builder.Services.AddScoped<IRepository<MasterMenu>, MasterMenuRepository>();
builder.Services.AddScoped<IRepository<MasterOffer>, MasterOfferRepository>();
builder.Services.AddScoped<IRepository<MasterOffer>,MasterOfferRepository>();
builder.Services.AddScoped<IRepository<MasterPartner>,MasterPartnerRepository>();
builder.Services.AddScoped<IRepository<MasterServices>,MasterServicesRepository>();
builder.Services.AddScoped<IRepository<MasterSlider>,MasterSliderRepository>();
builder.Services.AddScoped<IRepository<MasterSocialMedia>,MasterSocialMediaRepository>();
builder.Services.AddScoped<IRepository<MasterWorkingHours>,MasterWorkingHoursRepository>();
builder.Services.AddScoped<IRepository<TransactionBookTable>,TransactionBookTableRepository>();
builder.Services.AddScoped<IRepository<TransactionNewsletter>,TransactionNewsletterRepository>();
builder.Services.AddScoped<IRepository<TransactionContactUs>,TransactionContactUsRepository>();
builder.Services.AddScoped<IRepository<MasterFeedBack>,MasterFeedBackRepository>();
builder.Services.AddScoped<IRepository<SystemSetting>,SystemSettingRepository>();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

//app.UseRouting();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "area",
   pattern: "{area:exists}/{controller=Account}/{action=LogIn}/{id?}"
   );

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");


//app.MapGet("/", () => "Hello World!");


app.Run();
