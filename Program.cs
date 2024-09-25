using FuncProg_Lab1.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

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
app.UseAntiforgery();

app.MapGet("/products/{productId:int}", (int productId) =>
{
    var result = new
    {
        id = productId.ToString(),
        name = $"{productId} name",
        description = $"Product description for product id:{productId} sadasjlkrw"
    };
    return Results.Json(result);
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
