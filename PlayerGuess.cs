namespace Ex02
{
    public class PlayerGuess
    {
        private readonly string r_GuessString;

        public PlayerGuess(string i_Guess)
        {
            r_GuessString = i_Guess?.ToUpper() ?? "";
        }

        public string Value
        {
            get
            {
                return r_GuessString;
            }
        }

        public int Length
        {
            get
            {
                return r_GuessString.Length;
            }
        }

        public char GetCharAt(int i_Index)
        {
            return r_GuessString[i_Index];
        }
    }
}