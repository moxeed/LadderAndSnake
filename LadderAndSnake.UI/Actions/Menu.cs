using LadderAndSnake.UI.Heplers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LadderAndSnake.UI.Actions
{
    class Menu : IUIAction
    {
        IUIAction _nextAction;
        public void Render(Game game)
        {
            Console.WriteLine("->choose action \n 1. Add new Player \n 2. Start Game \n 3. Restart \n 4. quit ");
        }

        IUIAction ResolveNextAction(int command) 
        {
            switch (command)
            {
                case 1:
                    return new JoinNewPalyer();
                case 2:
                    return new ShowBoard();
                case 3:
                    return new SetBoard();
                default:
                    return new Quit();
            }
        }

        public Game DidRender(Game game)
        {
            var inputParser = new InputParser();

            int command = inputParser.ReadNumberInput();
            _nextAction = ResolveNextAction(command);

            return game;
        }

        public IUIAction NextAction() => _nextAction;
    }
}
