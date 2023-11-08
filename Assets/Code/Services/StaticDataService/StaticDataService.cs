using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.Constants;
using Code.StaticData.Heroes;
using Code.StaticData.Items;
using Code.StaticData.RoleItemBuildSettings;
using Code.StaticData.Windows;
using Code.UI.Roles;
using Code.UI.Windows;
using UnityEngine;

namespace Code.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<WindowType, WindowStaticData> _windowsMap = new Dictionary<WindowType, WindowStaticData>();
        private Dictionary<RoleType, RoleItemBuildSettings> _itemBuildSettingsMap = new Dictionary<RoleType, RoleItemBuildSettings>();
        private HeroesStaticData _heroesStaticData;
        private ItemsStaticData _itemsStaticData;
        
        public void Load()
        {
            _windowsMap = Resources.LoadAll<WindowStaticData>(StaticDataPaths.WindowPaths)
                .ToDictionary(x => x.Type);

            _heroesStaticData = Resources.Load<HeroesStaticData>(StaticDataPaths.HeroesStaticDataPath);

            _itemsStaticData = Resources.Load<ItemsStaticData>(StaticDataPaths.ItemsStaticDataPath);

            _itemBuildSettingsMap = Resources.LoadAll<RoleItemBuildSettings>(StaticDataPaths.RoleItemBuildSettingsStaticDataPath)
                .ToDictionary(x => x.Type);
        }

        public WindowStaticData ForWindow(WindowType type)
            => _windowsMap[type];

        public HeroesStaticData ForHeroes()
            => _heroesStaticData;

        public ItemsStaticData ForItems()
            => _itemsStaticData;

        public RoleItemBuildSettings ForRoleItemBuildSettings(RoleType type)
            => _itemBuildSettingsMap[type];
    }
}