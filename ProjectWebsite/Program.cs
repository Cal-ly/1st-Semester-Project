using ProjectWebsite.Repositories;
using ProjectWebsite.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<JsonProductService, JsonProductService>();
builder.Services.AddSingleton<JsonCustomerService, JsonCustomerService>();
builder.Services.AddSingleton<JsonEventService, JsonEventService>();
builder.Services.AddSingleton<JsonOrderService, JsonOrderService>();

builder.Services.AddSingleton<OrderRepository, OrderRepository>();
builder.Services.AddSingleton<CustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<ProductRepository, ProductRepository>();
builder.Services.AddSingleton<EventRepository, EventRepository>();

builder.Services.AddSingleton<ProductService, ProductService>();
builder.Services.AddSingleton<OrderService, OrderService>();
builder.Services.AddSingleton<CustomerService, CustomerService>();
builder.Services.AddSingleton<EventService, EventService>();

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
