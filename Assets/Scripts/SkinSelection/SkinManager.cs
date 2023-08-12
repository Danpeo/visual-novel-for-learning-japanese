using System;
using UnityEngine;
using UnityEngine.UI;

namespace SkinSelection
{
    public class SkinManager : MonoBehaviour
    {
        [SerializeField] private SkinData _skinData;
        [SerializeField] private Text _skinName;
        [SerializeField] private Image _skin;
        [SerializeField] private Animator _skinAnimator;
        private int _selectedOption = 0;

        private static readonly int ChangeSkin = Animator.StringToHash("changeSkin");

        private void Start()
        {
            SetCurrentSkin();
            DontDestroyOnLoad(gameObject);
        }

        public void OnNextSkin()
        {
            _selectedOption++;

            if (_selectedOption >= _skinData.SkinCount)
                _selectedOption = 0;
            
            UpdateSkin(_selectedOption);
        }

        public void OnPrevSkin()
        {
            _selectedOption--;

            if (_selectedOption < 0)
                _selectedOption = _skinData.SkinCount - 1;
            
            UpdateSkin(_selectedOption);
        }

        private void UpdateSkin(int selectedOption)
        {
            var skin = _skinData.GetSkin(selectedOption);
            _skin.sprite = skin.SkinImage.sprite;
            _skinName.text = skin.SkinName;
            _skinAnimator.SetTrigger(ChangeSkin);
        }

        private void Load()
        {
            _selectedOption = PlayerPrefs.GetInt("SelectedSkin", 0);
        }

        public void Save()
        {
            _skinData.CurrentSkinImage = _skin.sprite;
            PlayerPrefs.SetInt("SelectedSkin", _selectedOption);
            PlayerPrefs.Save();
        }

        public void SetCurrentSkin()
        {
            Load();
            UpdateSkin(_selectedOption);
        }
    }
}
