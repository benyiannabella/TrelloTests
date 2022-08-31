using GetBoardsTest.Arguments.Holders;
using GetBoardsTest.Arguments.Providers;
using GetBoardsTest.Constants;
using GetCardsTest.Arguments.Providers;

namespace GetBoardsTest.Tests.Get
{
    public class GetBoardsValidaionTests : BaseTest
    {

        [Test]
        [TestCaseSource(typeof(BoardIdValidationArgumentProvider))]
        public void CheckGetBoardWithInvalidID(BoardIdValidationArgumentsHolder validationArguments)
        {
            var request = RequestWithAuth(BoardsEndpoints.GetABoardUrl)
                 .AddOrUpdateParameters(validationArguments.PathParams);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(validationArguments.StatusCode));
            Assert.That(response.Content, Is.EqualTo(validationArguments.ErrorMessage));
        }

        [Test]
        [TestCaseSource(typeof(BoardNoAuthArgumentProvider))]
        public void CheckGetBoardWithInvlidAuth(BoardIdValidationArgumentsHolder boardIdValidationArguments)
        {
            var request = RequestWithoutAuth(BoardsEndpoints.GetABoardUrl)
               .AddOrUpdateParameters(boardIdValidationArguments.PathParams);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(boardIdValidationArguments.StatusCode));
            Assert.That(response.Content, Is.EqualTo(boardIdValidationArguments.ErrorMessage));
        }

        [Test]
        [TestCaseSource(typeof(BoardOtherAuthArgumentProvider))]
        public void CheckGetBoardWithOtherUsersToken(BoardIdValidationArgumentsHolder boardIdValidationArguments)
        {
            var request = RequestWithoutAuth(BoardsEndpoints.GetABoardUrl)
                .AddUrlSegment("boardId", UrlParamValues.BoardIdGet)
                .AddOrUpdateParameters(boardIdValidationArguments.PathParams);

            var response = _client.Get(request);

            Assert.That(response.StatusCode, Is.EqualTo(boardIdValidationArguments.StatusCode));
            Assert.That(response.Content, Is.EqualTo(boardIdValidationArguments.ErrorMessage));

        }

    }


}