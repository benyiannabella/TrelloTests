
namespace GetListsTest.Arguments.Holders
{
    public class ListsArgumentHolder
    {
        public IEnumerable<Parameter> PathParam { get; set; }

        public string ErrorMessage { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
