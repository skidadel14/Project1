using MyFirstProject.Interfaces;
using MyFirstProject.Models;

var builder = WebApplication.CreateBuilder(args);

// 1. Add MVC support
builder.Services.AddControllersWithViews();

// 2. Register Mock Services so the Interfaces work without a Database
builder.Services.AddScoped<IProductService, MockProductService>();
builder.Services.AddScoped<IUserService, MockUserService>();

var app = builder.Build();

// 3. Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 4. Set the default route to Products
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();

// --- MOCK IMPLEMENTATIONS (To make the code runnable immediately) ---

public class MockProductService : IProductService
{
    public List<Product> GetAll() => new() { 
        new Product { Id = 1, Name = "Mechanical Keyboard", Price = 99.99 },
        new Product { Id = 2, Name = "Gaming Mouse", Price = 49.99 } 
    };
    public Product GetById(int id) => GetAll().First();
    public void Add(Product product) { }
}

public class MockUserService : IUserService
{
    public List<User> GetAll() => new() { 
        new User { Id = 1, Username = "JohnDoe", Email = "john@example.com" },
        new User { Id = 2, Username = "JaneSmith", Email = "jane@example.com" } 
    };
    public User GetById(int id) => GetAll().First();
    public void Register(User user) { }
}