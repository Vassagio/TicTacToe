using System;
using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Board.Tile {
    public sealed class OccupiedTile : ITile, IEquatable<OccupiedTile>
    {
        public int Position { get; }
        public ICoordinate Coordinate { get; }
        public IPlayer Player { get; private set; } = new UnknownPlayer();
        
        public OccupiedTile(int position, ICoordinate coordinate) {
            Position = position;
            Coordinate = coordinate;
        }

        public ITile SetPlayer(IPlayer player) => new OccupiedTile(Position, Coordinate) {
            Player = player
        };

        public bool Equals(OccupiedTile other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Position.Equals(other.Position) && Coordinate.Equals(other.Coordinate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((OccupiedTile)obj);
        }

        public override int GetHashCode() => Position.GetHashCode() ^ Coordinate.GetHashCode();

        public static bool operator ==(OccupiedTile a, OccupiedTile b)
        {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);
            return a.Equals(b);
        }

        public static bool operator !=(OccupiedTile a, OccupiedTile b) => !(a == b);
    }
}