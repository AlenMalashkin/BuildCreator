using System.Collections.Generic;
using Code.Data;
using Code.Persistent;
using UnityEngine;

namespace Code.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private IPersistentProgress _persistentProgress;
        public List<IProgressReader> ProgressReaders { get; set; }

        public SaveLoadService(IPersistentProgress persistentProgress)
        {
            _persistentProgress = persistentProgress;
        }

        public void Save()
        {
            PlayerPrefs.SetString("Progress", JsonUtility.ToJson(_persistentProgress.Progress));

            foreach (var progressReader in ProgressReaders)
            {
                progressReader.ReadProgress();
            }
        }

        public Progress Load()
            => JsonUtility.FromJson<Progress>(PlayerPrefs.GetString("Progress"));
    }
}