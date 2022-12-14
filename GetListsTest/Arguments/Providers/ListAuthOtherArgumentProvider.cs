
using GetListsTest.Arguments.Holders;
using GetListsTest.Constants;

namespace GetListsTest.Arguments.Providers
{
    internal class ListAuthOtherArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
               new ListsArgumentHolder
               {
                   PathParam = new[]{new Parameter("key",UrlParamValues.OtherKey, ParameterType.QueryString), 
                       new Parameter("token", UrlParamValues.Token, ParameterType.QueryString)},
                   ErrorMessage = "invalid key",
                   StatusCode = HttpStatusCode.Unauthorized
               }
            };

            yield return new object[]
            {
               new ListsArgumentHolder
               {
                   PathParam = new[]{ new Parameter("key", UrlParamValues.Key, ParameterType.QueryString),
                       new Parameter("token", UrlParamValues.OtherToken, ParameterType.QueryString)},
                   ErrorMessage = "invalid token",
                   StatusCode = HttpStatusCode.Unauthorized
               }
            };
        }
    }
}
