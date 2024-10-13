using System;
using System.Collections.Generic;
using Source.Config;

namespace Source.Infrastructure {
    public class GameStateMachine {
        private readonly Dictionary<Type, IExitableState> _states;
        
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, ICoroutineRunner coroutineRunner, GameConfig gameConfig) {
            _states = new Dictionary<Type, IExitableState> {
                [typeof(BootstrapState)] = new BootstrapState(this),
                [typeof(LoadMenuState)] = new LoadMenuState(this, sceneLoader),
                [typeof(MenuLoopState)] = new MenuLoopState(this),
                [typeof(LoadGameState)] = new LoadGameState(this, sceneLoader),
                [typeof(GameLoopState)] = new GameLoopState(this, coroutineRunner, gameConfig),
            };
        }
        
        public void Enter<TState>() where TState : class, IState {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload> {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState {
            return _states[typeof(TState)] as TState;
        }
    }
}
