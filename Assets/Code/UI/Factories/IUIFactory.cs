using Code.Data;
using Code.Services;
using Code.UI.Heroes;
using Code.UI.Items;
using Code.UI.Windows;
using UnityEngine;

namespace Code.UI.Factories
{
    public interface IUIFactory : IService
    {
        GameObject CreateMenuWindow(WindowType type);
        GameObject CreateChooseHeroWindow(WindowType type);
        GameObject CreateItemBuildWindow(WindowType type);
        HeroCard CreateHeroCard(Transform parent);
        Item CreateItem(Item prefab, ItemData itemData, Transform parent);
    }
}