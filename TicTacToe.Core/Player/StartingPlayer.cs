using System;

namespace TicTacToe.Core.Player
{
    public sealed class StartingPlayer : IStartingPlayer, IEquatable<StartingPlayer>
    {
        private enum StatusRepresentation
        {
            None,
            FirstPlayer,
            SecondPlayer
        }

        public static IStartingPlayer As() => new StartingPlayer(StatusRepresentation.None);

        private StatusRepresentation Representation { get; }

        private StartingPlayer(StatusRepresentation represenation) => Representation = represenation;

        public StartingPlayer FirstPlayer() => new StartingPlayer(StatusRepresentation.FirstPlayer);

        public StartingPlayer SecondPlayer() => new StartingPlayer(StatusRepresentation.SecondPlayer);

        public bool Equals(StartingPlayer other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Representation.Equals(other.Representation);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((StartingPlayer)obj);
        }

        public override int GetHashCode() => Representation.GetHashCode();

        public static bool operator ==(StartingPlayer a, StartingPlayer b)
        {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);
            return a.Equals(b);
        }

        public static bool operator !=(StartingPlayer a, StartingPlayer b) => !(a == b);
    }
}

