
namespace GetCardsTest
{
    public class GetCardTests : BaseTest
    {        
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