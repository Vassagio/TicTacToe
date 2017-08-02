using TicTacToe.Core.Game.Board.Tile.Coordinate;

namespace TicTacToe.Core.Player {
    internal class ComputerPlayer : BasePlayer {
        public ComputerPlayer(string name, string symbol) : base(name, symbol) { }
        public override ICoordinate GetNextMove() => throw new System.NotImplementedException();
    }
}