using GetCardsTest.Arguments.Holders;
using GetCardsTest.Constants;


namespace GetCardsTest.Arguments.Providers
{
    public class CardOtherListIdArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
            new CardIDArgumentHolder
                {
                    ErrorMessage = "could not find the board that the card belongs to",
                    StatusCode = HttpStatusCode.NotFound,
                    PathParams = new[] {new Parameter("idList", UrlParamValues.OtherListId, ParameterType.QueryString)}
                }
            };
        }
    }
}
