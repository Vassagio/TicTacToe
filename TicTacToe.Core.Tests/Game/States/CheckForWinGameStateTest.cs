using System;
using Project.Mocks;
using Test.Utilities.StateHelper;
using TicTacToe.Core.Game.States;
using Xunit;

namespace TicTacToe.Core.Tests.Game.States
{
    public class CheckForWinGameStateTest
    {        
        private static readonly Func<CheckForWinGameState> CHECK_FOR_WIN = () => State.Create<CheckForWinGameState>();
        private static readonly Func<OverGameState> OVER = () => State.Create<OverGameState>();
        private static readonly Func<SwitchPlayerGameState> SWITCH_PLAYER = () => State.Create<SwitchPlayerGameState>();

        [Fact]
        public void Start_ChangeStates()
        {
            var predicateTrue = new MockFunc<bool>().RunReturns(true);
            var predicateFalse = new MockFunc<bool>().RunReturns(false);
            var state = CHECK_FOR_WIN();

            StateTests<IGameState>
                .For(state)
                .When(() => state.CheckForWin(() => predicateTrue.Run())).TransitionTo(OVER).And()
                .When(() => state.CheckForWin(() => predicateFalse.Run())).TransitionTo(SWITCH_PLAYER).And()
                .When(() => state.End()).TransitionTo(CHECK_FOR_WIN).And()
                .When(() => state.Over()).TransitionTo(CHECK_FOR_WIN).And()
                .When(() => state.Play(() => new MockAction().Run())).TransitionTo(CHECK_FOR_WIN).And()
                .When(() => state.PlayAgain(() => new MockFunc<bool>().Run())).TransitionTo(CHECK_FOR_WIN).And()
                .When(() => state.Start()).TransitionTo(CHECK_FOR_WIN).And()
                .When(() => state.SwitchPlayer(() => new MockAction().Run())).TransitionTo(CHECK_FOR_WIN)
                .Assert();
        }

        [Fact]
        public void CheckForWin_VerifyFunctionCalled()
        {
            var predicate = new MockFunc<bool>();
            var state = CHECK_FOR_WIN();

            StateTests<IGameState>
                .For(state)
                .When(() => state.CheckForWin(() => predicate.Run()))
                .Invoke();

            predicate.VerifyFunctionCalled();
        }

        [Fact]
        public void Play_VerifyActionNotCalled()
        {
            var action = new MockAction();
            var state = CHECK_FOR_WIN();

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
            var state = CHECK_FOR_WIN();

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
            var state = CHECK_FOR_WIN();

            StateTests<IGameState>
                .For(state)
                .When(() => state.SwitchPlayer(() => action.Run()))
                .Invoke();

            action.VerifyActionNotCalled();
        }
    }
}
