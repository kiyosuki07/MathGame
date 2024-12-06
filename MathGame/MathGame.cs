namespace MathGame
{
    public class MathGame
    {
        private List<string> gameHistory = new List<string>();
        public void Start()
        {
            Console.WriteLine("--- MathGame ---");
            while (true)
            {
                Console.WriteLine("Choice an option:");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Show game history");
                Console.WriteLine("6. Exit");

                string choice = Console.ReadLine();

                if (choice == "6")
                {
                    Console.WriteLine("Thanks for playing!");
                    break;
                }

                if (choice == "5")
                {
                    ShowHistory();
                    continue;
                }

                GenerateQuestion(choice);
            }
        }

        private void GenerateQuestion(string choice)
        {
            Random random = new Random();
            int num1 = random.Next(1, 100);
            int num2 = random.Next(1, 100);

            int correctAnswer = 0;
            string operation = "";

            switch (choice)
            {
                case "1":
                    operation = "+";
                    correctAnswer = num1 + num2;
                    break;
                case "2":
                    operation = "-";
                    correctAnswer = num1 - num2;
                    break;
                case "3":
                    operation = "*";
                    correctAnswer = num1 * num2;
                    break;
                case "4":
                    operation = "/";
                    if (num2 == 0) num2 = 1;
                    correctAnswer = num1 / num2;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return;
            }

            Console.WriteLine($"Solve: {num1} {operation} {num2}");
            string answer = Console.ReadLine();

            if (int.TryParse(answer, out int userAnswer) && userAnswer == correctAnswer)
            {
                Console.WriteLine("Good!");
                gameHistory.Add($"Correct: {num1} {operation} {num2} = {correctAnswer}");
            }
            else
            {
                Console.WriteLine($"Incorrect. The right answer: {correctAnswer}");
                gameHistory.Add($"Incorrect: {num1} {operation} {num2}. Your answer: {answer}, Correct: {correctAnswer}");
            }
        }

        private void ShowHistory()
        {
            Console.WriteLine("--- Game History ---");
            if (gameHistory.Count == 0)
            {
                Console.WriteLine("History is empty.");
            }
            else
            {
                foreach (var record in gameHistory)
                {
                    Console.WriteLine(record);
                }
            }
        }
    }
}