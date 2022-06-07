using System.Collections.Generic;
using System;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var separators = new char[] { '.', '!', '?', ';', ':', '(', ')' };

            var textProcessed = text.Split(separators);
            for (int i = 0; i < textProcessed.Length; i++)
            {
                if (textProcessed[i].Length > 0 && ParseWords(textProcessed[i]) != null) sentencesList.Add(ParseWords(textProcessed[i]));
            }

            return sentencesList;
        }

        public static List<string> ParseWords(string text)
        {
            var wordsList = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (!(char.IsLetter(text[i]) || text[i] == '\'') && sb.Length > 0)
                {
                    wordsList.Add(sb.ToString().ToLower());
                    sb = new StringBuilder();
                }

                if (char.IsLetter(text[i]) || text[i] == '\'') sb.Append(text[i]);
                if (i == text.Length - 1 && sb.Length > 0) wordsList.Add(sb.ToString().ToLower());
            }
            if (wordsList.Count > 0) return wordsList;
            else return null;
        }
    }
}          
