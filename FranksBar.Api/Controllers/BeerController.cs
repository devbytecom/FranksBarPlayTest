using FranksBar.Api.Validators;
using FranksBar.DataAccess.Entities;
using FranksBar.Shared.Commands;
using FranksBar.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using Beer = FranksBar.Shared.Models.Beer;

namespace FranksBar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly CreateBeerCommandValidator _createBeerCommandValidator;
        private readonly IBeerService _beerService;

        public BeerController(CreateBeerCommandValidator createBeerCommandValidator, IBeerService beerService)
        {
            _createBeerCommandValidator = createBeerCommandValidator;
            _beerService = beerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(int? gtAlcoholByVolume, int? ltAlcoholByVolume)
        {
            var filtered = _beerService.GetFilteredAsync(gtAlcoholByVolume, ltAlcoholByVolume);

            return Ok(filtered);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var beer = await _beerService.GetAsync(id);

            if (beer == null)
            {
                return NotFound();
            }

            return Ok(beer);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateBeerCommand beer)
        {
            beer.Id = id;
            var validResponse = await _createBeerCommandValidator.ValidateAsync(beer);

            if (validResponse is { IsValid: true })
            {
                var createdId = await _beerService.UpdateAsync(beer);

                return Ok(createdId);
            }

            return BadRequest(validResponse.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateBeerCommand beer)
        {
            var validResponse = await _createBeerCommandValidator.ValidateAsync(beer);

            if (validResponse is { IsValid: true })
            {
                var createdId = await _beerService.CreateAsync(beer);

                return Ok(createdId);
            }

            return BadRequest(validResponse.Errors);
        }
    }
}
