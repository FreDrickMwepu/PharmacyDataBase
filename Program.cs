using Microsoft.EntityFrameworkCore;
using PharmacyDataBase.Components;
using PharmacyDataBase.Data;
using PharmacyDataBase.Services;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<CompanyServices>();
builder.Services.AddScoped<ContractServices>();
builder.Services.AddScoped<DoctorServices>();
builder.Services.AddScoped<DrugServices>();
builder.Services.AddScoped<PatientServices>();
builder.Services.AddScoped<PharmacyServices>();
builder.Services.AddScoped<PrescriptionServices>();

builder.Services.AddBlazorBootstrap();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSyncfusionBlazor();
// Register HttpClient
builder.Services.AddHttpClient();

// Connection Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if(string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection String is Invalid");
}

builder.Services.AddDbContext<ApplicationDataBaseContext> (options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);
    
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

app.UseAuthentication(); // Ensure this is added if authentication is required
app.UseAuthorization();

app.UseAntiforgery(); // Add this line here

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();