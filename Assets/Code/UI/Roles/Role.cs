using Code.Data;
using Code.Services;
using Code.Services.BuildGeneratorService;
using Code.Services.BuildHolderService;
using Code.UI.Services.WindowService;
using Code.UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Roles
{
    public class Role : MonoBehaviour
    {
        [SerializeField] private RoleType type;
        [SerializeField] private Button chooseRoleButton;

        private IBuildGeneratorService _buildGeneratorService;
        private IBuildHolderService _buildHolderService;
        private IWindowService _windowService;
        
        private void Awake()
        {
            _buildGeneratorService = ServiceLocator.Container.Resolve<IBuildGeneratorService>();
            _buildHolderService = ServiceLocator.Container.Resolve<IBuildHolderService>();
            _windowService = ServiceLocator.Container.Resolve<IWindowService>();
        }

        private void OnEnable()
        {
            chooseRoleButton.onClick.AddListener(ChooseHeroRole);
        }

        private void OnDisable()
        {
            chooseRoleButton.onClick.RemoveListener(ChooseHeroRole);
        }

        private void ChooseHeroRole()
        {
              ItemData[] itemBuild = _buildGeneratorService.GenerateBuild(type);
              _buildHolderService.SetCurrentBuild(itemBuild);
              _windowService.Open(WindowType.ItemBuildWindow);
              _windowService.CloseWindow(WindowType.ChooseHeroRole);
        }
    }
}