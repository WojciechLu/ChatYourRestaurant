using ChatYourRestaurant.DataAccess;
using ChatYourRestaurant.DataAccess.Repositories;
using ChatYourRestaurant.Domain.Service.Interfaces;
using ChatYourRestaurant.Domain.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatYourRestaurant.Domain.DI;

public static class DependencyInjector
{
    public static void AddDependency(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<RestaurantDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        serviceCollection.AddScoped<IMealRepository, MealRepository>();
        serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
        serviceCollection.AddScoped<IMealService, MealService>();
        serviceCollection.AddScoped<IOrderService, OrderService>();
    }
}