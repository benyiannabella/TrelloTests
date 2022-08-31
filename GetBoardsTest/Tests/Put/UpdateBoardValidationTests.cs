
using GetBoardsTest.Arguments.Holders;
using GetBoardsTest.Arguments.Providers;
using GetBoardsTest.Constants;
using GetCardsTest.Arguments.Providers;

namespace GetBoardsTest.Tests.Put
{
    public class UpdateBoardValidationTests : BaseTest
    {

        [Test]
        [TestCaseSource(typeof(BoardIdValidationArgumentProvider))]
        public void CheckUpdateBoardWithInvalidId(BoardIdValidationArgumentsHolder boardIdValidation)
        {
            var updatedName = "New Board Name";

            var request = RequestWithAuth(BoardsEndpoints.UpdateBoardUrl)
                .AddOrUpdateParameters(boardIdValidation.PathParams)
                .AddJsonBody(new Dictionary<string, string> { { "name", updatedName } });

            var response = _client.Put(request);

            Assert.AreEqual(boardIdValidation.StatusCode, response.StatusCode);
            Assert.AreEqual(boardIdValidation.ErrorMessage, response.Content);

        }

        [Test]
        [TestCaseSource(typeof(UpdateBoardNoAuthArgumentProvider))]
        public void CheckUpdateBoardWithNoAuth(BoardIdValidationArgumentsHolder boardIdValidation)
        {
            var updatedName = "New Board Name";

            var request = RequestWithoutAuth(BoardsEndpoints.UpdateBoardUrl)
                .AddOrUpdateParameters(boardIdValidation.PathParams)
                .AddJsonBody(new Dictionary<string, string> { { "name", updatedName } });

            var response = _client.Put(request);

            Assert.AreEqual(boardIdValidation.StatusCode, response.StatusCode);
            Assert.AreEqual(boardIdValidation.ErrorMessage, response.Content);

        }

    }
}
