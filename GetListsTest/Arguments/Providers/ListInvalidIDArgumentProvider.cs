
using GetListsTest.Arguments.Holders;
using GetListsTest.Constants;

namespace GetListsTest.Arguments.Providers
{
    public class ListInvalidIDArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new ListsArgumentHolder
                {
                    PathParam = new[]{new Parameter("id", "invalid", ParameterType.UrlSegment)},
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessage  = "invalid id"
                }
            };

            yield return new object[]
            {
                new ListsArgumentHolder
                {
                    PathParam = new[]{new Parameter("id", UrlParamValues.InvalidListId, ParameterType.UrlSegment)},
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessage  = "The requested resource was not found."
                }
            };
        }
    }
}
