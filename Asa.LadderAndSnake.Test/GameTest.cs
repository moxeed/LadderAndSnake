using LadderAndSnake;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.LadderAndSnake.Test
{
    public class GameTest
    {
        [Test]
        public void Game_Prevents_Duplicate_Players() 
        {
            int height = 6;
            int width = 4;
            int ladderCount = 2;
            int snakeCount = 3;

            var game = new Game(height, width, ladderCount, snakeCount);
            var player1 = new Player("player1", ColorEnum.Yellow);
            var player2 = new Player("player1", ColorEnum.Red);

            game.Join(player1.Name, player1.Color);

            Assert.Catch(typeof(InvalidOperationException), () => game.Join(player2.Name, player2.Color));
        }

        [Test]
        public void Game_Overflows_After_Max_Players_Players() 
        {
            int height = 6;
            int width = 4;
            int ladderCount = 2;
            int snakeCount = 3;

            var game = new Game(height, width, ladderCount, snakeCount);
            var player1 = new Player("player1", ColorEnum.Yellow);
            var player2 = new Player("player2", ColorEnum.Red);
            var player3 = new Player("player3", ColorEnum.Blue);
            var player4 = new Player("player4", ColorEnum.Green);
            var player5 = new Player("player5", ColorEnum.Purple);

            game.Join(player1.Name, player1.Color);
            game.Join(player2.Name, player2.Color);
            game.Join(player3.Name, player3.Color);
            game.Join(player4.Name, player4.Color);

            Assert.Catch(typeof(InvalidOperationException), () => game.Join(player5.Name, player5.Color));
        }
    }
}
