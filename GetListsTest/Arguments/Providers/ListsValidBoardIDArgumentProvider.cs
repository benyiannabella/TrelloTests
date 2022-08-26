
using GetListsTest.Arguments.Holders;

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
                    PathParam = new[]{new Parameter("boardId", "6305229b7fad4400600293ff", ParameterType.UrlSegment)},
                    StatusCode = HttpStatusCode.OK,
                    ErrorMessage = "To Do"
                }
            };

        }
    }
}
