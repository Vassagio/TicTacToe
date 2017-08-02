using TicTacToe.Core.Game.Board.Tile.Coordinate;

namespace TicTacToe.Core.Player {
    internal class HumanPlayer : BasePlayer {
        public HumanPlayer(string name, string symbol) : base(name, symbol) { }
        public override ICoordinate GetNextMove() => throw new System.NotImplementedException();
    }
}