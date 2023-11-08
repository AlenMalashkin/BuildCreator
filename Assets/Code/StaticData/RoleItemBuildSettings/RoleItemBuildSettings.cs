using Code.UI.Roles;
using UnityEngine;

namespace Code.StaticData.RoleItemBuildSettings
{
    [CreateAssetMenu(fileName = "RoleItemBuild", menuName = "Role Item Build Settings", order = 3)]
    public class RoleItemBuildSettings : ScriptableObject
    {
        [SerializeField] private RoleType type;
        [SerializeField] private int coreItemsCount;
        [SerializeField] private int supportItemsCount;
        [SerializeField] private int universalItemsCount;

        public RoleType Type => type;
        public int CoreItemsCount => coreItemsCount;
        public int SupportItemsCount => supportItemsCount;
        public int UniversalItemsCount => universalItemsCount;
    }
}