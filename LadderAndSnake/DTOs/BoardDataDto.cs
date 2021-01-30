using LadderAndSnake.BoardData;
using System.Collections.Generic;

namespace LadderAndSnake
{
    public class BoardDataDto
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public IEnumerable<ShortCut> Ladders { get; set; }
        public IEnumerable<ShortCut> Snakes { get; set; }
    }
}
