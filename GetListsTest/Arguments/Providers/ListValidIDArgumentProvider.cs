
using GetListsTest.Arguments.Holders;

namespace GetListsTest.Arguments.Providers
{
    internal class ListValidIDArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new ListsArgumentHolder
                {
                    PathParam = new[]{new Parameter("id", "6305229b7fad440060029406", ParameterType.UrlSegment) },
                    ErrorMessage = "To Do",
                    StatusCode = HttpStatusCode.OK
                }
            };
        }
    }
}
