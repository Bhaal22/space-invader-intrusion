using System.Collections.Generic;

namespace space_invader
{
    internal sealed class Palantir : IPalantir
    {
        public bool Match(Image sourceImage, Image patternToSearch)
        {
            int currentSourceLineIndex = 0;
            bool match = false;

            var firstPatternLine = patternToSearch.ImageContent[0];
            while ((currentSourceLineIndex < sourceImage.ImageContent.Count) && !match)
            {
                var currentSourceLine = sourceImage.ImageContent[currentSourceLineIndex];

                var matchingIndexes = RetrieveAllPatternIndexes(currentSourceLine, firstPatternLine);
                if (matchingIndexes.Count != 0)
                {
                    foreach(var index in matchingIndexes)
                    {
                        match = CheckLineByLine(index, sourceImage, currentSourceLineIndex, patternToSearch);
                        if (match)
                            break;
                    }
                }

                currentSourceLineIndex++;
            }
            return match;
        }

        public List<int> RetrieveAllPatternIndexes(string sourceLine, string firstLinePattern)
        {
            List<int> matchingIndexes = new List<int>();

            int numberOfChars = sourceLine.Length;

            for(int charIndex = 0; charIndex < sourceLine.Length - firstLinePattern.Length + 1; charIndex++)
            {
                var sub = sourceLine.Substring(charIndex, firstLinePattern.Length);
                if (sub == firstLinePattern)
                    matchingIndexes.Add(charIndex);
            }

            return matchingIndexes;
        }

        public bool CheckLineByLine(int startIndex, Image sourceImage, int sourceLineIndex, Image patternToSearch)
        {
            if (sourceLineIndex + patternToSearch.ImageContent.Count > sourceImage.ImageContent.Count)
                return false;

            var match = true;

            int index = sourceLineIndex;
            for (var patternLineIndex = 0; patternLineIndex < patternToSearch.ImageContent.Count; patternLineIndex++)
            {
                var line = sourceImage.ImageContent[sourceLineIndex];
                var pattern = patternToSearch.ImageContent[patternLineIndex];

                var subAtIndex = line.Substring(startIndex, pattern.Length);
                match &= (subAtIndex == pattern);

                sourceLineIndex++;
                if (!match)
                    break;
            }

            return match;
        }
    }
}
