using System;
using TicTacToe.Core.Game.Board.Tile.Coordinate;

namespace TicTacToe.Core.Player {
    internal sealed class HumanPlayer : BasePlayer, IEquatable<HumanPlayer> {
        public HumanPlayer(string name, string symbol) : base(name, symbol) { }
        public override ICoordinate GetNextMove() => new NoCoordinate();

        public bool Equals(HumanPlayer other) => other != null && Name == other.Name && Symbol == other.Symbol;

        public override bool Equals(object obj) => Equals(obj as HumanPlayer);

        public override int GetHashCode() => Name.GetHashCode() ^ Symbol.GetHashCode();

        public static bool operator ==(HumanPlayer a, HumanPlayer b) => ReferenceEquals(a, null) && ReferenceEquals(b, null) || !ReferenceEquals(a, null) && a.Equals(b);

        public static bool operator !=(HumanPlayer a, HumanPlayer b) => !(a == b);
    }
}