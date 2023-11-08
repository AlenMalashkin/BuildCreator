using System.Collections.Generic;
using Code.Data;
using UnityEngine;

namespace Code.StaticData.Items
{
    [CreateAssetMenu(fileName = "ItemsStaticData", menuName = "Items", order = 2)]
    public class ItemsStaticData : ScriptableObject
    {
        [SerializeField] private List<ItemData> boots;
        [SerializeField] private List<ItemData> supItems;
        [SerializeField] private List<ItemData> coreItems;
        [SerializeField] private List<ItemData> universalItems;

        public List<ItemData> Boots => boots;
        public List<ItemData> SupItems => supItems;
        public List<ItemData> CoreItems => coreItems;
        public List<ItemData> UniversalItems => universalItems;
    }
}