using System;
using Code.Services;
using Code.Services.BuildHolderService;
using Code.UI.Services.WindowService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows.ItemBuildWindow
{
    public class ItemBuildWindow : WindowBase
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Image heroIcon;
        [SerializeField] private TextMeshProUGUI heroName;

        private IWindowService _windowService;
        private IBuildHolderService _buildHolderService;
        
        private void Awake()
        {
            _windowService = ServiceLocator.Container.Resolve<IWindowService>();
            _buildHolderService = ServiceLocator.Container.Resolve<IBuildHolderService>();
        }

        private void OnEnable()
        {
            closeButton.onClick.AddListener(CloseItemBuildWindow);
        }

        private void OnDisable()
        {
            closeButton.onClick.RemoveListener(CloseItemBuildWindow);
        }

        private void Start()
        {
            ShowCurrentHero();
        }

        private void CloseItemBuildWindow()
        {
            _windowService.CloseWindow(WindowType.ItemBuildWindow);
            _windowService.Open(WindowType.Menu);
            _buildHolderService.Clear();
        }

        private void ShowCurrentHero()
        {
            heroName.text = _buildHolderService.CurrentHero.HeroName;
            heroIcon.sprite = _buildHolderService.CurrentHero.HeroIcon;
        }
    }
}