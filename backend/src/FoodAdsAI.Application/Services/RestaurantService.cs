using FoodAdsAI.Application.Abstractions;
using FoodAdsAI.Application.Models;
using FoodAdsAI.Domain.Entities;

namespace FoodAdsAI.Application.Services;

public sealed class RestaurantService
{
    private readonly IRepositoryStore _store;

    public RestaurantService(IRepositoryStore store) => _store = store;

    public IReadOnlyCollection<RestaurantDto> GetAll(Guid userId)
        => _store.GetRestaurants(userId)
            .Select(r => new RestaurantDto(r.Id, r.Name, r.CuisineType, r.BrandTone, r.WebsiteUrl, r.LogoUrl))
            .ToArray();

    public async Task<RestaurantDto> CreateAsync(Guid userId, string name, string cuisineType, string brandTone, string? websiteUrl, string? logoUrl, CancellationToken cancellationToken = default)
    {
        var restaurant = new Restaurant
        {
            UserId = userId,
            Name = name,
            CuisineType = cuisineType,
            BrandTone = brandTone,
            WebsiteUrl = websiteUrl,
            LogoUrl = logoUrl
        };

        _store.AddRestaurant(restaurant);
        await _store.SaveChangesAsync(cancellationToken);
        return new RestaurantDto(restaurant.Id, restaurant.Name, restaurant.CuisineType, restaurant.BrandTone, restaurant.WebsiteUrl, restaurant.LogoUrl);
    }
}
