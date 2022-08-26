using GetBoardsTest.Arguments.Holders;
using GetBoardsTest.Arguments.Providers;

namespace GetBoardsTest
{
    public class GetBoardsValidaionTests : BaseTest
    {

        [Test]
        [TestCaseSource(typeof(BoardIdValidationArgumentProvider))]
        public void CheckGetBoardWithInvalidID(BoardIdValidationArgumentsHolder validationArguments)
        {
            var request = RequestWitAuth("/1/boards/{boardId}")
                 .AddOrUpdateParameters(validationArguments.PathParams);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(validationArguments.StatusCode));
            Assert.That(response.Content, Is.EqualTo(validationArguments.ErrorMessage));
        }

        [Test]
        public void CheckGetBoardWithInvlidAuth()
        {
            var request = RequestWithoutAuth("/1/boards/{boardId}")
               .AddUrlSegment("boardId", "63067787a84cf200b6d77500");

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Content, Is.EqualTo("unauthorized permission requested"));
        }

        [Test]
        public void CheckGetBoardWithOtherUsersToken()
        {
            var request = RequestWithoutAuth("/1/boards/{boardId}")
                .AddQueryParameter("key", "9412ec2fd86e5bd8a69c359da63744d8")
                .AddQueryParameter("token", "868e793c460a02759265b6da6ab8f535c08653d91045ae4a06eff6adfe6fc2c2")
                .AddUrlSegment("boardId", "63067787a84cf200b6d77500");

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Content, Is.EqualTo("invalid token"));

        }

        [Test]
        public void CheckGetBoardWithOtherUsersKey()
        {
            var request = RequestWithoutAuth("/1/boards/{boardId}")
                .AddQueryParameter("key", "9412ec2fd86e5bd8a69c359da63744d7")
                .AddQueryParameter("token", "868e793c460a02759265b6da6ab8f535c08653d91045ae4a06eff6adfe6fc2c1")
                .AddUrlSegment("boardId", "63067787a84cf200b6d77500");

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Content, Is.EqualTo("invalid key"));

        }
    }

   
}