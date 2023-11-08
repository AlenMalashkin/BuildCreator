using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
    public class SceneLoader
    {
        private ICoroutineRunner _coroutineRunner;
        
        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action onLoad = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoad));
        }
        
        private IEnumerator LoadScene(string sceneName, Action onLoad)
        {
            AsyncOperation loadingScene = SceneManager.LoadSceneAsync(sceneName);

            while (!loadingScene.isDone)
                yield return null;
            
            onLoad?.Invoke();
        }
    }
}