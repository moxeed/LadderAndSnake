using System;
using System.Collections.Generic;
using System.Text;

namespace LadderAndSnake.UI.Actions
{
    class RollDice : IUIAction
    {
        bool isWinner;

        public Game DidRender(Game game)
        {
            Console.ReadKey();
            var moveResult = game.Play();
            Console.WriteLine($"Color        : {moveResult.Color}");
            Console.WriteLine($"PalyerName   : {moveResult.Name}");
            Console.WriteLine($"new Position : {moveResult.NewPosition}");
            Console.WriteLine($"old Position : {moveResult.OldPosition}");

            isWinner = moveResult.IsWinner;
            if (isWinner)
                Console.WriteLine($"{moveResult.Color} Wins!!!");

            return game;
        }

        public IUIAction NextAction()
        {
            if (isWinner)
                return new Menu();
            return new RollDice();
        }

        public void Render(Game game)
        {
            Console.WriteLine("Press Any Key To Roll Dice..");
        }
    }
}
