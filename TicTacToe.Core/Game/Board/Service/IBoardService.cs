using System.Collections.Generic;
using TicTacToe.Core.Game.Board.Tile;

namespace TicTacToe.Core.Game.Board.Service
{
    public interface IBoardService
    {        
        IEnumerable<ITile> GenerateTilesWithCoordinates(int size);
    }
}