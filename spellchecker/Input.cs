﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringExtended;

namespace spellchecker
{
    public class Input
    {
        private List<string> inputWords;
        private int wordCurrent = -1;

        public bool ReachedEnd
        {
            get
            {
                if (wordCurrent < inputWords.Count)
                    return false;
                else
                    return true;
            }
        }

        public string CurrentWord
        {
            get
            {
                return inputWords[wordCurrent];
            }
        }

        public void GetWords(string inputString)
        {
            char[] delim = { ' ', '\r', '\n' };
            inputWords = inputString.Split(delim, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public void FindNextMisspell(Dict someDictionary)
        {
            do wordCurrent++; while ((wordCurrent < inputWords.Count) && ((someDictionary.Contains(inputWords[wordCurrent].NormalizeWord())) || (CurrentWord.NormalizeWord().Length == 0)));
        }

        public List<string> GetSuggestions(Dict someDictionary)
        {
            Edit edits = new Edit();
            List<string> keys = edits.GetEdits(inputWords[wordCurrent].NormalizeWord());
            List<string> suggestions = new List<string>();
            foreach (string key in keys)
                suggestions.AddRange(someDictionary.GetMatches(key));
            return suggestions;
        }

        public void ReplaceWord(string correctWord)
        {
            inputWords[wordCurrent] = correctWord;
        }

        public string GetString()
        {
            string outputString = "";
            foreach (string word in inputWords)
                outputString += word + " ";
            outputString.Remove(outputString.Length-1, 1);
            return outputString;
        }
    }
}
