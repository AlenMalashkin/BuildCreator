using System.Collections.Generic;
using Code.Data;

namespace Code.Services.SaveLoadService
{
    public interface ISaveLoadService : IService
    {
        List<IProgressReader> ProgressReaders { get; set; }
        void Save();
        Progress Load();
    }
}