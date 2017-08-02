using System;
using Project.Mocks;
using Test.Utilities.StateHelper;
using TicTacToe.Core.Game.States;
using Xunit;

namespace TicTacToe.Core.Tests.Game.States
{
    public class StartGameStateTest
    {        
        private static readonly Func<StartGameState> START = () => State.Create<StartGameState>();
        private static readonly Func<PlayGameState> PLAY = () => State.Create<PlayGameState>();

        [Fact]
        public void Start_ChangeStates()
        {
            var state = START();

            StateTests<IGameState>
                .For(state)
                .When(() => state.CheckForWin(() => new MockFunc<bool>().Run())).TransitionTo(START).And()
                .When(() => state.End()).TransitionTo(START).And()
                .When(() => state.Over()).TransitionTo(START).And()
                .When(() => state.Play(() => new MockAction().Run())).TransitionTo(PLAY).And()
                .When(() => state.PlayAgain(() => new MockFunc<bool>().Run())).TransitionTo(START).And()
                .When(() => state.Start()).TransitionTo(START).And()
                .When(() => state.SwitchPlayer(() => new MockAction().Run())).TransitionTo(START)
                .Assert();
        }

        [Fact]
        public void CheckForWin_VerifyFunctionNotCalled()
        {
            var predicate = new MockFunc<bool>();
            var state = START();

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
            var state = START();

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
            var state = START();

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
            var state = START();

            StateTests<IGameState>
                .For(state)
                .When(() => state.SwitchPlayer(() => action.Run()))
                .Invoke();

            action.VerifyActionNotCalled();
        }
    }
}
