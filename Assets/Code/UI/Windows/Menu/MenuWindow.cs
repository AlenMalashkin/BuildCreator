using System;
using Code.Services;
using Code.Services.StaticDataService;
using Code.StaticData.Heroes;
using Code.UI.Factories;
using UnityEngine;

namespace Code.UI.Windows.Menu
{
    public class MenuWindow : WindowBase
    {
        [SerializeField] private Transform cardParent;
        
        private IUIFactory _uiFactory;
        private IStaticDataService _staticDataService;
        
        private void Awake()
        {
            _uiFactory = ServiceLocator.Container.Resolve<IUIFactory>();
            _staticDataService = ServiceLocator.Container.Resolve<IStaticDataService>();
        }

        private void Start()
        {
            HeroesStaticData heroesStaticData = _staticDataService.ForHeroes();
            
            foreach (var heroData in heroesStaticData.HeroData)
            {
                _uiFactory.CreateHeroCard(cardParent)
                    .Init(heroData);
            }
        }
    }
}