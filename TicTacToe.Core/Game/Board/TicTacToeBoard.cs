using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Project.Utilities;
using TicTacToe.Core.Game.Board.Service;
using TicTacToe.Core.Game.Board.Tile;
using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Board {
    public class TicTacToeBoard : IEnumerable<ITile>, IBoard
    {
        private readonly List<ITile> _tiles;
        public int Size { get; }

        public static TicTacToeBoard Initialize(int size, IBoardService boardService) {
            var tiles = boardService.GenerateTilesWithCoordinates(size);
            return new TicTacToeBoard(size, tiles);
        }        

        private TicTacToeBoard(int size, IEnumerable<ITile> tiles) {
            Size = size;
            _tiles = new List<ITile>(tiles);
        }

        public IEnumerator<ITile> GetEnumerator() => _tiles.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => _tiles.Count;        

        public ITile GetTileBy(int x, int y) {
            var tile = _tiles.FirstOrDefault(t => t.Coordinate.X == x && t.Coordinate.Y == y);
            return tile ?? new OutOfBoundsTile();
        }

        public ITile GetTileBy(ICoordinate coordinate)
        {
            var tile = _tiles.FirstOrDefault(t => t.Coordinate.Equals(coordinate));
            return tile ?? new OutOfBoundsTile();
        }

        public ITile GetTileBy(int position)
        {
            var tile = _tiles.FirstOrDefault(t => t.Position.Equals(position));
            return tile ?? new OutOfBoundsTile();
        }

        public TicTacToeBoard ReserveTileBy(ICoordinate coordinate, IPlayer currentPlayer) {            
            var tile = GetTileBy(coordinate);
            if (tile is OutOfBoundsTile) return this;

            return AdjustBoard(tile, currentPlayer);
        }


        public TicTacToeBoard ReserveTileBy(int x, int y, IPlayer currentPlayer)
        {
            var tile = GetTileBy(x, y);
            if (tile is OutOfBoundsTile) return this;

            return AdjustBoard(tile, currentPlayer);
        }

        public TicTacToeBoard ReserveTileBy(int position, IPlayer currentPlayer)
        {
            var tile = GetTileBy(position);
            if (tile is OutOfBoundsTile) return this;

            return AdjustBoard(tile, currentPlayer);
        }

        private TicTacToeBoard AdjustBoard(ITile tile, IPlayer currentPlayer)
        {
            var newTiles = _tiles.DeepClone().ToList();
            newTiles.Remove(tile);
            var newTile = tile.SetPlayer(currentPlayer);
            newTiles.Add(newTile);
            return new TicTacToeBoard(Size, newTiles);
        }
    }
}