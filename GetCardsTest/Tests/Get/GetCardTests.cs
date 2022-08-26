using GetCardsTest.Constants;
using GetCardsTest.Tests;

namespace GetCardsTest.Tests.Get
{
    public class GetCardTests : BaseTest
    {
        [Test]
        public void CheckGetCardsOnABoard()
        {
            var request = RequestWithAuth(CardEndpoints.GetCardsUrl)
                    .AddQueryParameter("fields", "id,name")
                    .AddUrlSegment("boardId", UrlParamValues.BoardId);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_cards_on_board.json"));

            Assert.True(responseContent.IsValid(jsonSchema));
        }

        [Test]
        public void CheckGetACard()
        {
            var request = RequestWithAuth(CardEndpoints.GetACardUrl)
                .AddQueryParameter("fields", "id,name")
                .AddUrlSegment("cardId", UrlParamValues.CardId);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JToken.Parse(response.Content).SelectToken("name").ToString, Is.EqualTo("updating my first card"));

            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_a_card.json"));

            Assert.True(responseContent.IsValid(jsonSchema));
        }

    }
}