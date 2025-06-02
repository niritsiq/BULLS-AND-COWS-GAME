using System;

namespace Ex02
{
    public class BoardRenderer
    {
        public void PrintHeaders()
        {
            Console.WriteLine("¦ Pins:   ¦Result:¦");
            printSeparator();
        }

        public void PrintPlaceholderRow(GameBoard i_GameBoard)
        {
            string placeholderContent = i_GameBoard.GetPlaceholderContent();
            string emptyResult = padResult("");

            printRow(placeholderContent, emptyResult);
        }

        public void PrintGuessRow(string i_GuessContent, string i_ResultContent)
        {
            printRow(i_GuessContent, i_ResultContent);
        }

        private void printRow(string i_LeftContent, string i_RightContent)
        {
            Console.WriteLine($"¦ {i_LeftContent} ¦{i_RightContent}¦");
            printSeparator();
        }

        private void printSeparator()
        {
            Console.WriteLine("¦=========¦=======¦");
        }

        private string padResult(string i_Result)
        {
            string result = i_Result ?? "";

            while (result.Length < 7)
            {
                result += " ";
            }
            
            return result;
        }

        public void PrintBoard(GameBoard i_GameBoard)
        {
            Console.Clear();
            PrintHeaders();

            if (i_GameBoard.CurrentRow < i_GameBoard.MaxGuesses)
            {
                string placeholderContent = i_GameBoard.GetPlaceholderContent();
                string emptyResult = padResult("");
                Console.WriteLine($"¦ {placeholderContent} ¦{emptyResult}¦");
            }
            else
            {
                string secretContent = i_GameBoard.GetSecretSequence();
                string emptyResult = padResult("");
                Console.WriteLine($"¦ {secretContent} ¦{emptyResult}¦");
            }
            printSeparator();
 
            for (int i = 1; i <= i_GameBoard.MaxGuesses; i++)
            {
                int guessIndex = i - 1; // Adjust for guesses array (0-based)
                string guessContent = i_GameBoard.GetGuessAt(guessIndex);
                string resultContent = i_GameBoard.GetResultAt(guessIndex);
                if (guessContent != null && resultContent != null)
                {
                    printRow(guessContent, resultContent);
                }
                else
                {
                    string emptyContent = i_GameBoard.GetEmptyContent();
                    string emptyResult = padResult("");
                    printRow(emptyContent, emptyResult);
                }
            }
        }
    }
}