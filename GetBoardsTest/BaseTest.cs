
namespace GetBoardsTest
{
    public class BaseTest
    {
        protected static IRestClient _client;

        [OneTimeSetUp]
        protected static void InitializeRestClient() =>
            _client = new RestClient("https://api.trello.com");

        protected IRestRequest RequestWitAuth(string url) =>
            RequestWithoutAuth(url)
                 .AddQueryParameter("key", "9412ec2fd86e5bd8a69c359da63744d8")
                 .AddQueryParameter("token", "868e793c460a02759265b6da6ab8f535c08653d91045ae4a06eff6adfe6fc2c1");


        protected IRestRequest RequestWithoutAuth(string url) =>
            new RestRequest(url);

    }
}

