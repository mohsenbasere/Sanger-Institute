using System.Collections.Generic;
using System.IO;

namespace Framework.Commons
{
    public interface IParser<out T> where T : IParserResult
    {
        public IEnumerable<T> Parse(Stream stream);
    }
}