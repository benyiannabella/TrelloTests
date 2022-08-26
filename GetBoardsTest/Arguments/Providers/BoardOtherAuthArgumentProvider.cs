
using GetBoardsTest.Arguments.Holders;
using GetBoardsTest.Constants;

namespace GetCardsTest.Arguments.Providers
{
    internal class BoardOtherAuthArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new BoardIdValidationArgumentsHolder
                {
                   PathParams = new[]{new Parameter("key", UrlParamValues.OtherKey, ParameterType.QueryString),
                       new Parameter("token", UrlParamValues.Token, ParameterType.QueryString)},
                   ErrorMessage = "invalid key",
                   StatusCode = HttpStatusCode.Unauthorized
                }

            };

            yield return new object[]
            {
                new BoardIdValidationArgumentsHolder
                {
                   PathParams = new[]{ new Parameter("key", UrlParamValues.Key, ParameterType.QueryString),
                       new Parameter("token", UrlParamValues.OtherToken, ParameterType.QueryString)},
                   ErrorMessage = "invalid token",
                   StatusCode = HttpStatusCode.Unauthorized
                }

            };
        }
    }
}
