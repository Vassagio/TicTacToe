using System;
using TicTacToe.Core;
using TicTacToe.Core.Game.Board;
using TicTacToe.Core.Game.Visitor;

namespace TicTacToe.UI {
    internal class PrintBoardVisitor : IGameVisitor
    {
        public void Execute(TicTacToeBoard board)
        {
            const string BORDER = "|-----|-----|-----|";
            Console.WriteLine(BORDER);
            for (var x = 1; x <= board.Size; x++) {
                Console.Write("|");
                for (var y = 1; y <= board.Size; y++)
                {
                    Console.Write($"  {board.GetTile(x, y).Position}  ");
                    Console.Write("|");
                }
                Console.WriteLine();
                Console.WriteLine(BORDER);
            }
        }
    }
}