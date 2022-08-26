
using GetListsTest.Arguments.Holders;

namespace GetListsTest.Arguments.Providers
{
    internal class ListAuthOtherArgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
               new ListsArgumentHolder
               {
                   PathParam = new[]{new Parameter("key", "9412ec2fd86e5bd8a69c359da63744d7", ParameterType.QueryString), 
                       new Parameter("token", "868e793c460a02759265b6da6ab8f535c08653d91045ae4a06eff6adfe6fc2c1", ParameterType.QueryString)},
                   ErrorMessage = "invalid key",
                   StatusCode = HttpStatusCode.Unauthorized
               }
            };

            yield return new object[]
            {
               new ListsArgumentHolder
               {
                   PathParam = new[]{ new Parameter("key", "9412ec2fd86e5bd8a69c359da63744d8", ParameterType.QueryString),
                       new Parameter("token", "868e793c460a02759265b6da6ab8f535c08653d91045ae4a06eff6adfe6fc2c2", ParameterType.QueryString)},
                   ErrorMessage = "invalid token",
                   StatusCode = HttpStatusCode.Unauthorized
               }
            };
        }
    }
}
