using System.Collections;

namespace WebApi.test.InlineData;
public class CultureInlineDataTest : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "fr" };
        yield return new object[] { "pt-BR" };
        yield return new object[] { "en" };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
