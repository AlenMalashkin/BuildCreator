using System.Collections.Generic;
using Code.Data;
using Code.UI.Heroes;
using UnityEngine;

namespace Code.StaticData.Heroes
{
    [CreateAssetMenu(fileName = "HeroesStaticData", menuName = "Heroes", order = 1)]
    public class HeroesStaticData : ScriptableObject
    {
        [SerializeField] private HeroCard heroCardPrefab;
        [SerializeField] private List<HeroData> heroData;
        public HeroCard HeroCardPrefab => heroCardPrefab;
        public List<HeroData> HeroData => heroData;
    }
}