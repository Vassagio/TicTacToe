using System;
using TicTacToe.Core.Game.Board;
using TicTacToe.Core.Game.Visitor;
using TicTacToe.Core.Player;

namespace TicTacToe.UI {
    internal class PrintBoardVisitor : IGameVisitor
    {
        public void Execute(IBoard board, IPlayers players)
        {
            const string BORDER = "|-----|-----|-----|";
            Console.Clear();
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
            Console.ReadKey();
        }
    }
}