
using GetBoardsTest.Arguments.Holders;
using GetBoardsTest.Constants;

namespace GetCardsTest.Arguments.Providers
{
    public class CreateBoardNoAuthArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new BoardIdValidationArgumentsHolder
                {
               
                    StatusCode = HttpStatusCode.Unauthorized,
                    ErrorMessage  = "invalid key"
                }
            };
        }
    
    }
}
