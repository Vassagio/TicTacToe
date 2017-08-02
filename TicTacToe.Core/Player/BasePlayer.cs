using TicTacToe.Core.Game.Board.Tile.Coordinate;

namespace TicTacToe.Core.Player {
    internal abstract class BasePlayer : IPlayer {        
        public string Name { get; }
        public string Symbol { get; }

        protected BasePlayer(string name, string symbol) {
            Name = name;
            Symbol = symbol;
        }        

        public abstract ICoordinate GetNextMove();
    }
}