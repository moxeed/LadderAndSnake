using LadderAndSnake.BoardData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asa.LadderAndSnake.Test
{
    public class BoardTest
    {
        [Test]
        public void Board_Should_Not_Allow_Invalid_Ladder_And_Snake_Count() 
        {
            var width = 2;
            var height = 5;
            var ladderCount = 20;
            var snakeCount = 20;

            Assert.Catch(typeof(ArgumentOutOfRangeException), () => new Board(width, height, ladderCount, snakeCount));
        }
        
        [Test]
        public void Board_Should_Be_Created_Succesfuly() 
        {
            var width = 10;
            var height = 5;
            var ladderCount = 2;
            var snakeCount = 5;

            Assert.DoesNotThrow(() => new Board(width, height, ladderCount, snakeCount));
        }
        
        [Test]
        public void Board_Feilds_Will_BeFilled_Succesfuly() 
        {
            var width = 10;
            var height = 5;
            var ladderCount = 2;
            var snakeCount = 5;

            Board board = null;

            Assert.DoesNotThrow(() => board = new Board(height, width, ladderCount, snakeCount));
            Assert.IsNotNull(board);
            Assert.AreEqual(board.Width, width);
            Assert.AreEqual(board.Heigth, height);
        }
        
        [Test]
        public void Board_GetData_Returns_Correct_Data() 
        {
            var width = 10;
            var height = 5;
            var ladderCount = 2;
            var snakeCount = 5;

            Board board = new Board(height, width, ladderCount, snakeCount);
            var boardData = board.GetData();

            Assert.AreEqual(boardData.Width, width);
            Assert.AreEqual(boardData.Height, height);
            Assert.AreEqual(boardData.Snakes.Count(), snakeCount);
            Assert.AreEqual(boardData.Ladders.Count(), ladderCount);
        }
        
        [Test]
        public void Board_Currecly_Calculates_Next_Position_When_No_ShortCutExists() 
        {
            var width = 10;
            var height = 5;
            var ladderCount = 0;
            var snakeCount = 0;
            var position = 10;
            var diceValue = 4;

            Board board = new Board(height, width, ladderCount, snakeCount);
            var nextPosition = board.CalculateNextPostion(position, diceValue);

            Assert.AreEqual(nextPosition, position + diceValue);
        }
        
        [Test]
        public void Board_Currecly_Calculates_Next_Position_When_Facing_Snake() 
        {
            var width = 10;
            var height = 5;
            var ladderCount = 0;
            var snakeCount = 1;
            var diceValue = 4;

            Board board = new Board(height, width, ladderCount, snakeCount);
            var snake = board.GetData().Snakes.First();
            var nextPosition = board.CalculateNextPostion(snake.Start - diceValue, diceValue);

            Assert.AreEqual(nextPosition, snake.End);
        }


        [Test]
        public void Board_Currecly_Calculates_Next_Position_When_Facing_Ladder() 
        {
            var width = 10;
            var height = 5;
            var ladderCount = 1;
            var snakeCount = 0;
            var diceValue = 4;

            Board board = new Board(height, width, ladderCount, snakeCount);
            var ladder = board.GetData().Ladders.First();
            var nextPosition = board.CalculateNextPostion(ladder.Start - diceValue, diceValue);

            Assert.AreEqual(nextPosition, ladder.End);
        }
    }
}
