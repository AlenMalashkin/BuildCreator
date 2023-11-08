using System;
using Code.UI.Heroes;
using UnityEngine;

namespace Code.Data
{
    [Serializable]
    public class HeroData
    {
        public HeroType Type;
        public Sprite HeroIcon;
        public string HeroName;
    }
}