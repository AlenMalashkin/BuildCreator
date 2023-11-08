using Code.StaticData.Heroes;
using Code.StaticData.Items;
using Code.StaticData.RoleItemBuildSettings;
using Code.StaticData.Windows;
using Code.UI.Roles;
using Code.UI.Windows;

namespace Code.Services.StaticDataService
{
    public interface IStaticDataService : IService
    {
        void Load();
        WindowStaticData ForWindow(WindowType type);
        HeroesStaticData ForHeroes();
        ItemsStaticData ForItems();
        RoleItemBuildSettings ForRoleItemBuildSettings(RoleType type);
    }
}