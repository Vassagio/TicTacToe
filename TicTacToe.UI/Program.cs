using System;
using TicTacToe.Core.Game.Builder;
using TicTacToe.Core.Player;

namespace TicTacToe.UI
{
    public class Program
    {
        private static void Main(string[] args)
        {            

            var game = GameBuilder
                .WithBoardSize(3)
                .FirstPlayerSet(PlayerType.As().Human("Player", "X"))
                .SecondPlayerSet(PlayerType.As().Computer("Computer", "O"))
                .Set(StartingPlayer.As().FirstPlayer())
                .Create();
            
            do
            {
                game.Accept(new PrintBoardVisitor());
                game.Start();
                game.Play();
                game.CheckForWin();
                game.SwitchPlayer();
                game.Over();
                game.NewGame();
                game.End();
            } while (game.StillGoing);
            
            Console.ReadKey();
        }
    }
}