using Code.Data;
using Code.Services;

namespace Code.Persistent
{
    public interface IPersistentProgress : IService
    {
        Progress Progress { get; set; }
    }
}