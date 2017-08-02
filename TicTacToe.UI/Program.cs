using Autofac;
using TicTacToe.Core.Game.Board.Service;
using TicTacToe.Core.Game.Builder;
using TicTacToe.Core.Player;

namespace TicTacToe.UI
{
    public class Program
    {
        public static IContainer Container { get; set; }

        private static int Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<StartingPlayerMapper>().As<IStartingPlayerMapper>();
            builder.RegisterType<Players>().As<IPlayers>();
            builder.RegisterType<BoardService>().As<IBoardService>();

            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
            {                
                scope.Resolve<IApplication>().Run();
            }

            return 0;
        }        
    }
}