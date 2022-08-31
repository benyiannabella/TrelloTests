
using GetCardsTest.Constants;

namespace GetCardsTest.Tests.Put
{
    public class UpdateCardTest : BaseTest
    {
        [Test]
        public void CheckUpdateCard()
        {
            var updatedName = "My New Card Name " + DateTime.Now.ToLongDateString;
            
            var request = RequestWithAuth(CardEndpoints.UpdateCradUrl)
                .AddUrlSegment("cardId", UrlParamValues.CardId)
                .AddJsonBody(new Dictionary<string, string> { { "name", updatedName } });

            var response = _client.Put(request);
            var responseContent = JToken.Parse(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseContent.SelectToken("name").ToString, Is.EqualTo(updatedName));


            request = RequestWithAuth(CardEndpoints.GetACardUrl)
                .AddUrlSegment("cardId", UrlParamValues.CardId);

            response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JToken.Parse(response.Content).SelectToken("name").ToString, Is.EqualTo(updatedName));
        }
    }
}
