using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Core.Game.Board.Tile.Coordinate {
    public struct AvailableCoordinate : ICoordinate
    {
        public int X { get; }
        public int Y { get; }        

        public AvailableCoordinate(int x, int y) {
            X = x;
            Y = y;
        }
    }
}