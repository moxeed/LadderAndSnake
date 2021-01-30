using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LadderAndSnake.BoardData
{
    interface IShortCutPolicy
    {
        bool IsValid(ShortCut shortCut, IEnumerable<ShortCut> shortCuts);
    }
}
