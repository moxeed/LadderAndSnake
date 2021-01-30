﻿using LadderAndSnake.BoardData;
using System;
using System.Runtime.CompilerServices;

namespace LadderAndSnake
{
    internal class Player
    {
        public string Name { get; }
        public int Position { get; private set; } = 1;
        public ColorEnum Color { get; }

        public Player(string name, ColorEnum color)
        {

            Name = name != null ? name.Trim().ToLower() : throw new ArgumentNullException(nameof(name));
            Color = color;
        }

        public int RollDice()
        {
            var randomGenerator = new Random();
            var randomNumber = randomGenerator.Next(1, 1000);
            var diceValue = (randomNumber % 6) + 1;
            return diceValue;
        }

        public override bool Equals(object obj)
        {
            if (obj is Player player)
            {
                var namesAreTheSame = string.Compare(Name, player.Name, true) == 0;
                var colorsAreTheSame = Color == player.Color;
                return namesAreTheSame || colorsAreTheSame;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Color);
        }
        public static bool operator ==(Player p1, Player p2) => p1.Equals(p2);
        public static bool operator !=(Player p1, Player p2) => !p1.Equals(p2);

        internal MoveResult MoveOn(Board board)
        {
            var diceValue = RollDice();
            var oldPosition = Position;
            var newPosition = board.CalculateNextPostion(oldPosition, diceValue);
            Position = newPosition;
            return new MoveResult(Name, Color, oldPosition, newPosition, diceValue);
        }
    }
}
