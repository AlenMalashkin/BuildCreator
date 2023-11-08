using Code.Services.StaticDataService;
using Code.UI.Factories;
using Code.UI.LoadingCurtain;
using Code.UI.Services.WindowService;
using Code.UI.Windows;

namespace Code.Infrastructure.StateMachine.States
{
    public class GameState : IPayloadState<string>
    {
        private SceneLoader _sceneLoader;
        private LoadingCurtain _loadingCurtain;
        private IWindowService _windowService;

        public GameState(SceneLoader sceneLoader, 
            LoadingCurtain loadingCurtain, 
            IWindowService windowService)
        {
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _windowService = windowService;
        }
        
        public void Enter(string payload)
        {
            _sceneLoader.Load(payload, OnLoad);
        }

        public void Exit()
        {
        }

        private void OnLoad()
        {
            InitGame();
            _loadingCurtain.Hide();
        }

        private void InitGame()
        {
            _windowService.Open(WindowType.Menu);
        }
    }
}