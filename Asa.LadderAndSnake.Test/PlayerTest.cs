using LadderAndSnake;
using LadderAndSnake.BoardData;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace Asa.LadderAndSnake.Test
{
    public class PlayerTest
    {
        [Test]
        public void Player_Cannot_Have_Null_Name() 
        {
            string name = null;

            Assert.Catch(typeof(ArgumentNullException), () => new Player(name, ColorEnum.Blue));
        }

        [Test]
        public void Player_Dice_Only_Have_Numbers_Between_One_And_Six()
        {
            var player = new Player("player1", ColorEnum.Red);

            var rollData = Enumerable.Repeat(player.RollDice(), 100);

            Assert.That(() => rollData.All(c => c <= 6 && c >= 1));
        }


        [Test]
        public void Players_With_Same_Name_Are_Equal()
        {
            var player1 = new Player("player1", ColorEnum.Red);
            var player2 = new Player("player1", ColorEnum.Blue);

            var res = player1.Equals(player2);

            Assert.IsTrue(res);
        }

        [Test]
        public void Players_With_Same_Color_Are_Equal()
        {
            var player1 = new Player("player1", ColorEnum.Red);
            var player2 = new Player("player2", ColorEnum.Red);

            var res = player1.Equals(player2);

            Assert.IsTrue(res);
        }
         
        [Test]
        public void Players_Diffrent_Color_And_Name_Are_Equal()
        {
            var player1 = new Player("player1", ColorEnum.Yellow);
            var player2 = new Player("player2", ColorEnum.Red);

            var res = player1.Equals(player2);

            Assert.IsFalse(res);
        }  

        [Test]
        public void Players_Currencly_Moves_On()
        {
            var playerName = "player1";
            var playerColor = ColorEnum.Yellow;
            var player = new Player(playerName, playerColor);
            var board = new Mock<Board>();
            board.Setup(c => c.CalculateNextPostion(It.IsAny<int>(), It.IsAny<int>())).Returns((int position, int dice) => position + dice);

            var res = player.MoveOn(board.Object);

            Assert.AreEqual(playerColor, res.Color);
            Assert.AreEqual(playerName, res.Name);
            Assert.AreEqual(1, res.OldPosition);
            Assert.AreEqual(1 + res.DiceValue, res.NewPosition);
        }
    }
}
