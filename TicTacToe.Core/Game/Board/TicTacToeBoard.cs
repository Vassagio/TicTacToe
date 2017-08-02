using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.Core.Game.Board.Tile;
using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Board {
    public class TicTacToeBoard: IReadOnlyList<ITile> {
        private readonly List<ITile> _tiles;
        public int Size { get; }

        public static TicTacToeBoard Initialize(int size) {
            var tiles = new List<ITile>();
            for (var x = 1; x <= size; x++)
            {
                for (var y = 1; y <= size; y++)
                {
                    var coordinate = new AvailableCoordinate(x, y);
                    var tile = new EmptyTile(tiles.Count + 1, coordinate);
                    tiles.Add(tile);
                }
            }
            return new TicTacToeBoard(size, tiles);
        }        

        private TicTacToeBoard(int size, IEnumerable<ITile> tiles) {
            Size = size;
            _tiles = new List<ITile>(tiles);
        }

        public IEnumerator<ITile> GetEnumerator() => _tiles.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => _tiles.Count;

        public ITile this[int index] => _tiles[index];

        public ITile GetTile(int x, int y) => GetTile(new AvailableCoordinate(x, y));

        public ITile GetTile(ICoordinate coordinate)
        {
            var tile = _tiles.FirstOrDefault(t => t.Coordinate.Equals(coordinate));
            return tile ?? new OutOfBoundsTile();
        }

        public ITile GetTile(int position)
        {
            var tile = _tiles.FirstOrDefault(t => t.Position.Equals(position));
            return tile ?? new OutOfBoundsTile();
        }

        public TicTacToeBoard SetTile(ICoordinate coordinate, IPlayer currentPlayer) {
            GetTile(coordinate).SetPlayer(currentPlayer);              
            return new TicTacToeBoard(Size, _tiles);
        }
    }
}