namespace TicTacToe.Core.Game.Board.Tile.Coordinate {
    public struct AvailableCoordinate : ICoordinate
    {
        public int X { get; }
        public int Y { get; }

        public AvailableCoordinate(int x, int y) {
            X = x;
            Y = y;
        }

        public bool Equals(AvailableCoordinate other) => X == other.X && Y == other.Y;

        public bool Equals(ICoordinate other)
        {
            if (ReferenceEquals(null, other))
                return false;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is AvailableCoordinate && Equals((AvailableCoordinate) obj);
        }

        public override int GetHashCode() {
            unchecked {
                return (X * 397) ^ Y;
            }
        }
    }
}