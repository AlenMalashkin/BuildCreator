using Code.UI.LoadingCurtain;
using UnityEngine;

namespace Code.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LoadingCurtain loadingCurtain;
        
        private Game _game;
        
        private void Awake()
        {
            _game = new Game(this, Instantiate(loadingCurtain));
            _game.StartGame();
            
            DontDestroyOnLoad(this);
        }
    }
}