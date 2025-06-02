using System;
using System.Collections.Generic;

namespace Ex02
{
    public class RandomSequence
    {
        private readonly string r_Sequence;
        private static readonly Random sr_Random = new Random();

        public RandomSequence(int i_Length, char[] i_AvailableChars)
        {
            r_Sequence = generateSequence(i_Length, i_AvailableChars);
        }

        public string Value
        {
            get
            {
                return r_Sequence;
            }
        }

        public int Length
        {
            get
            {
                return r_Sequence.Length;
            }
        }

        public char GetCharAt(int i_Index)
        {
            return r_Sequence[i_Index];
        }

        private string generateSequence(int i_Length, char[] i_AvailableChars)
        {
            List<char> availableChars = new List<char>(i_AvailableChars);
            string sequence = "";

            for (int i = 0; i < i_Length; i++)
            {
                int randomIndex = sr_Random.Next(availableChars.Count);
                char selectedChar = availableChars[randomIndex];
                sequence += selectedChar;
                availableChars.RemoveAt(randomIndex);
            }

            return sequence;
        }
    }
}