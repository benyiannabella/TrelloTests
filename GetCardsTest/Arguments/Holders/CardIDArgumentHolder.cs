
namespace GetCardsTest.Arguments.Holders
{
    public class CardIDArgumentHolder
    {
        public IEnumerable<Parameter> PathParams { get; set; }

        public string ErrorMessage { get; set; }    

        public HttpStatusCode StatusCode { get; set; }  

    }
}
