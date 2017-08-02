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

        public bool Equals(OccupiedTile other) => other != null && Position == other.Position && Equals(Coordinate, other.Coordinate);

        public override bool Equals(object obj) => !ReferenceEquals(obj, null) && Equals(obj as OccupiedTile);

        public override int GetHashCode() => (Position.GetHashCode() * 397) ^ (Coordinate.GetHashCode() * 397);

        public static bool operator ==(OccupiedTile a, OccupiedTile b) => ReferenceEquals(a, null) && ReferenceEquals(b, null) || !ReferenceEquals(a, null) && a.Equals(b);

        public static bool operator !=(OccupiedTile a, OccupiedTile b) => !(a == b);
    }
}