using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LadderAndSnake
{
    class ShortCutPolicy
    {
        public bool IsValid(ShortCut shortCut, IEnumerable<ShortCut> shortCuts) 
            => !shortCuts.Any(sc => sc.Start == shortCut.Start ||
                sc.Start == shortCut.End && sc.End == shortCut.Start);
    }
}
