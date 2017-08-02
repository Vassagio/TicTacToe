using System.Collections.Generic;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Builder
{
    public class StartingPlayerMapper: IStartingPlayerMapper
    {
        private readonly Dictionary<IStartingPlayer, IPlayer> _startingPlayers = new Dictionary<IStartingPlayer, IPlayer>();
        public StartingPlayerMapper() { }
        private StartingPlayerMapper(Dictionary<IStartingPlayer, IPlayer> startingPlayers) => _startingPlayers = new Dictionary<IStartingPlayer, IPlayer>(startingPlayers);

        public IStartingPlayerMapper Add(IStartingPlayer startingPlayer, IPlayer player)
        {
            var dictionary = new Dictionary<IStartingPlayer, IPlayer>(_startingPlayers) {
                {
                    startingPlayer, player
                }
            };
            return new StartingPlayerMapper(dictionary);
        }

        public IPlayer this[IStartingPlayer key] => _startingPlayers[key];
    }
}
