namespace Ex02
{
    public class GameLogic
    {
        public static string ValidateGuess(string i_Input, char[] i_ValidChars, int i_RequiredLength)
        {
            if (string.IsNullOrEmpty(i_Input))
            {
                return $"Please enter exactly {i_RequiredLength} characters.";
            }

            if (i_Input.Length != i_RequiredLength)
            {
                return $"Please enter exactly {i_RequiredLength} characters.";
            }

            // Check for numbers
            foreach (char c in i_Input)
            {
                if (char.IsDigit(c))
                {
                    return "Numbers are not allowed. Please use only letters.";
                }
            }

            // Check for invalid characters
            foreach (char inputChar in i_Input)
            {
                bool isValid = false;
                foreach (char validChar in i_ValidChars)
                {
                    if (char.ToUpper(inputChar) == char.ToUpper(validChar))
                    {
                        isValid = true;
                        break;
                    }
                }
                if (!isValid)
                {
                    string validCharsString = "";
                    foreach (char validChar in i_ValidChars)
                    {
                        validCharsString += validChar + " ";
                    }
                    return $"Please use only these characters: {validCharsString.Trim()}";
                }
            }

            // Check for duplicates
            for (int i = 0; i < i_Input.Length; i++)
            {
                for (int j = i + 1; j < i_Input.Length; j++)
                {
                    if (char.ToUpper(i_Input[i]) == char.ToUpper(i_Input[j]))
                    {
                        return "Please don't use the same character twice.";
                    }
                }
            }

            return null; // Valid input
        }

        public static int CalculateBulls(RandomSequence i_Secret, PlayerGuess i_Guess)
        {
            int bulls = 0;
            int minLength = i_Secret.Length < i_Guess.Length ? i_Secret.Length : i_Guess.Length;

            for (int i = 0; i < minLength; i++)
            {
                if (i_Secret.GetCharAt(i) == i_Guess.GetCharAt(i))
                {
                    bulls++;
                }
            }

            return bulls;
        }

        public static int CalculateCows(RandomSequence i_Secret, PlayerGuess i_Guess, int i_Bulls)
        {
            string secretValue = i_Secret.Value;
            string guessValue = i_Guess.Value;
            
            char[] secretArray = secretValue.ToCharArray();
            char[] guessArray = guessValue.ToCharArray();
            
            bool[] secretUsed = new bool[secretArray.Length];
            bool[] guessUsed = new bool[guessArray.Length];
            
            // Mark bulls as used
            for (int i = 0; i < secretArray.Length && i < guessArray.Length; i++)
            {
                if (secretArray[i] == guessArray[i])
                {
                    secretUsed[i] = true;
                    guessUsed[i] = true;
                }
            }
            
            // Count cows
            int cows = 0;
            for (int i = 0; i < guessArray.Length; i++)
            {
                if (!guessUsed[i])
                {
                    for (int j = 0; j < secretArray.Length; j++)
                    {
                        if (!secretUsed[j] && guessArray[i] == secretArray[j])
                        {
                            secretUsed[j] = true;
                            cows++;
                            break;
                        }
                    }
                }
            }
            
            return cows;
        }

        public static bool IsWin(RandomSequence i_Secret, PlayerGuess i_Guess)
        {
            return i_Secret.Value == i_Guess.Value;
        }
    }
}