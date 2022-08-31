
namespace GetBoardsTest.Constants
{
    public class BoardsEndpoints
    {

        //for get
        public const string GetABoardUrl = "/1/boards/{boardId}";
        public const string GetBoardsUrl = "/1/members/{memberId}/boards";

        //for post
        public const string CreateBoardUrl = "/1/boards";
        public const string DeleteBoardUrl = "/1/boards/{id}";

        //for put
        public const string UpdateBoardUrl = "/1/boards/{boardId}";
    }
}
