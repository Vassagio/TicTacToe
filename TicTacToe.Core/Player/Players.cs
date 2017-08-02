using System;
using System.Collections.Generic;
using Project.Utilities;

namespace TicTacToe.Core.Player {
    public class Players : IPlayers
    {
        public IPlayer Current { get; } = new UnknownPlayer();
        private readonly LinkedList<IPlayer> _players = new LinkedList<IPlayer>();    
        

        public Players() { }
        private Players(IEnumerable<IPlayer> players, IPlayer currentPlayer) {
            _players = new LinkedList<IPlayer>(players);
            Current = currentPlayer;
        }
        
        internal int Count => _players.Count;

        public IPlayers Add(IPlayer player) {
            if (_players.Count >= 2)
                throw new ArgumentException();

            _players.AddLast(player);
            return new Players(_players, Current);
        }

        public IPlayers SetCurrentPlayer(IPlayer currentPlayer) {
            if (!_players.Contains(currentPlayer))
                throw new ArgumentException();

            return new Players(_players, currentPlayer);
        }

        public IPlayers Next() {
            var currentPlayerNode = _players.Find(Current) ?? _players.First;
            var newCurrentPlayer = currentPlayerNode != null ? currentPlayerNode.NextOrFirst().Value : new UnknownPlayer();
            return new Players(_players, newCurrentPlayer);
        } 
    }
}