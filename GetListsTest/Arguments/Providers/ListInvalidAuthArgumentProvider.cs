
using GetListsTest.Arguments.Holders;
using GetListsTest.Constants;

namespace GetListsTest.Arguments.Providers
{
    public class ListInvalidAuthArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new ListsArgumentHolder
                {
                    PathParam = new[]{new Parameter("id", UrlParamValues.ListId, ParameterType.UrlSegment)},
                    StatusCode = HttpStatusCode.Unauthorized,
                    ErrorMessage  = "unauthorized permission requested"
                }
            };
        }
    }
}
