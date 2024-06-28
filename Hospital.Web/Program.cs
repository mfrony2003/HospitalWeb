using Hospital.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Hospital.Utility;
using Hospital.Repositories.Iterface;
using Hospital.Repositories.Implementation;
using Microsoft.AspNetCore.Identity.UI.Services;
using Hospital.Models;
using Hospital.Services.Interface;
using Hospital.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser,IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IDbInitilizer,DbInitilizer>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddTransient<IHospitalInfoService, HospitalInfoService>();
builder.Services.AddTransient<IApplicationUserService, ApplicationUserService>();
builder.Services.AddTransient<IRoomService, RoomService>();
builder.Services.AddTransient<IMedecineCategoryService, MedecineCategoryService>();
builder.Services.AddTransient<IMedecineService, MedecineService>();
builder.Services.AddTransient<ILabReportCategoryService, LabReportCategoryService>();
builder.Services.AddTransient<ILabReportService, LabReportService>();
builder.Services.AddTransient<IPrescriptionService, PrescriptionService>();
builder.Services.AddTransient<IAppoinmentService, AppoinmentService>();
builder.Services.AddTransient<IAppoinmentService, AppoinmentService>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
DataSedding(); 
app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{Area=Admin}/{controller=Hospital}/{action=Index}/{id?}");

app.Run();

void DataSedding()
{

    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.
            GetRequiredService<IDbInitilizer>();
        dbInitializer.Initilizer();



    }
}