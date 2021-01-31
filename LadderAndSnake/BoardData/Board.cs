using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Asa.LadderAndSnake.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace LadderAndSnake.BoardData
{
    class Board
    {
        public int Heigth { get; }
        public int Width { get; }
        public int ExitPoint => Heigth * Width;

        readonly int _ladderCount;
        readonly int _snakeCount;
        readonly List<ShortCut> _shortCuts;// this data structure is not performant in term of time and space complexity

        public Board(){}

        public Board(int heigth, int width, int ladderCount, int snakeCount)
        {
            Heigth = heigth;
            Width = width;
            _ladderCount = ladderCount;
            _snakeCount = snakeCount;
            if (ExitPoint < (_ladderCount + _snakeCount) / 2)
            {
                throw new ArgumentOutOfRangeException("The size of the board and number of the ladders and snakes are not compatible.");
            }
            _shortCuts = new List<ShortCut>();
            Initial();
        }

        private void Initial()
        {
            AddSnake();
            AddLadder();
        }

        private void AddLadder() => AddShortCuts(new LadderPolicy(), _ladderCount);

        private void AddSnake() => AddShortCuts(new SnakePolicy(), _snakeCount);

        void AddShortCuts(IShortCutPolicy policy, int count)
        {
            var points = Enumerable.Range(1, ExitPoint).
                OrderBy(c => Guid.NewGuid()).ToList();

            for (int i = 0; i < points.Count && count > 0; i++)
                for (int j = i; j < points.Count; j++)
                {
                    ShortCut shortCut = new ShortCut(points[i], points[j]);
                    if (policy.IsValid(shortCut, _shortCuts))
                    {
                        _shortCuts.Add(shortCut);
                        points.RemoveAt(i);
                        points.RemoveAt(j);
                        count--;
                        break;
                    }
                }
        }

        internal virtual int CalculateNextPostion(int position, int diceValue)
        {
            var excpectedPosition = position + diceValue;

            if (excpectedPosition >= ExitPoint)
                return ExitPoint;
            if (_shortCuts.Any(c => c.Start == excpectedPosition))
                return _shortCuts.First(c => c.Start == excpectedPosition).End;
            return excpectedPosition;
        }

        internal BoardDataDto GetData()
        {
            return new BoardDataDto
            {
                Height = Heigth,
                Width = Width,
                Ladders = _shortCuts.Where(cs => cs.Start < cs.End),
                Snakes = _shortCuts.Where(cs => cs.Start > cs.End),
            };
        }
    }
}
