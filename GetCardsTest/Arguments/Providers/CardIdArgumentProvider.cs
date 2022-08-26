using GetCardsTest.Arguments.Holders;
using System.Collections;

namespace GetCardsTest.Arguments.Providers
{
    public class CardIdArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new CardIDArgumentHolder
                {
                    ErrorMessage = "invalid id",
                    StatusCode = HttpStatusCode.BadRequest,
                    PathParams = new[] {new Parameter("cardId", "invalid", ParameterType.UrlSegment)}
                }
            };

            yield return new object[]
            {
            new CardIDArgumentHolder
                {
                    ErrorMessage = "The requested resource was not found.",
                    StatusCode = HttpStatusCode.NotFound,
                    PathParams = new[] {new Parameter("cardId", "6305f551c2aef000f7ed1c5c", ParameterType.UrlSegment)}
                }
            };
        }
    }
}
