using System;
using Project.Mocks;
using Test.Utilities.StateHelper;
using TicTacToe.Core.Game.States;
using Xunit;

namespace TicTacToe.Core.Tests.Game.States
{
    public class SwitchPlayerGameStateTest
    {
        private static readonly Func<SwitchPlayerGameState> SWITCH_PLAYER = () => State.Create<SwitchPlayerGameState>();
        private static readonly Func<PlayGameState> PLAY = () => State.Create<PlayGameState>();

        [Fact]
        public void Start_ChangeStates()
        {
            var state = SWITCH_PLAYER();

            StateTests<IGameState>
                .For(state)
                .When(() => state.CheckForWin(() => new MockFunc<bool>().Run())).TransitionTo(SWITCH_PLAYER).And()
                .When(() => state.End()).TransitionTo(SWITCH_PLAYER).And()
                .When(() => state.Over()).TransitionTo(SWITCH_PLAYER).And()
                .When(() => state.Play(() => new MockAction().Run())).TransitionTo(SWITCH_PLAYER).And()
                .When(() => state.PlayAgain(() => new MockFunc<bool>().Run())).TransitionTo(SWITCH_PLAYER).And()
                .When(() => state.Start()).TransitionTo(SWITCH_PLAYER).And()
                .When(() => state.SwitchPlayer(() => new MockAction().Run())).TransitionTo(PLAY)
                .Assert();
        }

        [Fact]
        public void CheckForWin_VerifyFunctionNotCalled()
        {
            var predicate = new MockFunc<bool>();
            var state = SWITCH_PLAYER();

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
            var state = SWITCH_PLAYER();

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
            var state = SWITCH_PLAYER();

            StateTests<IGameState>
                .For(state)
                .When(() => state.PlayAgain(() => predicate.Run()))
                .Invoke();

            predicate.VerifyFunctionNotCalled();
        }

        [Fact]
        public void SwitchPlayer_VerifyActionCalled()
        {
            var action = new MockAction();
            var state = SWITCH_PLAYER();

            StateTests<IGameState>
                .For(state)
                .When(() => state.SwitchPlayer(() => action.Run()))
                .Invoke();

            action.VerifyActionCalled();
        }
    }
}
