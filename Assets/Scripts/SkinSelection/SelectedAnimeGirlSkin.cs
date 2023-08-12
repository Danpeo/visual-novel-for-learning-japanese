using UnityEngine;
using UnityEngine.UI;

namespace SkinSelection
{
    public class SelectedAnimeGirlSkin : MonoBehaviour
    {
        [SerializeField] private SkinData _skinData;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void Start()
        {
            var selectedOption = PlayerPrefs.GetInt("SelectedSkin");
            var skin = _skinData.GetSkin(selectedOption);
            _image.sprite = skin.SkinImage.sprite;
        }
    }
}
