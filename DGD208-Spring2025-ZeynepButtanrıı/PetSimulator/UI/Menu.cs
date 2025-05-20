using System;
using System.Collections.Generic;

namespace PetSimulator.UI
{
    public class Menu
    {
        private readonly List<string> options;

        public Menu(IEnumerable<string> options)
        {
            this.options = new List<string>(options);
        }

        public int DisplayAndGetChoice()
        {
            Console.Clear();
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            while (true)
            {
                Console.Write("\nEnter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= options.Count)
                {
                    return choice;
                }
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
} 