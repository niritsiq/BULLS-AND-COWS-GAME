using System;

namespace Ex02
{
    public class GameController
    {
        private readonly char[] r_ValidCharacters;
        private readonly int r_SequenceLength;
        private int m_MaxAttempts;
        private GameBoard m_GameBoard;
        private BoardRenderer m_BoardRenderer;
        private RandomSequence m_Secret;

        public GameController(char[] i_ValidCharacters, int i_SequenceLength)
        {
            r_ValidCharacters = i_ValidCharacters;
            r_SequenceLength = i_SequenceLength;
            m_BoardRenderer = new BoardRenderer();
        }

        public void RunGame()
        {
            m_MaxAttempts = getMaxAttemptsFromUser();
            initializeGame();
            showWelcomeMessage();
            
            bool gameWon = false;
            
            m_BoardRenderer.PrintBoard(m_GameBoard);
            
            while (m_GameBoard.CurrentRow < m_GameBoard.MaxGuesses && !gameWon)
            {
                string playerInput = getPlayerInput();
                
                if (isQuitCommand(playerInput))
                {
                    break;
                }
                
                string validationError = GameLogic.ValidateGuess(playerInput, r_ValidCharacters, r_SequenceLength);
                
                if (validationError == null)
                {
                    gameWon = processGuess(playerInput);
                    m_BoardRenderer.PrintBoard(m_GameBoard);
                }
                else
                {
                    Console.WriteLine(validationError);
                }
            }
            
            if (gameWon)
            {
                handleGameWin();
            }
            else if (m_GameBoard.CurrentRow >= m_GameBoard.MaxGuesses)
            {
                handleGameLoss();
            }
            
            handleGameEnd();
        }

        private void initializeGame()
        {
            m_Secret = new RandomSequence(r_SequenceLength, r_ValidCharacters);
            m_GameBoard = new GameBoard(r_ValidCharacters, m_MaxAttempts, m_Secret.Value);
        }

        private int getMaxAttemptsFromUser()
        {
            int maxAttempts = 0;

            Console.WriteLine("Welcome to Bulls and Cows!");
            Console.WriteLine("How many attempts would you like? (4-10):");

            while (maxAttempts == 0)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int attempts) && attempts >= 4 && attempts <= 10)
                {
                    maxAttempts = attempts;
                }
                else
                {
                    Console.WriteLine("Please enter a number between 4 and 10:");
                }
            }

            return maxAttempts;
        }

        private string getPlayerInput()
        {
            Console.Write("Please type your next guess <");
            
            foreach (char validChar in r_ValidCharacters)
            {
                Console.Write($"{validChar} ");
            }
            
            Console.WriteLine("> or 'Q' to quit:");
            
            string input = Console.ReadLine();
            return input?.ToUpper();
        }

        private bool isQuitCommand(string i_Input)
        {
            return i_Input != null && i_Input.Length == 1 && i_Input == "Q";
        }

        private bool processGuess(string i_PlayerInput)
        {
            PlayerGuess guess = new PlayerGuess(i_PlayerInput);
            
            int bulls = GameLogic.CalculateBulls(m_Secret, guess);
            int cows = GameLogic.CalculateCows(m_Secret, guess, bulls);
            bool isWin = GameLogic.IsWin(m_Secret, guess);

            m_GameBoard.AddGuess(i_PlayerInput, bulls, cows);

            return isWin;
        }

        private void showWelcomeMessage()
        {
            Console.WriteLine("Welcome to Bulls and Cows!");
            Console.Write("Available characters: ");

            foreach (char validChar in r_ValidCharacters)
            {
                Console.Write($"{validChar} ");
            }
            
            Console.WriteLine();
            Console.WriteLine($"Guess the {r_SequenceLength}-character sequence!");
            Console.WriteLine($"You have {m_MaxAttempts} attempts.");
            Console.WriteLine();
        }

        private void handleGameWin()
        {
            Console.WriteLine($"Congratulations! You won in {m_GameBoard.CurrentRow} attempts!");
            Console.WriteLine($"The secret sequence was: {m_Secret.Value}");
        }

        private void handleGameLoss()
        {
            Console.WriteLine("Game Over! You've used all your attempts.");
            Console.WriteLine($"The secret sequence was: {m_Secret.Value}");
        }

        private void handleGameEnd()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to play again? (y/n)");

            string input = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(input) && input.ToUpper() == "Y")
            {
                RunGame();
            }
            else
            {
                Console.WriteLine("Thanks for playing!");
            }
        }
    }
}