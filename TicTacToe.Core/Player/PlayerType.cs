using System;

namespace TicTacToe.Core.Player {
    public sealed class PlayerType : IPlayerType, IEquatable<PlayerType> {
        private enum StatusRepresentation {
            None,
            Human,
            Computer
        }

        public static IPlayerType As() => new PlayerType(StatusRepresentation.None, new UnknownPlayer());
       
        private StatusRepresentation Representation { get; }

        public IPlayer Player { get; }

        private PlayerType(StatusRepresentation represenation, IPlayer player) {
            Representation = represenation;
            Player = player;
        }
        
        public PlayerType Human(string name, string symbol) => new PlayerType(StatusRepresentation.Human, new HumanPlayer(name, symbol));

        public PlayerType Computer(string name, string symbol) => new PlayerType(StatusRepresentation.Computer, new ComputerPlayer(name, symbol));

        public bool Equals(PlayerType other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Representation.Equals(other.Representation) && Player.Equals(other.Player);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((PlayerType)obj);
        }

        public override int GetHashCode() => Representation.GetHashCode() * Player.GetHashCode();

        public static bool operator ==(PlayerType a, PlayerType b)
        {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);
            return a.Equals(b);
        }

        public static bool operator !=(PlayerType a, PlayerType b) => !(a == b);
    }
}