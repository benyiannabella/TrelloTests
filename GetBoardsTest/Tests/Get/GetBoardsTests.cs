using GetBoardsTest.Constants;
using GetBoardsTest.Tests;

namespace GetBoardsTest.Tests.Get
{
    public class GetBoardsTests : BaseTest
    {
        [Test]
        public void CheckGetBoards()
        {
            var request = RequestWithAuth(BoardsEndpoints.GetBoardsUrl)
                .AddQueryParameter("fields", "id,name")
                .AddUrlSegment("memberId", UrlParamValues.UserId);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse
                    (File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_boards.json"));
            Assert.True(responseContent.IsValid(jsonSchema));
        }

        [Test]
        public void CheckGetBoard()
        {
            var request = RequestWithAuth(BoardsEndpoints.GetABoardUrl)
                 .AddQueryParameter("fields", "id,name")
                 .AddUrlSegment("boardId", UrlParamValues.BoardId);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(JToken.Parse(response.Content).SelectToken("name").ToString, Is.EqualTo("My New board"));

            var responseContent = JToken.Parse(response.Content);
            var jsonSchema = JSchema.Parse
                (File.ReadAllText($"{Directory.GetCurrentDirectory()}/Resources/Schemas/get_a_board.json"));

            Assert.True(responseContent.IsValid(jsonSchema));
        }
    }
}