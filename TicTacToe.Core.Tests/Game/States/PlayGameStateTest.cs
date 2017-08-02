using System;
using Project.Mocks;
using Test.Utilities.StateHelper;
using TicTacToe.Core.Game.States;
using Xunit;

namespace TicTacToe.Core.Tests.Game.States
{
    public class PlayGameStateTest
    {        
        private static readonly Func<PlayGameState> PLAY = () => State.Create<PlayGameState>();
        private static readonly Func<CheckForWinGameState> CHECK_FOR_WIN = () => State.Create<CheckForWinGameState>();

        [Fact]
        public void Start_ChangeStates()
        {
            var state = PLAY();

            StateTests<IGameState>
                .For(state)
                .When(() => state.CheckForWin(() => new MockFunc<bool>().Run())).TransitionTo(PLAY).And()
                .When(() => state.End()).TransitionTo(PLAY).And()
                .When(() => state.Over()).TransitionTo(PLAY).And()
                .When(() => state.Play(() => new MockAction().Run())).TransitionTo(CHECK_FOR_WIN).And()
                .When(() => state.PlayAgain(() => new MockFunc<bool>().Run())).TransitionTo(PLAY).And()
                .When(() => state.Start()).TransitionTo(PLAY).And()
                .When(() => state.SwitchPlayer(() => new MockAction().Run())).TransitionTo(PLAY)
                .Assert();
        }

        [Fact]
        public void CheckForWin_VerifyFunctionNotCalled()
        {
            var predicate = new MockFunc<bool>();
            var state = PLAY();

            StateTests<IGameState>
                .For(state)
                .When(() => state.CheckForWin(() => predicate.Run()))
                .Invoke();

            predicate.VerifyFunctionNotCalled();
        }

        [Fact]
        public void Play_VerifyActionCalled()
        {
            var action = new MockAction();
            var state = PLAY();

            StateTests<IGameState>
                .For(state)
                .When(() => state.Play(() => action.Run()))
                .Invoke();

            action.VerifyActionCalled();
        }

        [Fact]
        public void PlayAgain_VerifyFunctionNotCalled()
        {
            var predicate = new MockFunc<bool>();
            var state = PLAY();

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
            var state = PLAY();

            StateTests<IGameState>
                .For(state)
                .When(() => state.SwitchPlayer(() => action.Run()))
                .Invoke();

            action.VerifyActionNotCalled();
        }
    }
}
