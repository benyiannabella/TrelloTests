
using GetCardsTest.Arguments.Holders;
using GetCardsTest.Constants;

namespace GetCardsTest.Arguments.Providers
{
    internal class CardOtherAuthArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new CardIDArgumentHolder
                {
                   PathParams = new[]{new Parameter("key", UrlParamValues.OtherKey, ParameterType.QueryString),
                       new Parameter("token", UrlParamValues.Token, ParameterType.QueryString)},
                   ErrorMessage = "invalid key",
                   StatusCode = HttpStatusCode.Unauthorized
                }

            };

            yield return new object[]
            {
                new CardIDArgumentHolder
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
