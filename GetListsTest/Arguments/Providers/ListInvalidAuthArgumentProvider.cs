
using GetListsTest.Arguments.Holders;

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
                    PathParam = new[]{new Parameter("id", "6305229b7fad440060029406", ParameterType.UrlSegment)},
                    StatusCode = HttpStatusCode.Unauthorized,
                    ErrorMessage  = "unauthorized permission requested"
                }
            };
        }
    }
}
