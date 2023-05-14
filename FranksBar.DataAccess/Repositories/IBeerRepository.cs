using FranksBar.DataAccess.Entities;

namespace FranksBar.DataAccess.Repositories;

public interface IBeerRepository
{
    Task<ICollection<Beer>> GetByBarIdAsync(Guid barId);

    Task<Beer?> CreateAsync(Beer? createBeer);

    Task<Beer?> GetByIdAsync(Guid id);

    Task<IList<Beer>> GetFilteredAsync(int? gtAlcoholByVolume, int? ltAlcoholByVolume);
}