using System;
using Code.Data;
using Code.Services;
using Code.Services.BuildHolderService;
using Code.UI.Services.WindowService;
using Code.UI.Windows;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Heroes
{
    public class HeroCard : MonoBehaviour
    {
        [SerializeField] private Button heroCardButton;
        [SerializeField] private Image heroIcon;
        [SerializeField] private TextMeshProUGUI heroName;

        private IWindowService _windowService;
        private IBuildHolderService _buildHolderService;
        
        private HeroData _heroData;
        
        private void Awake()
        {
            _windowService = ServiceLocator.Container.Resolve<IWindowService>();
            _buildHolderService = ServiceLocator.Container.Resolve<IBuildHolderService>();
        }
        
        private void OnDisable()
        {
            heroCardButton.onClick.RemoveListener(ChooseHero);
        }

        public void Init(HeroData heroData)
        {
            _heroData = heroData;
            
            heroIcon.sprite = heroData.HeroIcon;
            heroName.text = heroData.HeroName;
            
            heroCardButton.onClick.AddListener(ChooseHero);
        }

        private void ChooseHero()
        {
            _buildHolderService.SetCurrentHero(_heroData);
            _windowService.Open(WindowType.ChooseHeroRole);
            _windowService.CloseWindow(WindowType.Menu);
        }
    }
}