# Bulls and Cows Game - Console Version

This is a console-based **Bulls and Cows** game implemented in **C#** as part of an Object-Oriented Programming assignment. The game focuses on demonstrating object-oriented principles, collections handling, input validation, and console-based interaction.

## 📜 Description
The game randomly selects a sequence of 4 unique uppercase letters (A-H) without repetitions. The player has a limited number of attempts (4-10) to guess the sequence. After each guess, the game provides feedback:
- **V**: Correct letter in the correct position ("Bull").
- **X**: Correct letter but in the wrong position ("Cow").

The game displays the board with the history of guesses and feedback, allowing the player to refine their next guess. The game continues until the player guesses the sequence or exhausts all attempts.

## 🚀 Features
- Random sequence generation using `Random.Next`.
- Input validation for correct length, allowed characters (A-H), and uniqueness.
- Clear board display using `Ex02.ConsoleUtils.Screen.Clear()` from an external DLL.
- Separation of concerns:
  - Logic and data management classes.
  - User interaction and board display classes.
- Option to play again or quit (`Q` to quit at any time).
- Feedback provided after each guess:
  - First **V**s (bulls), then **X**s (cows).

## 📏 Rules
- Allowed characters: **A-H** (uppercase, no spaces or repetitions).
- Sequence length: **4**.
- Number of guesses: **4 to 10**.
- Feedback is always aligned with **V**s (bulls) first, then **X**s (cows).

## 🖥️ Running the Game
1. Build the project in Visual Studio.
2. Reference the provided `Ex02.ConsoleUtils.dll`.
3. Run the application in the console.
4. Follow prompts to input guesses.
5. Quit at any time by entering `Q`.

## 🔒 Input Validation
- The game checks for valid guess length and characters.
- Handles both syntactic (format) and semantic (content) errors.

## 📚 Key Concepts
- Object-Oriented Programming: Classes, properties, access modifiers, and string handling.
- Collections and arrays.
- External library usage (`DLL`).
- Separation between logic and UI for future extensibility.

## 🏆 Objective
Implement a **Bulls and Cows** console game demonstrating good design, proper input handling, and clean code structure.

### 👥 Authors
- **Nir Itzik**
- **Tamir Sida**
