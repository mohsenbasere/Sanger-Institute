using System.Collections.Generic;
using System.IO;
using System.Text;
using Framework.Commons;

namespace Framework.Parser.FASTQs
{
    public partial class FASTQParser : IParser<FASTQSequence>
    {
        public IEnumerable<FASTQSequence> Parse(Stream stream)
        {
            using var reader = new StreamReader(stream, Encoding.UTF8);
            while (reader.Peek() != -1)
            {
                var sequence = ParseOneSequence(reader);
                yield return sequence;
            }
        }

        private static FASTQSequence ParseOneSequence(TextReader reader)
        {
            var id = ProcessLineOne(reader);
            var sequenceData = ProcessLineTwo(reader, id);
            ProcessLineThree(reader, id);
            var qualityScores = ProcessLineFour(reader, id, sequenceData);
            return new FASTQSequence(id, sequenceData, qualityScores);
        }

    }
}