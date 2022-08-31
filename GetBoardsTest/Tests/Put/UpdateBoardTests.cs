
using GetBoardsTest.Constants;

namespace GetBoardsTest.Tests.Put
{
    public class UpdateBoardTests : BaseTest
    {
        [Test]
        public void CheckUpdateBoard()
        {
            var updatedName = "New Board Name " + DateTime.Now.ToLongDateString();

            var request = RequestWithAuth(BoardsEndpoints.UpdateBoardUrl)
                .AddUrlSegment("boardId", UrlParamValues.BoardId)
                .AddJsonBody(new Dictionary<string, string> { { "name", updatedName } });

            var response = _client.Put(request);

            var responseContent = JToken.Parse(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseContent.SelectToken("name").ToString, Is.EqualTo(updatedName));

            request = RequestWithAuth(BoardsEndpoints.GetABoardUrl)
                .AddUrlSegment("boardId", UrlParamValues.BoardId);

            response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JToken.Parse(response.Content).SelectToken("name").ToString, Is.EqualTo(updatedName));
        }
    }
}
