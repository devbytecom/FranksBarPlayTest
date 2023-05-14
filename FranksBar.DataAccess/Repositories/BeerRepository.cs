using FranksBar.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FranksBar.DataAccess.Repositories
{
    public class BeerRepository : IBeerRepository
    {
        private readonly DBarContext _dBarContext;

        public BeerRepository(DBarContext dBarContext)
        {
            _dBarContext = dBarContext;
        }

        public async Task<ICollection<Beer>> GetByBarIdAsync(Guid barId)
        {
            return await _dBarContext
                .BarBeers
                .Include(_ => _.Beer)
                .Where(_ => _.BarId == barId)
                .Select(_ => _.Beer)
                .ToListAsync();
        }

        public async Task<Beer?> CreateAsync(Beer? createBeer)
        {
            await _dBarContext.Beers.AddAsync(createBeer);

            await _dBarContext.SaveChangesAsync();

            return createBeer;
        }

        public async Task<Beer?> GetByIdAsync(Guid id)
        {
            return await _dBarContext.Beers.FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task<IList<Beer>> GetFilteredAsync(int? gtAlcoholByVolume, int? ltAlcoholByVolume)
        {
            return await _dBarContext.Beers.Where(_ => _.PercentageAlcoholByVolume > (gtAlcoholByVolume ?? 100) &&
                                                       _.PercentageAlcoholByVolume < (ltAlcoholByVolume ?? 0))
                .ToListAsync();
        }
    }
}
