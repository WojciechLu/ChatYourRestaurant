using ChatYourRestaurant.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatYourRestaurant.Domain.DI;

public static class DependencyInjector
{
    public static void AddDependency(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<RestaurantDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
    }
}