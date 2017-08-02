using System;

namespace TicTacToe.Core.Player {
    public sealed class PlayerType : IPlayerType, IPlayerTypeCreate, IEquatable<PlayerType> {
        private enum StatusRepresentation {
            None,
            Human,
            Computer
        }

        public static IPlayerType As() => new PlayerType(StatusRepresentation.None, new UnknownPlayer());

        public static bool operator ==(PlayerType a, PlayerType b) => ReferenceEquals(a, null) && ReferenceEquals(b, null) || !ReferenceEquals(a, null) && a.Equals(b);

        public static bool operator !=(PlayerType a, PlayerType b) => !(a == b);

        private StatusRepresentation Representation { get; }

        private readonly IPlayer _player;

        private PlayerType(StatusRepresentation represenation, IPlayer player) {
            Representation = represenation;
            _player = player;
        }

        public bool Equals(PlayerType other) => other != null && Representation == other.Representation;

        public IPlayerTypeCreate Human(string name, string symbol) => new PlayerType(StatusRepresentation.Human, new HumanPlayer(name, symbol));

        public IPlayerTypeCreate Computer(string name, string symbol) => new PlayerType(StatusRepresentation.Computer, new ComputerPlayer(name, symbol));

        public IPlayer Create() => _player;

        public override bool Equals(object obj) => Equals(obj as PlayerType);

        public override int GetHashCode() => (int) Representation;
    }
}