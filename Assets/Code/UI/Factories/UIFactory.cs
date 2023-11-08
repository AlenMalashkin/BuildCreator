using Code.Data;
using Code.Services.StaticDataService;
using Code.StaticData.Heroes;
using Code.StaticData.Windows;
using Code.UI.Heroes;
using Code.UI.Items;
using Code.UI.Windows;
using UnityEngine;

namespace Code.UI.Factories
{
    public class UIFactory : IUIFactory
    {
        private IStaticDataService _staticDataService;

        public UIFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public GameObject CreateMenuWindow(WindowType type)
        {
            WindowStaticData menuWindow = _staticDataService.ForWindow(type);

            return Object.Instantiate(menuWindow.Template).gameObject;
        }

        public GameObject CreateChooseHeroWindow(WindowType type)
        {
            WindowStaticData chooseHeroWindow = _staticDataService.ForWindow(type);

            return Object.Instantiate(chooseHeroWindow.Template).gameObject;
        }

        public GameObject CreateItemBuildWindow(WindowType type)
        {
            WindowStaticData itemBuildWindow = _staticDataService.ForWindow(type);

            return Object.Instantiate(itemBuildWindow.Template).gameObject;
        }

        public HeroCard CreateHeroCard(Transform parent)
        {
            HeroesStaticData heroesStaticData = _staticDataService.ForHeroes();

            return Object.Instantiate(heroesStaticData.HeroCardPrefab, parent);
        }

        public Item CreateItem(Item prefab, ItemData itemData, Transform parent)
        {
            Item item = Object.Instantiate(prefab, parent);
            item.Init(itemData );
            return item;
        }
    }
}