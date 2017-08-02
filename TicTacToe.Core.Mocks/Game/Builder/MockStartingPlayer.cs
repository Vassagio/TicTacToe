using System;
using Moq;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Mocks.Game.Builder {
    public sealed class MockStartingPlayer : IStartingPlayer, IEquatable<MockStartingPlayer> {
        private readonly Mock<IStartingPlayer> _mock = new Mock<IStartingPlayer>();

        public StartingPlayer FirstPlayer() => _mock.Object.FirstPlayer();

        public StartingPlayer SecondPlayer() => _mock.Object.SecondPlayer();

        public static bool operator ==(MockStartingPlayer a, MockStartingPlayer b) => ReferenceEquals(a, null) && ReferenceEquals(b, null) || !ReferenceEquals(a, null) && a.Equals(b);

        public static bool operator !=(MockStartingPlayer a, MockStartingPlayer b) => !(a == b);

        public bool Equals(MockStartingPlayer other) => other != null && _mock.Name == other._mock.Name;
        
        public override bool Equals(object obj) => Equals(obj as MockStartingPlayer);

        public override int GetHashCode() => _mock.Name.GetHashCode();
    }
}