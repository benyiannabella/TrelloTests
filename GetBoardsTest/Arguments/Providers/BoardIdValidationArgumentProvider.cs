
using GetBoardsTest.Arguments.Holders;
using System.Collections;

namespace GetBoardsTest.Arguments.Providers
{
    public class BoardIdValidationArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new BoardIdValidationArgumentsHolder
                {
                    ErrorMessage = "invalid id",
                    StatusCode = HttpStatusCode.BadRequest,
                    PathParams = new[] {new Parameter("boardId", "invalid", ParameterType.UrlSegment)}
                }
            };

            yield return new object[]
            {
                new BoardIdValidationArgumentsHolder
                {
                    ErrorMessage = "The requested resource was not found.",
                    StatusCode = HttpStatusCode.NotFound,
                    PathParams = new[] {new Parameter("boardId", "63067787a84cf200b6d77501", ParameterType.UrlSegment)}
                }
            };
        }
    }
}
