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

        public static bool operator ==(StartingPlayer a, StartingPlayer b) => ReferenceEquals(a, null) && ReferenceEquals(b, null) || !ReferenceEquals(a, null) && a.Equals(b);

        public static bool operator !=(StartingPlayer a, StartingPlayer b) => !(a == b);

        private StatusRepresentation Representation { get; }

        private StartingPlayer(StatusRepresentation represenation) => Representation = represenation;

        public bool Equals(StartingPlayer other) => other != null && Representation == other.Representation;

        public StartingPlayer FirstPlayer() => new StartingPlayer(StatusRepresentation.FirstPlayer);

        public StartingPlayer SecondPlayer() => new StartingPlayer(StatusRepresentation.SecondPlayer);

        public override bool Equals(object obj) => Equals(obj as StartingPlayer);

        public override int GetHashCode() => (int)Representation;
    }

    public interface IStartingPlayer
    {
        StartingPlayer FirstPlayer();
        StartingPlayer SecondPlayer();
    }
}

