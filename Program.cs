using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PharmacyDataBase.Data;
using PharmacyDataBase.Services;
using Syncfusion.Blazor;
using Microsoft.AspNetCore.Components.Authorization;
using PharmacyDataBase.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddCookie(IdentityConstants.ApplicationScheme); // Adjust based on your authentication scheme
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<CompanyServices>();
builder.Services.AddScoped<ContractServices>();
builder.Services.AddScoped<DoctorServices>();
builder.Services.AddScoped<DrugServices>();
builder.Services.AddScoped<PatientServices>();
builder.Services.AddScoped<PharmacyServices>();
builder.Services.AddScoped<PrescriptionServices>();

builder.Services.AddBlazorBootstrap();

builder.Services.AddControllersWithViews();

builder.Services.AddSyncfusionBlazor();
// Register HttpClient
builder.Services.AddHttpClient();

// Add default identity with EF Core
builder.Services.AddDbContext<ApplicationDataBaseContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDataBaseContext>();

// Register custom AuthenticationStateProvider
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider<ApplicationUser>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); 
app.UseAuthorization();
app.UseAntiforgery(); 
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
