namespace TicTacToe.Core.Game.Board.Tile.Coordinate {
    public struct NoCoordinate : ICoordinate {
        public int X => 0;
        public int Y => 0;
        public bool Equals(NoCoordinate other) => X == other.X && Y == other.Y;

        public bool Equals(ICoordinate other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (!(other is NoCoordinate))
                return false;                
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is NoCoordinate && Equals((NoCoordinate)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}