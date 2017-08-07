using System;
using TicTacToe.Core.Game.Board;
using TicTacToe.Core.Game.Visitor;

namespace TicTacToe.UI {
    internal class DisplayBoardVisitor : IGameVisitor
    {
        public void Execute(IBoard board)
        {
            const string BORDER = "|-----|-----|-----|";
            Console.Clear();
            Console.WriteLine(BORDER);

            foreach (var tile in board)
            {
                if (tile.Coordinate.X == 1) Console.Write("|");
                Console.Write($"  {tile.Position}  ");
                Console.Write("|");
                if (tile.Coordinate.X == board.Size)
                {
                    Console.WriteLine();
                    Console.WriteLine(BORDER);
                }
            }

            Console.ReadKey();
        }        
    }
}