using Code.Data;

namespace Code.Services.BuildHolderService
{
    public interface IBuildHolderService : IService
    {
        ItemData[] CurrentItemBuild { get; }
        HeroData CurrentHero { get; }

        void SetCurrentHero(HeroData hero);
        void SetCurrentBuild(ItemData[] itemBuild);
        void Clear();
    }
}