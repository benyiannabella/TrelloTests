
using GetListsTest.Constants;
using System.Runtime.CompilerServices;

namespace GetListsTest.Tests.Post
{
    public class CreateListsTest : BaseTest
    {
        private string _createListId;
        [Test]
        public void CheckCreateList()
        {

            //create
            var listName = "My Done List " + DateTime.Now.ToLongDateString();

            var request = RequestWithAuth(ListEndpoint.CreateListUrl)
                .AddUrlSegment("id", UrlParamValues.BoardId)
                .AddJsonBody(new Dictionary<string, string> { { "name", listName } });

            var response = _client.Post(request);

            var responseContent = JToken.Parse(response.Content);
            _createListId = responseContent.SelectToken("id").ToString();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseContent.SelectToken("name").ToString(), Is.EqualTo(listName));

            //check created

            request = RequestWithAuth(ListEndpoint.GetListsUrl)
                .AddQueryParameter("fields", "id,name")
                .AddUrlSegment("boardId", UrlParamValues.BoardId);

            response = _client.Get(request);
            responseContent = JToken.Parse(response.Content);

            Assert.True(responseContent.Children().Select(token=> token.SelectToken("name")).Contains(listName));

        }

        [TearDown]
        public void ArchiveNewList()
        {
            var request = RequestWithAuth(ListEndpoint.ArchiveListUrl)
                .AddUrlSegment("id", _createListId)
                .AddQueryParameter("value", "true");

            var response = _client.Put(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
