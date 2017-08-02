using System;
using Project.Mocks;
using Test.Utilities.StateHelper;
using TicTacToe.Core.Game.States;
using Xunit;

namespace TicTacToe.Core.Tests.Game.States
{
    public class OverGameStateTest
    {
        private static readonly Func<OverGameState> OVER = () => State.Create<OverGameState>();
        private static readonly Func<PlayAgainGameState> PLAY_AGAIN = () => State.Create<PlayAgainGameState>();

        [Fact]
        public void Start_ChangeStates() {
            var state = OVER();

            StateTests<IGameState>
                .For(state)
                .When(() => state.CheckForWin(() => new MockFunc<bool>().Run())).TransitionTo(OVER).And()
                .When(() => state.End()).TransitionTo(OVER).And()
                .When(() => state.Over()).TransitionTo(PLAY_AGAIN).And()
                .When(() => state.Play(() => new MockAction().Run())).TransitionTo(OVER).And()
                .When(() => state.PlayAgain(() => new MockFunc<bool>().Run())).TransitionTo(OVER).And()
                .When(() => state.Start()).TransitionTo(OVER).And()
                .When(() => state.SwitchPlayer(() => new MockAction().Run())).TransitionTo(OVER)
                .Assert();
        }

        [Fact]
        public void CheckForWin_VerifyFunctionNotCalled()
        {
            var predicate = new MockFunc<bool>();
            var state = OVER();

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
            var state = OVER();

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
            var state = OVER();

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
            var state = OVER();

            StateTests<IGameState>
                .For(state)
                .When(() => state.SwitchPlayer(() => action.Run()))
                .Invoke();

            action.VerifyActionNotCalled();
        }
    }
}
