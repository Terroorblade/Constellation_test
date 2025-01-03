using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Fivesemtest.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Сервис для подключения к базе данных
builder.Services.AddDbContext<FivesemestercswrkContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавление аутентификации с использованием Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
.AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<FivesemestercswrkContext>();  // Добавление Entity Framework Stores для работы с базой
    // .AddDefaultTokenProviders();

builder.Services.AddScoped<UsersService>();
// Добавление Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Конфигурация аутентификации и маршрутов
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // Включение аутентификации
app.UseAuthorization();  // Включение авторизации

app.MapRazorPages(); // Маршрутизация Razor страниц

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "admin", "user" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    // Создание пользователя admin
    var adminUser = userManager.FindByEmailAsync("admin@mail.com").Result;
    if (adminUser == null)
    {
        adminUser = new IdentityUser { UserName = "admin@mail.com", Email = "admin@mail.com" };
        var result =  userManager.CreateAsync(adminUser, "Password123!_").Result;

        if (result.Succeeded)
        {
            userManager.AddToRoleAsync(adminUser, "admin").Wait();
            Console.WriteLine("Admin user created successfully.");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.Description);
            }
        }
    }
    else
    {
        Console.WriteLine("Admin user already exists.");
    }
}

app.Run();
