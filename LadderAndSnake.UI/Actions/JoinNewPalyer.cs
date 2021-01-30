using System;
using System.Collections.Generic;
using System.Text;

namespace LadderAndSnake.UI.Actions
{
    class JoinNewPalyer : IUIAction
    {
        public Game DidRender(Game game)
        {
            var playerName = Console.ReadLine();
            var playerColor = Console.ReadLine();

            game.Join(playerName, ParseColor(playerColor));
            return game;
        }

        public IUIAction NextAction() => new Menu();

        public void Render(Game game)
        {
            Console.Write("->Enter New Player Name and Color in Two Lines \n color list:");
            foreach (var name in Enum.GetNames(typeof(ColorEnum)))
                Console.Write(" " + name);
            Console.WriteLine();
        }

        ColorEnum ParseColor(string input) 
        {
            return input.ToLower() switch
            {
                "red" => ColorEnum.Red,
                "blue" => ColorEnum.Blue,
                "yellow" => ColorEnum.Yellow,
                "green" => ColorEnum.Green,
                _ => throw new InvalidCastException($"{input} is not a valid color name")
            };
        }
    }
}
