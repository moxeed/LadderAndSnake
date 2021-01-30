using System;
using System.Collections.Generic;
using System.Text;

namespace LadderAndSnake.UI.Heplers
{
    class InputParser
    {
        public int ReadNumberInput() 
        {
            string input = Console.ReadLine();
            int numberInput;

            while (!int.TryParse(input, out numberInput))
            {
                Console.WriteLine($"{input} is not Valid, enter a number");
                input = Console.ReadLine();
            }
            return numberInput;
        }
    }
}
