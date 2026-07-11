using FoodAdsAI.Domain.Entities;

namespace FoodAdsAI.Application.Abstractions;

public interface IRepositoryStore
{
    IReadOnlyCollection<Restaurant> GetRestaurants(Guid userId);
    IReadOnlyCollection<Campaign> GetCampaigns(Guid? userId = null);
    IReadOnlyCollection<GeneratedImage> GeneratedImages { get; }
    IReadOnlyCollection<PromptHistory> GetPromptHistory(Guid? userId = null);
    IReadOnlyCollection<Favorite> GetFavorites(Guid userId);

    void AddRestaurant(Restaurant restaurant);
    void UpsertRestaurant(Restaurant restaurant);
    void AddCampaign(Campaign campaign);
    void AddGeneratedImage(GeneratedImage image);
    void AddPromptHistory(PromptHistory history);
    void RemovePromptHistory(Guid id);
    void AddFavorite(Favorite favorite);
    void RemoveFavorite(Guid id);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task ExecuteInTransactionAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken = default);
}
