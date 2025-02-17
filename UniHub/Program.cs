using UniHub.UniHubDbContext;
using Microsoft.EntityFrameworkCore;
using UniHub.Implementations.Repository;
using UniHub.Implementations.Services;
using UniHub.Interfaces.Repository;
using UniHub.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

//Add Database
builder.Services.AddDbContext<UniHubContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString(name: "UniHubContext")));


// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRepostRepository, RepostRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IClubRepository, ClubRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRepostService, RepostService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IClubService, ClubService>();


builder.Services.AddControllersWithViews();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();