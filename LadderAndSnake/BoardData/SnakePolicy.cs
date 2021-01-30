using System.Collections.Generic;
using System.Linq;

namespace LadderAndSnake.BoardData
{
    class SnakePolicy : IShortCutPolicy
    {
        public bool IsValid(ShortCut shortCut, IEnumerable<ShortCut> shortCuts)
        {
            return !shortCuts.Any(sc => sc.Start == shortCut.Start ||
                sc.Start == shortCut.End && sc.End == shortCut.Start)
                && shortCut.Start > shortCut.End;
        }
    }
}
