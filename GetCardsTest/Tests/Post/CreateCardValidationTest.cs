
using GetCardsTest.Arguments.Holders;
using GetCardsTest.Arguments.Providers;
using GetCardsTest.Constants;


namespace GetCardsTest.Tests.Post
{
    public class CreateCardValidationTest :BaseTest
    {
        [Test]
        [TestCaseSource(typeof(CardInvalidListIdIdArgumentProvider))]
        public void CheckCreateCardWithInvalidListID(CardIDArgumentHolder cardIDArgumentHolder)
        {
            var cardName = "New Done Card";
            var request = RequestWithAuth(CardEndpoints.CreateCardUrl)
                .AddOrUpdateParameters(cardIDArgumentHolder.PathParams)
                .AddJsonBody(new Dictionary<string, string> { { "name", cardName } });

            var response = _client.Post(request);

            Assert.That(response.StatusCode, Is.EqualTo(cardIDArgumentHolder.StatusCode));
            Assert.That(response.Content, Is.EqualTo(cardIDArgumentHolder.ErrorMessage));
        }

        [Test]
        [TestCaseSource(typeof(CardOtherListIdArgumentProvider))]
        public void CheckCreateCardWithOtherListID(CardIDArgumentHolder cardIDArgumentHolder)
        {
            var cardName = "New Done Card";
            var request = RequestWithAuth(CardEndpoints.CreateCardUrl)
                .AddOrUpdateParameters(cardIDArgumentHolder.PathParams)
                .AddJsonBody(new Dictionary<string, string> { { "name", cardName } });

            var response = _client.Post(request);

            Assert.That(response.StatusCode, Is.EqualTo(cardIDArgumentHolder.StatusCode));
            Assert.That(response.Content, Is.EqualTo(cardIDArgumentHolder.ErrorMessage));
        }

        [Test]
        [TestCaseSource(typeof(CreateCardNoAuthArgumentProvider))]
        public void ChekCreateCardWithNoAuth(CardIDArgumentHolder cardIDArgumentHolder)
        {
            var cardName = "New Done Card";
            var request = RequestWithoutAuth(CardEndpoints.CreateCardUrl)
               .AddOrUpdateParameters(cardIDArgumentHolder.PathParams)
               .AddJsonBody(new Dictionary<string, string> { { "name", cardName } });

            var response = _client.Post(request);

            Assert.That(response.StatusCode, Is.EqualTo(cardIDArgumentHolder.StatusCode));
            Assert.That(response.Content, Is.EqualTo(cardIDArgumentHolder.ErrorMessage));


        }
    }
}
