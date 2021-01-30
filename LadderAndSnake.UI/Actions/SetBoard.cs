using LadderAndSnake.UI.Heplers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LadderAndSnake.UI.Actions
{
    class SetBoard : IUIAction
    {
        public Game DidRender(Game game)
        {
            var inputParser = new InputParser();

            var height = inputParser.ReadNumberInput();
            var width = inputParser.ReadNumberInput();
            var snakeCount = inputParser.ReadNumberInput();
            var ladderCount = inputParser.ReadNumberInput();

            return new Game(width, height, ladderCount, snakeCount);
        }

        public IUIAction NextAction() => new Menu();

        public void Render(Game game)
        {
            Console.WriteLine("Give Your Board Height, Width, Snake Count, Ladder Count");
        }
    }
}
