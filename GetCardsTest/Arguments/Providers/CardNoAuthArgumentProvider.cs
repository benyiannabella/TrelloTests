
using GetCardsTest.Arguments.Holders;

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
                    PathParams = new[]{new Parameter("cardId", "6305f551c2aef000f7ed1c5d", ParameterType.UrlSegment)},
                    StatusCode = HttpStatusCode.Unauthorized,
                    ErrorMessage  = "unauthorized card permission requested"
                }
            };
        }
    
    }
}
