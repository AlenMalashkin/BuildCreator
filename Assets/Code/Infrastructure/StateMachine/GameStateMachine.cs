using System;
using System.Collections.Generic;
using Code.Infrastructure.StateMachine.States;
using Code.Services;
using Code.Services.StaticDataService;
using Code.UI.Factories;
using Code.UI.LoadingCurtain;
using Code.UI.Services.WindowService;

namespace Code.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitableState> _statesMap;
        
        private IExitableState _currentState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain loadingCurtain, ServiceLocator serviceLocator)
        {
            _statesMap = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, loadingCurtain, serviceLocator),
                [typeof(GameState)] = new GameState(sceneLoader, 
                    loadingCurtain,
                    serviceLocator.Resolve<IWindowService>()),
            };
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TPayloadState, TPayload>(TPayload payload) where TPayloadState : class, IPayloadState<TPayload>
        {
            IPayloadState<TPayload> state = ChangeState<TPayloadState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
            => _statesMap[typeof(TState)] as TState;
    }
}