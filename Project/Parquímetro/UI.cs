using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parquímetro
{
    public struct UI
    {
        public static double PrintMenu(Menu menu, double credits, DateTime exitTime)
        {
            List<int> validNumbers = getValidNumbers(menu.options.Length);

            // Clear console info for next execution
            Console.Clear();
            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine(" ");
            Console.WriteLine(" " + Time.GetDate(DateTime.Now) + "                                                                             " + Time.GetHours(DateTime.Now));
            Console.WriteLine(" ");
            Console.WriteLine(" " + menu.title);
            Console.WriteLine(" ");
            Console.WriteLine(" ");

            for (int i = 0; i < menu.options.Length; i++)
            {
                Console.WriteLine(" " + (i + 1) + ". " + menu.options[i]);
            }

            if (menu.AddFinalizePayment())
            {
                validNumbers.Add(9);
                Console.WriteLine(" 9. Finalizar pagamento");
            }

            if (menu.AddBackToPreviousMenu())
            {
                validNumbers.Add(10);
                string timeTillExit = $" 10. Voltar ao menu anterior";
                if (menu.id == "area")
                {
                    timeTillExit += $"               Hora de saída: {Time.GetDate(exitTime)} {Time.GetHours(exitTime)}";
                }

                Console.WriteLine(timeTillExit);
            }

            if (menu.AddBackToMainMenu())
            {
                validNumbers.Add(11);
                string lastLine = $" 11. Voltar ao menu principal";
                if (menu.id == "area")
                {
                    lastLine += $"                   créditos: {credits}";
                }
                Console.WriteLine(lastLine);
            }

            Console.WriteLine("_____________________________________________________________________________________________");

            Console.Write("Escolha uma opção -> ");

            // Run until valid option is selected
            while (true)
            {
                // Check if input is int
                bool isInputInt = int.TryParse(Console.ReadLine(), out int userInput);

                if (isInputInt && validNumbers.Contains(userInput))
                {
                    if ((menu.id == "area") && userInput <= 8)
                    {
                        return double.Parse(menu.options[userInput - 1]);
                    }
                    return userInput;
                }

                Console.Write("Erro: Escolha um opção válida -> ");
            }
        }

        private static List<int> getValidNumbers(int optionsLength)
        {
            List<int> validNumbers = Enumerable.Range(1, optionsLength).ToList();
            return validNumbers;
        }
    }
}
