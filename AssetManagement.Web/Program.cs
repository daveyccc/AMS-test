using AssetManagement.BusinessLogic.Services;
using AssetManagement.BusinessLogic.Interfaces;
using AssetManagement.DataAccess;
using AssetManagement.Web.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IAssetObjectiveService, AssetObjectiveService>();
builder.Services.AddScoped<IDecisionRecordService, DecisionRecordService>();
builder.Services.AddScoped<IPredictiveActionService, PredictiveActionService>();
builder.Services.AddScoped<IOrganisationalObjectiveService, OrganisationalObjectiveService>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IDataAssetService, DataAssetService>();
builder.Services.AddScoped<IInformationSystemService, InformationSystemService>();
builder.Services.AddScoped<IRiskItemService, RiskItemService>();
builder.Services.AddScoped<IAuditFindingService, AuditFindingService>();

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
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
