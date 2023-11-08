using System;
using System.Collections.Generic;
using Code.UI.Factories;
using Code.UI.Windows;
using UnityEngine;

namespace Code.UI.Services.WindowService
{
    public class WindowService : IWindowService
    {
        private IUIFactory _uiFactory;
        private Dictionary<WindowType, GameObject> _openedWindows = new Dictionary<WindowType, GameObject>();

        public WindowService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        public GameObject Open(WindowType type)
        {
            switch (type)
            {
                case WindowType.Menu:
                    GameObject menuWindow = _uiFactory.CreateMenuWindow(type);
                    _openedWindows.Add(type, menuWindow);
                    return menuWindow;
                case WindowType.ChooseHeroRole:
                    GameObject chooseHeroWindow = _uiFactory.CreateChooseHeroWindow(type);
                    _openedWindows.Add(type, chooseHeroWindow);
                    return chooseHeroWindow;
                case WindowType.ItemBuildWindow:
                    GameObject itemBuildWindow = _uiFactory.CreateItemBuildWindow(type);
                    _openedWindows.Add(type, itemBuildWindow);
                    return itemBuildWindow;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public void CloseWindow(WindowType type)
        {
            GameObject.Destroy(_openedWindows[type]);
            _openedWindows.Remove(type);
        } 
    }
}