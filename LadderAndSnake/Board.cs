using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LadderAndSnake
{
    class Board
    {
        public int Heigth { get; }
        public int Width { get; }
        public int ExitPint => Heigth * Width;

        int _ladderCount;
        int _snakeCount;
        ShortCutPolicy _shortCutPolicy;
        List<ShortCut> _shortCuts;// this data structure is not performant in term of time and space complexity
        public Board(int heigth, int width, int ladderCount, int snakeCount)
        {
            Heigth = heigth;
            Width = width;
            _ladderCount = ladderCount;
            _snakeCount = snakeCount;
            if (Heigth * width < (_ladderCount + _snakeCount) / 2)
            {
                throw new ArgumentOutOfRangeException("The size of the board and number of the ladders and snakes are not compatible.");
            }
            _shortCuts = new List<ShortCut>();
            _shortCutPolicy = new ShortCutPolicy();
            Initial();
        }

        private void Initial()
        {
            AddSnake();
            AddLadder();
        }

        private void AddLadder()
        {
            var randomGenerator = new Random();
            for (int i = 0; i < _snakeCount; i++) 
            {
                var start = randomGenerator.Next(2, ExitPint - 1);
                var end = randomGenerator.Next(start, ExitPint - 1);
                var ladder = new ShortCut(start, end);

                while (!_shortCutPolicy.IsValid(ladder, _shortCuts))
                    ladder = new ShortCut(ladder.Start - 1, ladder.End);
            }
        }

        private void AddSnake()
        {
            var randomGenerator = new Random();
            for (int i = 0; i < _snakeCount; i++)
            {
                var start = randomGenerator.Next(2, ExitPint - 1);
                var end = randomGenerator.Next(1, start);
                var snake = new ShortCut(start, end);

                while (!_shortCutPolicy.IsValid(snake, _shortCuts))
                    snake = new ShortCut(snake.Start + 1, snake.End);
            }
        }

        internal int CalculateNextPostion(int position, int diceValue)
        {
            var excpectedPosition = position + diceValue;

            if ( excpectedPosition >= ExitPint)
                return ExitPint;
            if(_shortCuts.Any(c => c.Start == excpectedPosition))
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
