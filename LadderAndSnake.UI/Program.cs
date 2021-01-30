using LadderAndSnake.UI.Actions;
using System;

namespace LadderAndSnake.UI
{
    class Program
    {
        static IUIAction action;
        static void Main()
        {
            Game game = null;
            action = new SetBoard();

            while (action != null) 
                try
                {
                    action.Render(game);
                    game = action.DidRender(game);
                    action = action.NextAction();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
        }
    }
}
