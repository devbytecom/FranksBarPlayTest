using FranksBar.Shared.Commands;
using FranksBar.Shared.Models;

namespace FranksBar.Shared.Services;

public interface IBeerService
{
    Task<Guid> CreateAsync(CreateBeerCommand  command);

    Task<bool> UpdateAsync(UpdateBeerCommand beer);

    Task<Beer?> GetAsync(Guid id);
    
    Task<IEnumerable<Beer>?> GetFilteredAsync(int? gtAlcoholByVolume, int? ltAlcoholByVolume);
}