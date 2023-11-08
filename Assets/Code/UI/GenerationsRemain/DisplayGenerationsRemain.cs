using System;
using System.Collections.Generic;
using Code.Persistent;
using Code.Services;
using Code.Services.SaveLoadService;
using TMPro;
using UnityEngine;

namespace Code.UI.GenerationsRemain
{
    public class DisplayGenerationsRemain : MonoBehaviour, IProgressReader
    {
        [SerializeField] private TextMeshProUGUI displayText;

        private IPersistentProgress _persistentProgress;
        private ISaveLoadService _saveLoadService;
        
        private void Awake()
        {
            _persistentProgress = ServiceLocator.Container.Resolve<IPersistentProgress>();
            _saveLoadService = ServiceLocator.Container.Resolve<ISaveLoadService>();
        }

        private void OnEnable()
        {
            _saveLoadService.ProgressReaders.Add(this);
        }

        private void Start()
        {
            DisplayRemainGenerations();
        }

        private void OnDisable()
        {
            _saveLoadService.ProgressReaders.Remove(this);
        }

        public void ReadProgress()
        {
            DisplayRemainGenerations();
        }

        private void DisplayRemainGenerations()
        {
            displayText.text = "Генераций осталось: " + _persistentProgress.Progress.GenerationsRemain;
        }
    }
}