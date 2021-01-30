using System;
using System.Collections.Generic;
using System.Text;

namespace LadderAndSnake.UI.Actions
{
    class Quit : IUIAction
    {
        public Game DidRender(Game game) => game;

        public IUIAction NextAction() => null;

        public void Render(Game game) => Console.WriteLine("->Good Bye");
    }
}
