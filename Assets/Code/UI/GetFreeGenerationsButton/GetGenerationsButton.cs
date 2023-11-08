using Code.Persistent;
using Code.Services;
using Code.Services.SaveLoadService;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Code.UI.GetFreeGenerationsButton
{
    public class GetGenerationsButton : MonoBehaviour
    {
        [SerializeField] private int videoId;
        [SerializeField] private Button getGenerationsButton;

        private IPersistentProgress _persistentProgress;
        private ISaveLoadService _saveLoadService;
        
        private void Awake()
        {
            _persistentProgress = ServiceLocator.Container.Resolve<IPersistentProgress>();
            _saveLoadService = ServiceLocator.Container.Resolve<ISaveLoadService>();
        }

        private void OnEnable()
        {
            getGenerationsButton.onClick.AddListener(GetGenerations);
            YandexGame.CloseVideoEvent += OnCloseVideo;
        }

        private void OnDisable()
        {
            getGenerationsButton.onClick.RemoveListener(GetGenerations);
            YandexGame.CloseVideoEvent -= OnCloseVideo;
        }

        private void GetGenerations()
        {
            YandexGame.RewVideoShow(videoId);
        }

        private void OnCloseVideo()
        {
            _persistentProgress.Progress.GenerationsRemain += 10;
            _saveLoadService.Save();
        }
    }
}