using GetCardsTest.Constants;

namespace GetCardsTest.Tests
{
    public class BaseTest
    {
        protected static IRestClient _client;

        [OneTimeSetUp]
        protected static void InitializeRestClient() => _client = new RestClient("https://api.trello.com");

        protected IRestRequest RequestWithAuth(string url) =>
            RequestWithoutAuth(url)
                .AddQueryParameter("key", UrlParamValues.Key)
                .AddQueryParameter("token", UrlParamValues.Token);

        protected IRestRequest RequestWithoutAuth(string url) =>
            new RestRequest(url);

    }
}
