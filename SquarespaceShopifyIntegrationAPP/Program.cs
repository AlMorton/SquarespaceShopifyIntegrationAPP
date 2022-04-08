using Infrastructure;
using Infrastructure.APIClients;
using SquarespaceShopifyIntegrationAPP.BackgroundWorker;
using SquarespaceShopifyIntegrationAPP.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSignalR();

builder.Services.AddHostedService<TransferService>();

builder.Services.AddSingleton<TransferEventQueue>();
builder.Services.AddScoped<IQueueTask>(s => s.GetRequiredService<TransferEventQueue>());
builder.Services.AddScoped<ITaskViewer>(s => s.GetRequiredService<TransferEventQueue>());

builder.Services.Configure<ShopifyConfig>(builder.Configuration.GetSection(ShopifyConfig.Config));

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapHub<TransferJobHub>("/transfershub");

app.Run();
