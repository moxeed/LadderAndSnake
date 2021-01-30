using LadderAndSnake.BoardData;
using NUnit.Framework;
using System.Collections.Generic;

namespace Asa.LadderAndSnake.Test
{
    public class PolicyTest
    {

        [Test]
        public void Snake_Should_Have_Lower_End_Than_Start()
        {
            var policy = new SnakePolicy();
            var shortCuts = new List<ShortCut>();

            var res = policy.IsValid(new ShortCut(5, 10), shortCuts);

            Assert.IsFalse(res);
        }

        [Test]
        public void Normal_Snake_Returns_True()
        {
            var policy = new SnakePolicy();
            var shortCuts = new List<ShortCut>();

            var res = policy.IsValid(new ShortCut(10, 5), shortCuts);

            Assert.IsTrue(res);
        }
        
        [Test]
        public void Snake_Should_Have_Unique_Start_Point()
        {
            var policy = new SnakePolicy();
            var shortCuts = new List<ShortCut>() 
                { new ShortCut(10, 20) };

            var res = policy.IsValid(new ShortCut(10, 15), shortCuts);

            Assert.IsFalse(res);
        }


        [Test]
        public void Snake_Should_Not_Create_Loop()
        {
            var policy = new SnakePolicy();
            var shortCuts = new List<ShortCut>() 
                { new ShortCut(20, 10) };

            var res = policy.IsValid(new ShortCut(10, 20), shortCuts);

            Assert.IsFalse(res);
        }

        [Test]
        public void Ladder_Should_Have_Higher_End_Than_Start()
        {
            var policy = new LadderPolicy();
            var shortCuts = new List<ShortCut>();

            var res = policy.IsValid(new ShortCut(10, 5), shortCuts);

            Assert.IsFalse(res);
        }

        [Test]
        public void Normal_Ladder_Returns_True()
        {
            var policy = new LadderPolicy();
            var shortCuts = new List<ShortCut>();

            var res = policy.IsValid(new ShortCut(5, 10), shortCuts);

            Assert.IsTrue(res);
        }

        [Test]
        public void Ladder_Should_Have_Unique_Start_Point()
        {
            var policy = new LadderPolicy();
            var shortCuts = new List<ShortCut>()
                { new ShortCut(10, 20) };

            var res = policy.IsValid(new ShortCut(10, 15), shortCuts);

            Assert.IsFalse(res);
        }


        [Test]
        public void Ladder_Should_Not_Create_Loop()
        {
            var policy = new LadderPolicy();
            var shortCuts = new List<ShortCut>()
                { new ShortCut(20, 10) };

            var res = policy.IsValid(new ShortCut(10, 20), shortCuts);

            Assert.IsFalse(res);
        }
    }
}