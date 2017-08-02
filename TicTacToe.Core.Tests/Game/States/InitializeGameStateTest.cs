using System;
using Project.Mocks;
using Test.Utilities.StateHelper;
using TicTacToe.Core.Game.States;
using Xunit;

namespace TicTacToe.Core.Tests.Game.States
{
    public class InitializeGameStateTest
    {
        private static readonly Func<InitializeGameState> INITIALIZE = () => State.Create<InitializeGameState>();
        private static readonly Func<StartGameState> START = () => State.Create<StartGameState>();

        [Fact]
        public void Initialize_ChangeStates() {
            var state = INITIALIZE();

            StateTests<IGameState>
                .For(state)
                .When(() => state.CheckForWin(() => new MockFunc<bool>().Run())).TransitionTo(INITIALIZE).And()
                .When(() => state.End()).TransitionTo(INITIALIZE).And()
                .When(() => state.Over()).TransitionTo(INITIALIZE).And()
                .When(() => state.Play(() => new MockAction().Run())).TransitionTo(INITIALIZE).And()
                .When(() => state.PlayAgain(() => new MockFunc<bool>().Run())).TransitionTo(INITIALIZE).And()
                .When(() => state.Start()).TransitionTo(START).And()
                .When(() => state.SwitchPlayer(() => new MockAction().Run())).TransitionTo(INITIALIZE)
                .Assert();
        }

        [Fact]
        public void CheckForWin_VerifyFunctionNotCalled()
        {
            var predicate = new MockFunc<bool>();
            var state = INITIALIZE();

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
            var state = INITIALIZE();

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
            var state = INITIALIZE();

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
            var state = INITIALIZE();

            StateTests<IGameState>
                .For(state)
                .When(() => state.SwitchPlayer(() => action.Run()))
                .Invoke();

            action.VerifyActionNotCalled();
        }
    }
}
