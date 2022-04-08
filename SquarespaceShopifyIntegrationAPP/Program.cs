using SquarespaceShopifyIntegrationAPP.BackgroundWorker;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSignalR();

builder.Services.AddHostedService<TransferService>();

builder.Services.AddSingleton<TransferEventQueue>();
builder.Services.AddScoped<IQueueTask>(s => s.GetRequiredService<TransferEventQueue>());
builder.Services.AddScoped<ITaskViewer>(s => s.GetRequiredService<TransferEventQueue>());

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

app.Run();
