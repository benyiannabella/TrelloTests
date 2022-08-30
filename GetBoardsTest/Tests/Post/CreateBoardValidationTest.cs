using GetBoardsTest.Arguments.Holders;
using GetBoardsTest.Arguments.Providers;
using GetBoardsTest.Constants;
using GetCardsTest.Arguments.Providers;
using NUnit.Framework;

namespace GetBoardsTest.Tests.Post
{
    public class CreateBoardValidationTest : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BoardNameValidationArrgumentProvider))]
        public void CheckCreateBoardWithInvalidName(IDictionary<string, object> bodyParams)
        {
            var request = RequestWithAuth(BoardsEndpoints.CreateBoardUrl)
                .AddJsonBody(bodyParams);

            var response = _client.Post(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Content, Is.EqualTo("invalid value for name"));
        }

        [Test]
        [TestCaseSource(typeof(CreateBoardNoAuthArgumentProvider))]
        public void CheckCreateBoardWithInvlidAuth(BoardIdValidationArgumentsHolder boardIdValidationArguments)
        {
            var boardName = "New Board";
            var request = RequestWithoutAuth(BoardsEndpoints.CreateBoardUrl)
               .AddJsonBody(new Dictionary<string, string> { { "name", boardName } });

            var response = _client.Post(request);

            Assert.That(response.StatusCode, Is.EqualTo(boardIdValidationArguments.StatusCode));
            Assert.That(response.Content, Is.EqualTo(boardIdValidationArguments.ErrorMessage));
        }

    }
}
