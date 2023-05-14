using FluentValidation.Results;
using FranksBar.Api.Controllers;
using FranksBar.Api.Tests.TableRows;
using FranksBar.Api.Validators;
using FranksBar.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace FranksBar.Api.Tests.Integration.Steps
{
    [Binding]
    [Scope(Tag = "Integration")]
    public class BeerSteps
    {
        private readonly ScenarioContextHelper _helper;
        private BeerController _beerController;

        public BeerSteps(ScenarioContextHelper helper)
        {
            _helper = helper;
            _beerController = _helper.GetService<BeerController>();
        }

        [Given(@"a beer has a name of '(.*)' and alcohol percentage of (.*)%")]
        public async Task GivenARaceWithRunners(string beerName, decimal beerPercentage)
        {
            var beerCommand = new CreateBeerCommand
            {
                PercentageAlcoholByVolume = beerPercentage,
                Name = beerName
            };
            
            _helper.Add("beerCommand", beerCommand);

            await Task.CompletedTask;
        }

        [When(@"beer command is posted")]
        public async Task GivenBeerCommandIsPosted()
        {
            var beerCommand = _helper.Get<CreateBeerCommand>("beerCommand");

            var response = await _beerController.PostAsync(beerCommand);

            _helper.Add("beerCreateResponse", response);
        }

        [Then(@"BadRequest response with the following errors")]
        public async Task ThenBadRequestResponseWithTheFollowingErrors(Table table)
        {
            var errorMessages = table.CreateSet<ErrorMessageTableRow>();

            var response = _helper.Get<IActionResult>("beerCreateResponse") as BadRequestObjectResult;

            Assert.Equal(400, response.StatusCode);

            var errors = response.Value as List<ValidationFailure>;

            foreach (var error in errorMessages)
            {
                Assert.Contains(errors, e => string.Equals(e.ErrorMessage, error.ErrorMessage, StringComparison.InvariantCultureIgnoreCase));
            }
            
            await Task.CompletedTask;
        }

    }
}
