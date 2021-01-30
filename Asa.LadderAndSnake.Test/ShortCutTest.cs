using LadderAndSnake.BoardData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.LadderAndSnake.Test
{
    public class ShortCutTest
    {
        [Test]
        public void ShortCuts_With_Same_Start_And_End_Should_Be_Equal() 
        {
            var start = 50;
            var end = 75;
            var shortCut1 = new ShortCut(start, end);
            var shortCut2 = new ShortCut(start, end);

            var res = shortCut1.Equals(shortCut2);

            Assert.IsTrue(res);
        }


        [Test]
        public void ShortCuts_With_Same_Start_And_End_Should_Not_Be_Equal() 
        {
            var start = 50;
            var end = 75;
            var shortCut1 = new ShortCut(start, end);
            var shortCut2 = new ShortCut(start + end, end);

            var res = shortCut1.Equals(shortCut2);

            Assert.IsFalse(res);
        }
    }
}
