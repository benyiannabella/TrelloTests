
using GetCardsTest.Arguments.Holders;
using GetCardsTest.Arguments.Providers;
using GetCardsTest.Constants;

namespace GetCardsTest.Tests.Put
{
    public class UpdateCardValidationTests : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(CardIdArgumentProvider))]
        public void UpdateCardInvalidId(CardIDArgumentHolder cardIDArgument)
        {
            var updatedName = "My New Card Name";

            var request = RequestWithAuth(CardEndpoints.UpdateCradUrl)
                .AddOrUpdateParameters(cardIDArgument.PathParams)
                .AddJsonBody(new Dictionary<string, string> { { "name", updatedName } });

            var response = _client.Put(request);

            Assert.That(response.StatusCode, Is.EqualTo(cardIDArgument.StatusCode));
            Assert.That(response.Content, Is.EqualTo(cardIDArgument.ErrorMessage));

        }

        [Test]
        [TestCaseSource(typeof(UpdateCardNoAuthArgumentProvider))]
        public void UpdateCardNoAuth(CardIDArgumentHolder cardIDArgument)
        {
            var updatedName = "My New Card Name";

            var request = RequestWithoutAuth(CardEndpoints.UpdateCradUrl)
                .AddOrUpdateParameters(cardIDArgument.PathParams)
                .AddJsonBody(new Dictionary<string, string> { { "name", updatedName } });

            var response = _client.Put(request);

            Assert.That(response.StatusCode, Is.EqualTo(cardIDArgument.StatusCode));
            Assert.That(response.Content, Is.EqualTo(cardIDArgument.ErrorMessage));

        }


    }
}
