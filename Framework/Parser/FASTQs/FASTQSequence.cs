using Framework.Commons;

namespace Framework.Parser.FASTQs
{
    public class FASTQSequence : IParserResult
    {
        public string Id { get; private set; }
        public byte[] SequenceData { get; private set; }
        public byte[] Scores { get; private set; }

        public FASTQSequence(string id, byte[] sequenceData, byte[] scores)
        {
            Id = id;
            SequenceData = sequenceData;
            Scores = scores;
        }
    }
}