
using GetCardsTest.Constants;

namespace GetCardsTest.Tests.Post
{
    public class CreateCardsTest : BaseTest
    {
        private string _createCardId;
        [Test]
        public void CheckCreateCard()
        {
            //create
            var cardName = "New Done Card " + DateTime.Now.ToLongDateString();

            var request = RequestWithAuth(CardEndpoints.CreateCardUrl)
                .AddQueryParameter("idList", UrlParamValues.ListId)
                .AddJsonBody(new Dictionary<string, string> {{"name", cardName}});

            var response = _client.Post(request);

            var responseContent = JToken.Parse(response.Content);
            _createCardId = responseContent.SelectToken("id").ToString();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseContent.SelectToken("name").ToString(), Is.EqualTo(cardName));

            //check newly created card
            request = RequestWithAuth(CardEndpoints.GetCardsUrl)
                    .AddQueryParameter("fields", "id,name")
                    .AddUrlSegment("boardId", UrlParamValues.BoardId);

            response = _client.Get(request);
            responseContent = JToken.Parse(response.Content);

            Assert.True(responseContent.Children().Select(token => token.SelectToken("name")).Contains(cardName));
        }

        [TearDown]
        public void DeleteCreatedCard()
        {
            var request = RequestWithAuth(CardEndpoints.DeleteCardUrl)
                .AddUrlSegment("id", _createCardId);

            var response = _client.Delete(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
