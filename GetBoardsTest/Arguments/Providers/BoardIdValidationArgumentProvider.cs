
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
                    PathParams = new[] {new Parameter("id", "invalid", ParameterType.UrlSegment)}
                }
            };

            yield return new object[]
            {
                new BoardIdValidationArgumentsHolder
                {
                    ErrorMessage = "The requested resource was not found.",
                    StatusCode = HttpStatusCode.NotFound,
                    PathParams = new[] {new Parameter("boardId", "6305229b7fad4400600293fe", ParameterType.UrlSegment)}
                }
            };
        }
    }
}
