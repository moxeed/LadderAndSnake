using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace LadderAndSnake.BoardData
{
    class LadderPolicy : IShortCutPolicy
    {
        public bool IsValid(ShortCut shortCut, IEnumerable<ShortCut> shortCuts)
        {
            return !shortCuts.Any(sc => sc.Start == shortCut.Start ||
                sc.Start == shortCut.End && sc.End == shortCut.Start)
                && shortCut.Start < shortCut.End;
        }
    }
}
