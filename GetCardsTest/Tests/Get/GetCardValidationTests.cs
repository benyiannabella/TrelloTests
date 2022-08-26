using GetCardsTest.Arguments.Holders;
using GetCardsTest.Arguments.Providers;
using GetCardsTest.Constants;

namespace GetCardsTest.Tests.Get
{
    public class GetCardValidationTests : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(CardIdArgumentProvider))]
        public void CheckGetCardWithInvalidId(CardIDArgumentHolder cardIDArgument)
        {
            var request = RequestWithAuth(CardEndpoints.GetACardUrl)
                .AddOrUpdateParameters(cardIDArgument.PathParams);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(cardIDArgument.StatusCode));
            Assert.That(response.Content, Is.EqualTo(cardIDArgument.ErrorMessage));

        }

        [Test]
        [TestCaseSource(typeof(CardNoAuthArgumentProvider))]
        public void CheckGetCardWithInvalidAut(CardIDArgumentHolder cardIDArgument)
        {
            var request = RequestWithoutAuth(CardEndpoints.GetACardUrl)
                .AddOrUpdateParameters(cardIDArgument.PathParams);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(cardIDArgument.StatusCode));
            Assert.That(response.Content, Is.EqualTo(cardIDArgument.ErrorMessage));
        }


        [Test]
        [TestCaseSource(typeof(CardOtherAuthArgumentProvider))]
        public void CheckGetCardWithOtherKeyOrToken(CardIDArgumentHolder cardIDArgument)
        {
            var request = RequestWithoutAuth(CardEndpoints.GetACardUrl)
                .AddOrUpdateParameters(cardIDArgument.PathParams)
                .AddUrlSegment("cardId", UrlParamValues.CardId);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(cardIDArgument.StatusCode));
            Assert.That(response.Content, Is.EqualTo(cardIDArgument.ErrorMessage));
        }

    }
}