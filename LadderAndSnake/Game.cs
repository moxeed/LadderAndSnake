using System;
using System.Linq;
using System.Collections.Generic;
using LadderAndSnake.BoardData;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Asa.LadderAndSnake.Test")]
namespace LadderAndSnake
{
    public class Game
    {

        readonly List<Player> _players;
        Board _board;

        public Game(int heigth, int width, int ladderCount, int snakeCount) : this()
        {
            _board = new Board(heigth, width, ladderCount, snakeCount);
        }

        public void Join(string name, ColorEnum color)
        {
            Player newPlayer = new Player(name, color);
            if (_players.Any(x => x == newPlayer))
            {
                throw new InvalidOperationException("Duplicated player name is not allowed.");
            }
            const int Max_Allowd_Players = 4;
            if (_players.Count >= Max_Allowd_Players)
            {
                throw new InvalidOperationException("Only 4 players can join a game.");
            }
            _players.Add(new Player(name, color));
        }
        public Game()
        {
            _players = new List<Player>();
        }

        bool gameIsFinished;
        public MoveResult Play()
        {
            if (gameIsFinished)
            {
                throw new InvalidOperationException("Game is finished, no more movement is allowed.");
            }
            var currentPlayer = GetCurrentPlayer();
            MoveResult moveresult = currentPlayer.MoveOn(_board);
            moveresult.IsWinner = moveresult.NewPosition == _board.ExitPoint;
            gameIsFinished = moveresult.IsWinner;
            return moveresult;
        }

        int currentPlayer;
        private Player GetCurrentPlayer()
        {
            var player = _players[currentPlayer];
            currentPlayer ++;
            currentPlayer %= _players.Count;

            return player;
        }
        public BoardDataDto GetBoardData() => _board.GetData();
    }
}
