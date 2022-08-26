
using GetCardsTest.Arguments.Holders;
using GetCardsTest.Arguments.Providers;

namespace GetCardsTest
{
    public class GetCardValidationTests : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(CardIdArgumentProvider))]
        public void CheckGetCardWithInvalidId(CardIDArgumentHolder cardIDArgument)
        {
            var request = RequestWithAuth("/1/cards/{cardId}")
                .AddOrUpdateParameters(cardIDArgument.PathParams);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(cardIDArgument.StatusCode));
            Assert.That(response.Content, Is.EqualTo(cardIDArgument.ErrorMessage));

        }

        [Test]
        [TestCaseSource(typeof(CardNoAuthArgumentProvider))]
        public void CheckGetCardWithInvalidAut(CardIDArgumentHolder cardIDArgument)
        {
            var request = RequestWithoutAuth("/1/cards/{cardId}")
                .AddOrUpdateParameters(cardIDArgument.PathParams);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(cardIDArgument.StatusCode));
            Assert.That(response.Content, Is.EqualTo(cardIDArgument.ErrorMessage));
        }


        [Test]
        [TestCaseSource(typeof(CardOtherAuthArgumentProvider))]
        public void CheckGetCardWithOtherKeyOrToken(CardIDArgumentHolder cardIDArgument)
        {
            var request = RequestWithoutAuth("/1/cards/{cardId}")
                .AddOrUpdateParameters(cardIDArgument.PathParams)
                .AddUrlSegment("cardId", "6305f551c2aef000f7ed1c5d");

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(cardIDArgument.StatusCode));
            Assert.That(response.Content, Is.EqualTo(cardIDArgument.ErrorMessage));
        }

    }
}