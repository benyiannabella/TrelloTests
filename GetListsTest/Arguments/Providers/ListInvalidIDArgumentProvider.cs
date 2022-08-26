
using GetListsTest.Arguments.Holders;

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
                    PathParam = new[]{new Parameter("id", "6305229b7fad440060029405", ParameterType.UrlSegment)},
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessage  = "The requested resource was not found."
                }
            };
        }
    }
}
