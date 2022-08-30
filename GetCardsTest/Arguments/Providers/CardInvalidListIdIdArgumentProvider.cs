using GetCardsTest.Arguments.Holders;
using GetCardsTest.Constants;
using System.Collections;

namespace GetCardsTest.Arguments.Providers
{
    public class CardInvalidListIdIdArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new CardIDArgumentHolder
                {
                    ErrorMessage = "invalid value for idList",
                    StatusCode = HttpStatusCode.BadRequest,
                    PathParams = new[] {new Parameter("idList", "invalid", ParameterType.UrlSegment)}
                }
            };


        }
    }
}
