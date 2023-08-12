using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SkinSelection
{
    [CreateAssetMenu(menuName = "Defs/SkinData", fileName = "SkinData")]
    [Serializable]
    public class SkinData : ScriptableObject
    {
        [SerializeField] private List<Skin> _skins;
        [SerializeField] public Sprite CurrentSkinImage;
        public int SkinCount => _skins.Count;

        public Skin GetSkin(int index) => _skins[index];
        
        [Serializable]
        public struct Skin
        {
            public string SkinName;
            [SerializeField] private Image _skinImage;
            public Image SkinImage => _skinImage;
        }
        
    }
}
