
using GetCardsTest.Arguments.Holders;
using GetCardsTest.Constants;

namespace GetCardsTest.Arguments.Providers
{
    public class UpdateCardNoAuthArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new CardIDArgumentHolder
                {
                    PathParams = new[]{new Parameter("cardId", UrlParamValues.CardId, ParameterType.UrlSegment)},
                    StatusCode = HttpStatusCode.Unauthorized,
                    ErrorMessage  = "invalid key"
                }
            };
        }
    
    }
}
