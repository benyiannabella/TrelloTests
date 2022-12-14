using GetListsTest.Arguments.Holders;
using GetListsTest.Arguments.Providers;
using GetListsTest.Constants;
using NUnit.Framework.Internal;

namespace GetListsTest.Tests.Get
{
    public class GetListValidationTests : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(ListsValidBoardIDArgumentProvider))]
        public void CheckGetListsOnABoard(ListsArgumentHolder listsValidIDArgument)
        {
            var request = RequestWithAuth(ListEndpoint.GetListsUrl)
                .AddQueryParameter("fields", "id,name")
                .AddOrUpdateParameters(listsValidIDArgument.PathParam);

            var response = _client.Get(request);
            Assert.That(response.StatusCode, Is.EqualTo(listsValidIDArgument.StatusCode));

            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_lists.json"));

            Assert.True(responseContent.IsValid(jsonSchema));
        }

        [Test]
        [TestCaseSource(typeof(ListValidIDArgumentProvider))]
        public void CheckGetListById(ListsArgumentHolder listsValidIDArgument)
        {
            var request = RequestWithAuth(ListEndpoint.GetAListUrl)
                .AddQueryParameter("fields", "id,name")
                .AddOrUpdateParameters(listsValidIDArgument.PathParam);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(listsValidIDArgument.StatusCode));
            Assert.That(JToken.Parse(response.Content).SelectToken("name").ToString, Is.EqualTo(listsValidIDArgument.ErrorMessage));

            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse(File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_a_list.json"));

            Assert.True(responseContent.IsValid(jsonSchema));
        }

        [Test]
        [TestCaseSource(typeof(ListInvalidIDArgumentProvider))]
        public void ChekGetListWithInvalidId(ListsArgumentHolder listsArgument)
        {
            var request = RequestWithAuth(ListEndpoint.GetAListUrl)
                .AddOrUpdateParameters(listsArgument.PathParam);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(listsArgument.StatusCode));

        }

        [Test]
        [TestCaseSource(typeof(ListInvalidAuthArgumentProvider))]
        public void CheckGetListWithInvalidAuth(ListsArgumentHolder listsArgument)
        {
            var request = RequestWithoutAuth(ListEndpoint.GetAListUrl)
                .AddQueryParameter("fields", "id,name")
                .AddOrUpdateParameters(listsArgument.PathParam);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(listsArgument.StatusCode));
            Assert.That(response.Content, Is.EqualTo(listsArgument.ErrorMessage));
        }

        [Test]
        [TestCaseSource(typeof(ListAuthOtherArgumentProvider))]
        public void CheckGetListWithOtherAuth(ListsArgumentHolder listsArgument)
        {
            var request = RequestWithoutAuth(ListEndpoint.GetAListUrl)
                .AddQueryParameter("fields", "id,name")
                .AddOrUpdateParameters(listsArgument.PathParam);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(listsArgument.StatusCode));
            Assert.That(response.Content, Is.EqualTo(listsArgument.ErrorMessage));
        }
    }
}