using Microsoft.Extensions.DependencyInjection;
using System.Data;
using TechTalk.SpecFlow;

namespace FranksBar.Api.Tests.Integration.Steps
{
    public class ScenarioContextHelper
    {
        private const string ContextIdKey = "beerContextId";
        
        private static readonly TestWebAppFactory<Program> _appFactory;
        private static readonly HttpClient _appHttpClient;

        private readonly ScenarioContext _scenarioContext;

        static ScenarioContextHelper()
        {
            _appFactory = new TestWebAppFactory<Program>();
            _appHttpClient = _appFactory.CreateClient();
        }

        public ScenarioContextHelper(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _scenarioContext[ContextIdKey] = Guid.NewGuid().ToString();
        }

        private IServiceProvider ServiceProvider => _appFactory.Services;

        public void Add<T>(string name, T item)
        {
            _scenarioContext[name] = item;
        }

        public T Get<T>(string name)
        {
            return (T)_scenarioContext[name];
        }
        
        public string GetContextId()
        {
            return _scenarioContext[ContextIdKey].ToString();
        }

        public HttpClient GetHttpClient()
        {
            return _appHttpClient;
        }
        
        public T GetService<T>()
        {
            using var scope = ServiceProvider.CreateScope();
            var service = scope.ServiceProvider.GetService<T>();
            return service;
        }
    }
}
