using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Builder {
    public interface IStartingPlayerMapper {
        IStartingPlayerMapper Add(IStartingPlayer startingPlayer, IPlayer player);
        IPlayer this[IStartingPlayer key] { get; }
    }
}