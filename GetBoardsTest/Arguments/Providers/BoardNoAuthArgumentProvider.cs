
using GetBoardsTest.Arguments.Holders;
using GetBoardsTest.Constants;

namespace GetCardsTest.Arguments.Providers
{
    public class BoardNoAuthArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new BoardIdValidationArgumentsHolder
                {
                    PathParams = new[]{new Parameter("boardId", UrlParamValues.BoardId, ParameterType.UrlSegment)},
                    StatusCode = HttpStatusCode.Unauthorized,
                    ErrorMessage  = "unauthorized permission requested"
                }
            };
        }
    
    }
}
