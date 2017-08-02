using System.Collections.Generic;
using System.Linq;
using Project.Utilities;
using TicTacToe.Core.Game.Board.Tile;
using TicTacToe.Core.Game.Board.Tile.Coordinate;

namespace TicTacToe.Core.Game.Board.Service
{
    public class BoardService : IBoardService
    {
        private IEnumerable<AvailableCoordinate> BuildCoordinateGrid(int size)
        {
            var horizontals = Enumerable.Range(1, size).RepeatSequence(3);
            var verticals = Enumerable.Range(1, size).Repeat(3);            
            return Enumerable.Zip(horizontals, verticals, (h, v) => new AvailableCoordinate(h, v));
        }

        private IEnumerable<EmptyTile> BuildTileGrid(AvailableCoordinate[] coordinates)
        {
            var positions = Enumerable.Range(1, coordinates.Length);
            return Enumerable.Zip(positions, coordinates, (p, c) => new EmptyTile(p, c));
        }

        public IEnumerable<EmptyTile> GenerateEmptyTilesWithAvailableCoordinates(int size)
        {
            var coordinates = BuildCoordinateGrid(size);
            return BuildTileGrid(coordinates.ToArray());
        }
    }
}
