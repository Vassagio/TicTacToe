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
            var horizontals = Enumerable.Range(1, size).RepeatSequence(size);
            var verticals = Enumerable.Range(1, size).RepeatTerms(size);            
            return Enumerable.Zip(horizontals, verticals, (h, v) => new AvailableCoordinate(h, v));
        }

        private IEnumerable<ITile> BuildTileGrid(AvailableCoordinate[] coordinates)
        {
            var positions = Enumerable.Range(1, coordinates.Length);
            return Enumerable.Zip(positions, coordinates, (p, c) => new EmptyTile(p, c));
        }

        public IEnumerable<ITile> GenerateTilesWithCoordinates(int size)
        {
            if (size <= 0) return new List<ITile>();

            var coordinates = BuildCoordinateGrid(size);
            return BuildTileGrid(coordinates.ToArray());
        }
    }
}
