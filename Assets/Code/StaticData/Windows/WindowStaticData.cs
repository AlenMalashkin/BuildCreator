using Code.UI.Windows;
using UnityEngine;

namespace Code.StaticData.Windows
{
    [CreateAssetMenu(fileName = "Window", menuName = "Windows", order = 0)]
    public class WindowStaticData : ScriptableObject
    {
        [SerializeField] private WindowType type;
        [SerializeField] private WindowBase template;

        public WindowType Type => type;
        public WindowBase Template => template;
    }
}