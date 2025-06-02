using System;

namespace Ex02
{
    public class Program
    {
        public static void Main()
        {
            char[] validCharacters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            int sequenceLength = 4;

            try
            {
                GameController gameController = new GameController(validCharacters, sequenceLength);
                gameController.RunGame();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while running the game:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}