using System;
using System.Collections.Generic;
using static Framework.Resources.Message;


namespace Framework.Parser.FASTQs
{
    public partial class FASTQParser
    {
        private static void GuardAgainstLineOneIsInvalid(string? line)
        {
            if (line == null || !line.StartsWith("@", StringComparison.Ordinal))
            {
                throw new Exception($"{BAD_INPUT} {line}");
            }
        }

        private static void GuardAgainstLineTwoIsEmpty(string id, string? line)
        {
            if (string.IsNullOrEmpty(line))
            {
                throw new Exception($"{LINE_TWO_VALIDATION} {id}");
            }
        }

        private static void GuardAgainstCheckPlusInLineThree(string id, string? line)
        {
            if (line == null || !line.StartsWith("+", StringComparison.Ordinal))
            {
                throw new Exception($"{CHECK_PLUS} {id}");
            }
        }

        private static void GuardAgainstMatchScoresHeaderWithSequenceHeader(string id, string qualityId)
        {
            if (!string.IsNullOrEmpty(qualityId) && !id.Equals(qualityId))
            {
                throw new Exception($"{MATCH_HEADER} {id}");
            }
        }

        private static void GuardAgainstQualityScoresIsEmpty(string id, string? line)
        {
            if (string.IsNullOrEmpty(line))
            {
                throw new Exception($"{LINE_THREE_VALIDATION} {id}");
            }
        }

        private static void GuardAgainstMatchNumberOfTotalScoresAndSequence(string id,
            IReadOnlyCollection<byte> sequenceData,
            IReadOnlyCollection<byte> qualityScores)
        {
            //TODO: check document
            if (sequenceData.Count != qualityScores.Count)
            {
                throw new Exception($"{MATCH_TOTAL_NUMBER_OF_SYMBOL} {id}");
            }
        }
    }
}