using TicTacToe.Core.Game.Board;
using TicTacToe.Core.Game.Board.Tile;

namespace TicTacToe.UI
{
    public static class TileExtension
    {


        public static void Display(this ITile tile, IBoard board) {            
            //if (tile.Coordinate.X == 1) Console.Write("|");
            //Console.Write($"  {tile.Position}  ");
            //Console.Write("|");
            //if (tile.Coordinate.X == board.Size) {
            //    Console.WriteLine();
            //    Console.WriteLine(BORDER);
            //}
        }
    }  
}
