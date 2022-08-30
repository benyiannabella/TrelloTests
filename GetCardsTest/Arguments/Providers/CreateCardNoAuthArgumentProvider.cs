
using GetCardsTest.Arguments.Holders;
using GetCardsTest.Constants;

namespace GetCardsTest.Arguments.Providers
{
    public class CreateCardNoAuthArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new CardIDArgumentHolder
                {
                    PathParams = new[] {new Parameter("idList", UrlParamValues.ListId, ParameterType.QueryString)},
                    StatusCode = HttpStatusCode.Unauthorized,
                    ErrorMessage  = "invalid key"
                }
            };
        }
    
    }
}
