using Code.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Items
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Image itemIcon;

        private ItemData _itemData;
        
        public void Init(ItemData itemData)
        {
            _itemData = itemData;
        }

        private void Start()
        {
            itemIcon.sprite = _itemData.ItemIcon;
        }
    }
}