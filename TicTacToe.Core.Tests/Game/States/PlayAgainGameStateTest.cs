using System;
using Project.Mocks;
using Test.Utilities.StateHelper;
using TicTacToe.Core.Game.States;
using Xunit;

namespace TicTacToe.Core.Tests.Game.States
{
    public class PlayAgainGameStateTest
    {
        private static readonly Func<PlayAgainGameState> PLAY_AGAIN = () => State.Create<PlayAgainGameState>();
        private static readonly Func<StartGameState> START = () => State.Create<StartGameState>();
        private static readonly Func<EndGameState> END = () => State.Create<EndGameState>();

        [Fact]
        public void Start_ChangeStates()
        {
            var predicateTrue = new MockFunc<bool>().RunReturns(true);
            var predicateFalse = new MockFunc<bool>().RunReturns(false);
            var state = PLAY_AGAIN();

            StateTests<IGameState>
                .For(state)
                .When(() => state.CheckForWin(() => new MockFunc<bool>().Run())).TransitionTo(PLAY_AGAIN).And()
                .When(() => state.End()).TransitionTo(PLAY_AGAIN).And()
                .When(() => state.Over()).TransitionTo(PLAY_AGAIN).And()
                .When(() => state.Play(() => new MockAction().Run())).TransitionTo(PLAY_AGAIN).And()
                .When(() => state.PlayAgain(() => predicateTrue.Run())).TransitionTo(START).And()
                .When(() => state.PlayAgain(() => predicateFalse.Run())).TransitionTo(END).And()
                .When(() => state.Start()).TransitionTo(PLAY_AGAIN).And()
                .When(() => state.SwitchPlayer(() => new MockAction().Run())).TransitionTo(PLAY_AGAIN)
                .Assert();
        }

        [Fact]
        public void CheckForWin_VerifyFunctionNotCalled()
        {
            var predicate = new MockFunc<bool>();
            var state = PLAY_AGAIN();

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
            var state = PLAY_AGAIN();

            StateTests<IGameState>
                .For(state)
                .When(() => state.Play(() => action.Run()))
                .Invoke();

            action.VerifyActionNotCalled();
        }

        [Fact]
        public void PlayAgain_VerifyFunctionCalled()
        {
            var predicate = new MockFunc<bool>();
            var state = PLAY_AGAIN();

            StateTests<IGameState>
                .For(state)
                .When(() => state.PlayAgain(() => predicate.Run()))
                .Invoke();

            predicate.VerifyFunctionCalled();
        }

        [Fact]
        public void PlayAgain_VerifyFunctionReturnsFalse_StateChangesEnd()
        {
            var predicate = new MockFunc<bool>().RunReturns(true);
            var state = PLAY_AGAIN();

            StateTests<IGameState>
                .For(state)
                .When(() => state.PlayAgain(() => predicate.Run()))
                .Invoke();

            predicate.VerifyFunctionCalled();
        }

        [Fact]
        public void SwitchPlayer_VerifyActionNotCalled()
        {
            var action = new MockAction();
            var state = PLAY_AGAIN();

            StateTests<IGameState>
                .For(state)
                .When(() => state.SwitchPlayer(() => action.Run()))
                .Invoke();

            action.VerifyActionNotCalled();
        }
    }
}
