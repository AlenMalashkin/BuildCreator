using System.Collections.Generic;
using Code.Data;
using Code.Persistent;
using Code.Services.SaveLoadService;
using Code.Services.StaticDataService;
using Code.StaticData.Items;
using Code.StaticData.RoleItemBuildSettings;
using Code.UI.Roles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Services.BuildGeneratorService
{
    public class BuildGeneratorService : IBuildGeneratorService
    {
        private IStaticDataService _staticDataService;
        private ISaveLoadService _saveLoadService;
        private IPersistentProgress _persistentProgress;
        
        private RoleItemBuildSettings _roleItemBuildSettings;
        private ItemsStaticData _itemsStaticData;

        public BuildGeneratorService(IStaticDataService staticDataService, ISaveLoadService saveLoadService,
            IPersistentProgress persistentProgress)
        {
            _staticDataService = staticDataService;
            _saveLoadService = saveLoadService;
            _persistentProgress = persistentProgress;
        }

        public ItemData[] GenerateBuild(RoleType type)
        {
            _roleItemBuildSettings = _staticDataService.ForRoleItemBuildSettings(type);
            _itemsStaticData = _staticDataService.ForItems();
            
            List<ItemData> items = new List<ItemData>();
            
            items.Add(GenerateBoot());

            foreach (var item in GenerateItems(_roleItemBuildSettings.CoreItemsCount, _itemsStaticData.CoreItems))
            {
                items.Add(item);
            }
            
            foreach (var item in GenerateItems(_roleItemBuildSettings.SupportItemsCount, _itemsStaticData.SupItems))
            {
                items.Add(item);
            }
            
            foreach (var item in GenerateItems(_roleItemBuildSettings.UniversalItemsCount, _itemsStaticData.UniversalItems))
            {
                items.Add(item);
            }

            Debug.Log(_persistentProgress);
            _persistentProgress.Progress.GenerationsRemain -= 1;
            _saveLoadService.Save();
            
            return items.ToArray();
        }

        private ItemData GenerateBoot()
        {
            List<ItemData> boots = _itemsStaticData.Boots;

            return boots[Random.Range(0, boots.Count)];
        }

        private ItemData[] GenerateItems(int itemsCount, List<ItemData> items)
        {
            List<ItemData> generatedItems = new List<ItemData>();

            while (generatedItems.Count != itemsCount) 
            {
                int randomItemIndex = Random.Range(0, items.Count);
                    
                if (!generatedItems.Contains(items[randomItemIndex]))
                    generatedItems.Add(items[randomItemIndex]);
            }

            return generatedItems.ToArray();
        }
    }
}