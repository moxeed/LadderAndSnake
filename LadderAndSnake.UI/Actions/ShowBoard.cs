using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LadderAndSnake.UI.Actions
{
    class ShowBoard : IUIAction
    {
        public Game DidRender(Game game) => game;

        public IUIAction NextAction() => new RollDice();

        public void Render(Game game)
        {
            var board = game.GetBoardData();

            for (int j=1; j <= board.Height * board.Width; j++) 
            {
                if (board.Snakes.Any(s => s.Start == j))
                    Console.Write($"|S{j:000}");

                else if (board.Ladders.Any(s => s.Start == j))
                    Console.Write($"|L{j:000}");
                else
                    Console.Write($"| {j:000}");

                if (j % board.Width == 0) 
                {
                    Console.Write("|\n");
                    Console.WriteLine(string.Concat(Enumerable.Repeat("-", board.Width * 5))+"-");
                }
            }
        }
    }
}
