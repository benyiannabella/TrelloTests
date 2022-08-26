
using GetListsTest.Arguments.Holders;
using GetListsTest.Constants;

namespace GetListsTest.Arguments.Providers
{
    public class ListsValidBoardIDArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]

            {
                new ListsArgumentHolder
                {
                    PathParam = new[]{new Parameter("boardId", UrlParamValues.BoardId, ParameterType.UrlSegment)},
                    StatusCode = HttpStatusCode.OK,
                    ErrorMessage = "To Do"
                }
            };

        }
    }
}
