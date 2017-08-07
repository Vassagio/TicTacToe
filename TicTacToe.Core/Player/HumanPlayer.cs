using System;
using TicTacToe.Core.Game.Board.Tile.Coordinate;

namespace TicTacToe.Core.Player {
    internal sealed class HumanPlayer : BasePlayer, IEquatable<HumanPlayer> {
        public HumanPlayer(string name, string symbol) : base(name, symbol) { }
        public override ICoordinate GetNextMove() => new NoCoordinate();

        public bool Equals(HumanPlayer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name.Equals(other.Name) && Symbol.Equals(other.Symbol);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((HumanPlayer)obj);
        }

        public override int GetHashCode() => Name.GetHashCode() ^ Symbol.GetHashCode();

        public static bool operator ==(HumanPlayer a, HumanPlayer b)
        {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);
            return a.Equals(b);
        }

        public static bool operator !=(HumanPlayer a, HumanPlayer b) => !(a == b);
    }
}