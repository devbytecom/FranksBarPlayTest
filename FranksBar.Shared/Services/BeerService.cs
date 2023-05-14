using FranksBar.DataAccess.Entities;
using FranksBar.DataAccess.Repositories;
using FranksBar.Shared.Commands;

namespace FranksBar.Shared.Services
{
    public class BeerService : IBeerService
    {
        private readonly IBeerRepository _beerRepository;

        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public async Task<Guid> CreateAsync(CreateBeerCommand command)
        {
            var createdBeer = await _beerRepository.CreateAsync(new Beer
            {
                Name = command.Name,
                PercentageAlcoholByVolume = command.PercentageAlcoholByVolume,
            });

            return createdBeer.Id;
        }

        public async Task<bool> UpdateAsync(UpdateBeerCommand beer)
        {

            return true;
        }

        public async Task<Models.Beer?> GetAsync(Guid id)
        {
            var beer = await _beerRepository.GetByIdAsync(id);

            if (beer == null)
            {
                return null;
            }

            return new Models.Beer
            {
                Name = beer.Name,
                PercentageAlcoholByVolume = beer.PercentageAlcoholByVolume,
                Id = beer.Id
            };
        }

        public async Task<IEnumerable<Models.Beer>?> GetFilteredAsync(int? gtAlcoholByVolume, int? ltAlcoholByVolume)
        {
            var filtered = await _beerRepository.GetFilteredAsync(gtAlcoholByVolume, ltAlcoholByVolume);

            return filtered?.Select(x => new Models.Beer
            {
                PercentageAlcoholByVolume = x.PercentageAlcoholByVolume,
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
