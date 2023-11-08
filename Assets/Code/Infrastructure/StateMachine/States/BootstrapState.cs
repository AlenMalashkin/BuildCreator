using System.Collections.Generic;
using Code.Data;
using Code.Persistent;
using Code.Services;
using Code.Services.BuildGeneratorService;
using Code.Services.BuildHolderService;
using Code.Services.SaveLoadService;
using Code.Services.StaticDataService;
using Code.UI.Factories;
using Code.UI.LoadingCurtain;
using Code.UI.Services.WindowService;

namespace Code.Infrastructure.StateMachine.States
{
    public class BootstrapState : IState
    {
        private IGameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private LoadingCurtain _loadingCurtain;
        private ServiceLocator _serviceLocator;
        
        public BootstrapState(IGameStateMachine gameStateMachine, SceneLoader sceneLoader, 
            LoadingCurtain loadingCurtain, 
            ServiceLocator serviceLocator)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _serviceLocator = serviceLocator;
            
            RegisterServices();
        }
        
        public void Enter()
        {
            _loadingCurtain.Show();
            _sceneLoader.Load("Bootstrap", OnLoad);  
        }

        public void Exit()
        {
        }

        private void OnLoad()
        {
            _gameStateMachine.Enter<GameState, string>("Main"); 
        }

        private void RegisterServices()
        {
            _serviceLocator.RegisterService(_gameStateMachine);
            RegisterStaticDataService();
            _serviceLocator.RegisterService<IUIFactory>(new UIFactory(_serviceLocator.Resolve<IStaticDataService>()));
            _serviceLocator.RegisterService<IWindowService>(new WindowService(_serviceLocator.Resolve<IUIFactory>()));
            _serviceLocator.RegisterService<IPersistentProgress>(new PersistentProgress());
            RegisterSaveLoadService();
            _serviceLocator.RegisterService<IBuildHolderService>(new BuildHolderService());
            _serviceLocator.RegisterService<IBuildGeneratorService>(new BuildGeneratorService(_serviceLocator.Resolve<IStaticDataService>(), _serviceLocator.Resolve<ISaveLoadService>(), _serviceLocator.Resolve<IPersistentProgress>()));
        }

        private void RegisterStaticDataService()
        {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.Load();
            _serviceLocator.RegisterService(staticDataService);
        }

        private void RegisterSaveLoadService()
        {
            IPersistentProgress persistentProgress = _serviceLocator.Resolve<IPersistentProgress>();
            ISaveLoadService saveLoadService = new SaveLoadService(persistentProgress);
            saveLoadService.ProgressReaders = new List<IProgressReader>();
            persistentProgress.Progress = saveLoadService.Load() ?? new Progress();
            _serviceLocator.RegisterService(saveLoadService);
        }
    }
}