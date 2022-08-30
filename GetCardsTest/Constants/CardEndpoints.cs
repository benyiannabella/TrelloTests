
namespace GetCardsTest.Constants
{
    public class CardEndpoints
    {
        //for Get
        public const string GetCardsUrl = "/1/boards/{boardId}/cards";
        public const string GetACardUrl = "/1/cards/{cardId}";


        //for Post
        public const string CreateCardUrl = "/1/cards";
        public const string DeleteCardUrl = "/1/cards/{id}";
    }
}
