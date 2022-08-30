
using GetBoardsTest.Constants;

namespace GetBoardsTest.Tests.Post
{
    public class CreateBoardTest : BaseTest
    {
        private string _createdBoardId;

        [Test]
        public void CheckCreateBoard()
        {
            var boardName = "New Board" + DateTime.Now.ToLongTimeString();

            var request = RequestWithAuth(BoardsEndpoints.CreateBoardUrl)
                .AddJsonBody(new Dictionary<string, string> { { "name", boardName } });

            var response = _client.Post(request);

            var responseContent = JToken.Parse(response.Content);
            _createdBoardId = responseContent.SelectToken("id").ToString();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseContent.SelectToken("name").ToString, Is.EqualTo(boardName));

            //check the results
            request = RequestWithAuth(BoardsEndpoints.GetBoardsUrl)
                .AddQueryParameter("fields", "id,name")
                .AddUrlSegment("memberId", UrlParamValues.UserId);

            response = _client.Get(request);
            responseContent = JToken.Parse(response.Content);

            Assert.True(responseContent.Children().Select(token => token.SelectToken("name")).Contains(boardName));
        }

        [TearDown]
        public void DeleteCreatedBoard()
        {
            var request = RequestWithAuth(BoardsEndpoints.DeleteBoardUrl)
                .AddUrlSegment("id", _createdBoardId);
            var response = _client.Delete(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
    }
   
}
