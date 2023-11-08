using Code.Data;

namespace Code.Services.BuildHolderService
{
    public class BuildHolderService : IBuildHolderService
    {
        public ItemData[] CurrentItemBuild => _currentItemBuild;
        public HeroData CurrentHero => _currentHero;

        private ItemData[] _currentItemBuild;
        private HeroData _currentHero;

        public void SetCurrentHero(HeroData hero)
            => _currentHero = hero;

        public void SetCurrentBuild(ItemData[] itemBuild)
            => _currentItemBuild = itemBuild;
        
        public void Clear()
        {
            _currentItemBuild = null;
            _currentHero = null;
        }
    }
}