

using Newtonsoft.Json.Schema;

namespace GetCardsTest
{
    public class GetCardTests
    {
        private static IRestClient _client;

        [OneTimeSetUp]
        public static void InitializeRestClient() => _client = new RestClient("https://api.trello.com");

        private IRestRequest RequestWithAuth(string url) => 
            new RestRequest(url)
                .AddQueryParameter("key", "9412ec2fd86e5bd8a69c359da63744d8")
                .AddQueryParameter("token", "868e793c460a02759265b6da6ab8f535c08653d91045ae4a06eff6adfe6fc2c1");

        [Test]
        public void CheckGetCardsOnABoard()
        {
            var request = RequestWithAuth("/1/boards/{boardId}/cards")
                    .AddQueryParameter("fields", "id,name")
                    .AddUrlSegment("boardId", "6305229b7fad4400600293ff");

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_cards_on_board.json"));

            Assert.True(responseContent.IsValid(jsonSchema));
        }

        [Test]
        public void CheckGetACard()
        {
            var request = RequestWithAuth("/1/cards/{cardId}")
                .AddQueryParameter("fields", "id,name")
                .AddUrlSegment("cardId", "6305f551c2aef000f7ed1c5d");

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JToken.Parse(response.Content).SelectToken("name").ToString, Is.EqualTo("updating my first card"));

            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_a_card.json"));

            Assert.True(responseContent.IsValid(jsonSchema));
        }
    }
}