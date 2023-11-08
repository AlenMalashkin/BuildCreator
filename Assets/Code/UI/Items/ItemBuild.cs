using Code.Services;
using Code.Services.BuildHolderService;
using Code.UI.Factories;
using UnityEngine;

namespace Code.UI.Items
{
    public class ItemBuild : MonoBehaviour
    {
        [SerializeField] private Item itemPrefab;

        private IBuildHolderService _buildHolderService;
        private IUIFactory _uiFactory;
        
        private void Awake()
        {
            _buildHolderService = ServiceLocator.Container.Resolve<IBuildHolderService>();
            _uiFactory = ServiceLocator.Container.Resolve<IUIFactory>();
        }

        private void Start()
        {
            foreach (var itemData in _buildHolderService.CurrentItemBuild)
            {
                _uiFactory.CreateItem(itemPrefab, itemData, transform);
            }
        }
    }
}