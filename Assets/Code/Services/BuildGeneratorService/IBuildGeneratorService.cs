using Code.Data;
using Code.UI.Roles;

namespace Code.Services.BuildGeneratorService
{
    public interface IBuildGeneratorService : IService
    {
        ItemData[] GenerateBuild(RoleType type);
    }
}