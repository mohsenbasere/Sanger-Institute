using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Framework.Parser.FASTQs
{
    public partial class FASTQParser
    {
        private static string ProcessLineOne(TextReader reader)
        {
            var line = ReadNextLine(reader);
            GuardAgainstLineOneIsInvalid(line);
            var id = line?.Split(' ');
            return id.FirstOrDefault();
        }

        private static byte[] ProcessLineTwo(TextReader reader, string id)
        {
            var line = ReadNextLine(reader);
            GuardAgainstLineTwoIsEmpty(id, line);
            var sequenceData = Encoding.Default.GetBytes(line);
            return sequenceData;
        }

        private static void ProcessLineThree(TextReader reader, string id)
        {
            var line = ReadNextLine(reader);
            GuardAgainstCheckPlusInLineThree(id, line);
            var qualityId = line?.Substring(1).Trim();
            GuardAgainstMatchScoresHeaderWithSequenceHeader(id, qualityId);
        }

        private static byte[] ProcessLineFour(TextReader reader, string id, IReadOnlyCollection<byte> sequenceData)
        {
            var line = ReadNextLine(reader);

            GuardAgainstQualityScoresIsEmpty(id, line);

            var qualityScores = Encoding.Default.GetBytes(line);

            GuardAgainstMatchNumberOfTotalScoresAndSequence(id, sequenceData, qualityScores);

            return qualityScores;
        }

        private static string? ReadNextLine(TextReader reader)
        {
            var line = reader.ReadLine();
            while (line != null && string.IsNullOrEmpty(line))
            {
                line = reader.ReadLine();
            }

            return line;
        }
    }
}