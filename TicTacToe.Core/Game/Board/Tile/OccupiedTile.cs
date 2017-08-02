using System;
using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Board.Tile {
    public sealed class OccupiedTile : ITile, IEquatable<OccupiedTile>
    {
        public int Position { get; }
        public ICoordinate Coordinate { get; }
        public IPlayer Player { get; private set; }
        
        public OccupiedTile(int position, ICoordinate coordinate) {
            Position = position;
            Coordinate = coordinate;
        }

        public ITile SetPlayer(IPlayer player) => new OccupiedTile(Position, Coordinate) {
            Player = player
        };

        public bool Equals(OccupiedTile other) {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Position == other.Position && Coordinate.Equals(other.Coordinate) && Equals(Player, other.Player);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((OccupiedTile) obj);
        }

        public override int GetHashCode() {
            unchecked {
                var hashCode = Position;
                hashCode = (hashCode * 397) ^ Coordinate.GetHashCode();
                hashCode = (hashCode * 397) ^ (Player != null ? Player.GetHashCode() : 0);
                return hashCode;
            }
        }

        public static bool operator ==(OccupiedTile a, OccupiedTile b) {
            if (ReferenceEquals(null, a))
                return false;
            if (ReferenceEquals(null, b))
                return false;
            if (ReferenceEquals(a, b))
                return true;
            return a.Position == b.Position && a.Coordinate.Equals(b.Coordinate) && Equals(a.Player, b.Player);
        }

        public static bool operator !=(OccupiedTile a, OccupiedTile b) => !(a == b);
    }
}