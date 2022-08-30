using GetBoardsTest.Arguments.Holders;
using System.Collections.Immutable;

namespace GetBoardsTest.Arguments.Providers
{
    public class BoardNameValidationArrgumentProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
               new Dictionary<string,object>{{"name", 12345}}
            };

            yield return new object[]
            {
               ImmutableDictionary<string,object>.Empty
            };
        }
    }
}
