namespace Ex02
{
    public class GameBoard
    {
        private readonly char[] r_AvailableChars;
        private readonly int r_MaxGuesses;
        private readonly string r_SecretSequence;
        private readonly string[,] r_BoardMatrix;
        private int m_CurrentRow;

        public GameBoard(char[] i_AvailableChars, int i_MaxGuesses, string i_SecretSequence)
        {
            r_AvailableChars = i_AvailableChars;
            r_MaxGuesses = i_MaxGuesses;
            r_SecretSequence = i_SecretSequence;
            r_BoardMatrix = new string[i_MaxGuesses, 2];
            m_CurrentRow = 0;
            initializeMatrix();
        }

        public int MaxGuesses
        {
            get
            {
                return r_MaxGuesses;
            }
        }

        public int CurrentRow
        {
            get
            {
                return m_CurrentRow;
            }
        }

        public int SecretLength
        {
            get
            {
                return r_SecretSequence.Length;
            }
        }

        public void AddGuess(string i_Guess, int i_Bulls, int i_Cows)
        {
            if (m_CurrentRow < r_MaxGuesses)
            {
                string resultString = createResultString(i_Bulls, i_Cows);
                r_BoardMatrix[m_CurrentRow, 0] = formatGuess(i_Guess);
                r_BoardMatrix[m_CurrentRow, 1] = resultString;
                m_CurrentRow++;
            }
        }

        public string GetGuessAt(int i_Row)
        {
            string guess = null;
            
            if (i_Row >= 0 && i_Row < r_MaxGuesses && r_BoardMatrix[i_Row, 0] != null)
            {
                guess = r_BoardMatrix[i_Row, 0];
            }
            
            return guess;
        }

        public string GetResultAt(int i_Row)
        {
            string result = null;
            
            if (i_Row >= 0 && i_Row < r_MaxGuesses && r_BoardMatrix[i_Row, 1] != null)
            {
                result = r_BoardMatrix[i_Row, 1];
            }
            
            return result;
        }

        public string GetPlaceholderContent()
        {
            string placeholder = "";
            int charIndex = 0;
            
            foreach (char secretChar in r_SecretSequence)
            {
                placeholder += "#";
                if (charIndex < r_SecretSequence.Length - 1)
                {
                    placeholder += " ";
                }
                charIndex++;
            }
            return placeholder;
        }

        public string GetEmptyContent()
        {
            string empty = "";
            int charIndex = 0;
            
            foreach (char secretChar in r_SecretSequence)
            {
                empty += " ";
                if (charIndex < r_SecretSequence.Length - 1)
                {
                    empty += " ";
                }
                charIndex++;
            }
            return empty;
        }

        public string GetSecretSequence()
        {
            return formatGuess(r_SecretSequence);
        }

        private void initializeMatrix()
        {
            for (int i = 0; i < r_MaxGuesses; i++)
            {
                r_BoardMatrix[i, 0] = null;
                r_BoardMatrix[i, 1] = null;
            }
        }

        private string formatGuess(string i_Guess)
        {
            string formatted = "";
            int charIndex = 0;
            
            foreach (char guessChar in i_Guess)
            {
                formatted += guessChar;
                if (charIndex < i_Guess.Length - 1)
                {
                    formatted += " ";
                }
                charIndex++;
            }
            
            return formatted;
        }

        private string createResultString(int i_Bulls, int i_Cows)
        {
            string result = "";
            
            for (int i = 0; i < i_Bulls; i++)
            {
                if (result.Length > 0)
                {
                    result += " ";
                }
                result += "V";
            }
            
            for (int i = 0; i < i_Cows; i++)
            {
                if (result.Length > 0)
                {
                    result += " ";
                }
                result += "X";
            }
            
            while (result.Length < 7)
            {
                result += " ";
            }
            
            return result;
        }
    }
}