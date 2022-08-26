
using GetCardsTest.Arguments.Holders;
using GetCardsTest.Constants;

namespace GetCardsTest.Arguments.Providers
{
    public class CardNoAuthArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new CardIDArgumentHolder
                {
                    PathParams = new[]{new Parameter("cardId", UrlParamValues.CardId, ParameterType.UrlSegment)},
                    StatusCode = HttpStatusCode.Unauthorized,
                    ErrorMessage  = "unauthorized card permission requested"
                }
            };
        }
    
    }
}
