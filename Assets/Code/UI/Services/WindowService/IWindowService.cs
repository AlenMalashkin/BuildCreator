using Code.Services;
using Code.UI.Windows;
using UnityEngine;

namespace Code.UI.Services.WindowService
{
    public interface IWindowService : IService
    {
        GameObject Open(WindowType type);
        void CloseWindow(WindowType type);
    }
}