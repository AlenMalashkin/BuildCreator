using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Code.Services;
using Code.UI.LoadingCurtain;

namespace Code.Infrastructure
{
    public class Game
    {
        private IGameStateMachine _gameStateMachine;
        
        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            _gameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), 
                loadingCurtain, 
                ServiceLocator.Container);
        }

        public void StartGame()
        {
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}