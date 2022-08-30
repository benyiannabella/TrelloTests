
namespace GetListsTest.Constants
{
    public class ListEndpoint
    {
        //for Get
        public const string GetListsUrl = "/1/boards/{boardId}/lists";
        public const string GetAListUrl = "/1/lists/{id}";


        //for Post
        public const string CreateListUrl = "/1/boards/{id}/lists";
        public const string ArchiveListUrl = "/1/lists/{id}/closed";
    }
}
