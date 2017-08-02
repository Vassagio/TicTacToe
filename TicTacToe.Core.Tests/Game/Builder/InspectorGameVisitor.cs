using TicTacToe.Core.Game.Board;
using TicTacToe.Core.Game.Visitor;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Tests.Game.Builder {
    internal class InspectorGameVisitor : IGameVisitor {
        public IBoard Board { get; private set; }
        public IPlayers Players { get; private set; }

        public void Execute(IBoard board, IPlayers players) {
            Board = board;
            Players = players;
        }
    }
}