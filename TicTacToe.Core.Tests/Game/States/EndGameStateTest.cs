using System;
using Project.Mocks;
using Test.Utilities.StateHelper;
using TicTacToe.Core.Game.States;
using Xunit;

namespace TicTacToe.Core.Tests.Game.States
{
    public class EndGameStateTest
    {
        private static readonly Func<EndGameState> END = () => State.Create<EndGameState>();        

        [Fact]
        public void Start_ChangeStates()
        {
            var state = END();

            StateTests<IGameState>
                .For(state)
                .When(() => state.CheckForWin(() => new MockFunc<bool>().Run())).TransitionTo(END).And()
                .When(() => state.End()).TransitionTo(END).And()
                .When(() => state.Over()).TransitionTo(END).And()
                .When(() => state.Play(() => new MockAction().Run())).TransitionTo(END).And()
                .When(() => state.PlayAgain(() => new MockFunc<bool>().Run())).TransitionTo(END).And()
                .When(() => state.Start()).TransitionTo(END).And()
                .When(() => state.SwitchPlayer(() => new MockAction().Run())).TransitionTo(END)
                .Assert();
        }

        [Fact]
        public void CheckForWin_VerifyFunctionNotCalled()
        {
            var predicate = new MockFunc<bool>();
            var state = END();

            StateTests<IGameState>
                .For(state)
                .When(() => state.CheckForWin(() => predicate.Run()))
                .Invoke();

            predicate.VerifyFunctionNotCalled();
        }

        [Fact]
        public void Play_VerifyActionNotCalled()
        {
            var action = new MockAction();
            var state = END();

            StateTests<IGameState>
                .For(state)
                .When(() => state.Play(() => action.Run()))
                .Invoke();

            action.VerifyActionNotCalled();
        }

        [Fact]
        public void PlayAgain_VerifyFunctionNotCalled()
        {
            var predicate = new MockFunc<bool>();
            var state = END();

            StateTests<IGameState>
                .For(state)
                .When(() => state.PlayAgain(() => predicate.Run()))
                .Invoke();

            predicate.VerifyFunctionNotCalled();
        }

        [Fact]
        public void SwitchPlayer_VerifyActionNotCalled()
        {
            var action = new MockAction();
            var state = END();

            StateTests<IGameState>
                .For(state)
                .When(() => state.SwitchPlayer(() => action.Run()))
                .Invoke();

            action.VerifyActionNotCalled();
        }
    }
}
