
using GetListsTest.Arguments.Holders;
using GetListsTest.Constants;

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
                    PathParam = new[]{new Parameter("id", UrlParamValues.ListId, ParameterType.UrlSegment) },
                    ErrorMessage = "To Do",
                    StatusCode = HttpStatusCode.OK
                }
            };
        }
    }
}
