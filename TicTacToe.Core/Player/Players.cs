using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Core.Player {
    internal class Players : IEnumerable<IPlayer>, IPlayers
    {
        public IPlayer Current { get; }
        private readonly IList<IPlayer> _players = new List<IPlayer>();      

        public Players() { }
        private Players(IEnumerable<IPlayer> players, IPlayer currentPlayer) {
            _players = new List<IPlayer>(players);
            Current = currentPlayer;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<IPlayer> GetEnumerator() => _players.GetEnumerator();

        public IPlayers Add(IPlayer player) {
            _players.Add(player);
            return new Players(_players, Current);
        }

        public IPlayers SetCurrentPlayer(IPlayer currentPlayer) {
            if (!_players.Contains(currentPlayer))
                throw new ArgumentException();

            return new Players(_players, currentPlayer);
        }

        public IPlayers Next() {
            var newCurrentPlayer = _players.SingleOrDefault(p => !p.Equals(Current));
            return new Players(_players, newCurrentPlayer);
        } 
    }
}