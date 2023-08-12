using System.Collections;
using Data;
using SkinSelection;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogs
{
    public class DialogBoxController : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private GameObject _container;
        [SerializeField] private Animator _dialogBoxAnimator;
        [SerializeField] private Animator _animeGirlAnimator;
        [SerializeField] private Image _background;
        [SerializeField] private SkinData _skinData;
        [SerializeField] private Image _animeGirl;
        
        [Space] [SerializeField] private float _textSpeed = 0.1f;

        [Header("Sounds")] [SerializeField] private AudioClip _typingSound;
        [SerializeField] private int _typingSoundRate = 6;
        [SerializeField] private AudioClip _openAudio;
        [SerializeField] private AudioClip _closeAudio;
        [SerializeField] private AudioSource _sfxSource;

        [SerializeField] private Ads _ads;
        [SerializeField] private GameObject _restartButton;
        
        private static readonly int IsOpen = Animator.StringToHash("isOpen");
        private static readonly int IsTalking = Animator.StringToHash("isTalking");
        private DialogData _data;
        
        private int _currentSentece;
        private Coroutine _typingRoutine;

        /*private void Awake()
        {
        #if UNITY_EDITOR    
            PlayerPrefs.SetInt("sentence", 0);
        #endif   

        }*/

        public void ShowDialog(DialogData data)
        {
            _data = data;
            _currentSentece = PlayerPrefs.GetInt("sentence");

            if (_skinData != null)
            {
                var selectedOption = PlayerPrefs.GetInt("SelectedSkin");
                var skin = _skinData.GetSkin(selectedOption);
                _animeGirl.sprite = skin.SkinImage.sprite;    
            }
            _text.text = string.Empty;
            _background.sprite = _data.Sentences[_currentSentece].Background.sprite;
            
            _container.SetActive(true);
            _sfxSource.PlayOneShot(_openAudio);
            _dialogBoxAnimator.SetBool(IsOpen, true);

        }
        
        public void OnStartDialogAnimation()
        {
            _typingRoutine = StartCoroutine(TypeDialogText());
        }

        private IEnumerator TypeDialogText()
        {
            _animeGirlAnimator.SetBool(IsTalking, true);

            _text.text = string.Empty;
            var sentence = _data.Sentences[_currentSentece].Text;
            
            var currentSentenceData = _data.Sentences[_currentSentece];
            var currentImage = currentSentenceData.Background;

            if (_currentSentece == 0 ||  currentImage.sprite != _data.Sentences[_currentSentece - 1].Background.sprite)
            {
                _background.sprite = UpdateBGSprite(currentImage.sprite);
            }

            int i = 0;
            foreach (var letter in sentence)
            {
                _text.text += letter;
                if (i % _typingSoundRate == 0)
                    _sfxSource.PlayOneShot(_typingSound);


                yield return new WaitForSeconds(_textSpeed);
                i++;
            }
            
            _animeGirlAnimator.SetBool(IsTalking, false);
            _typingRoutine = null;

        }

        private Sprite UpdateBGSprite(Sprite newSprite)
        {
            _background.sprite = newSprite;

            return _background.sprite;
        }
        
        public void OnSkip()
        {
            if (_typingRoutine == null) return;

            StopTypeAnimation();
            _text.text = _data.Sentences[_currentSentece].Text;
        }

        public void OnContinueDialog()
        {
            if (_typingRoutine != null) return;
            
            UpdateSentence(_currentSentece + 1);
            
        }

        public void OnGoToPreviousSentence()
        {
            if (_typingRoutine != null || _currentSentece == 0) return;
            
            UpdateSentence(_currentSentece - 1);
            
            var currentSentenceData = _data.Sentences[_currentSentece];
            var currentImage = currentSentenceData.Background;
            _background.sprite = UpdateBGSprite(currentImage.sprite);
            
        }

        private void UpdateSentence(int newSenteceIndex)
        {
            StopTypeAnimation();
            
            _currentSentece = newSenteceIndex;
            PlayerPrefs.SetInt("sentence", _currentSentece);
            
            var isDialogCompleted = _currentSentece >= _data.Sentences.Count;
            if (isDialogCompleted)
            {
                PlayerPrefs.SetInt("sentence", 0);
                HideDialogBox();
                
                if (_ads != null)
                    _ads.ShowAdvertisement();
                
                _restartButton.SetActive(true);
            }
            else
            {
                OnStartDialogAnimation();
            }
        }
        
        public void HideDialogBox()
        {
            _sfxSource.PlayOneShot(_closeAudio);
            _dialogBoxAnimator.SetBool(IsOpen, false);
        }

        public void ShowDialogBox()
        {
            _sfxSource.PlayOneShot(_openAudio);
            _dialogBoxAnimator.SetBool(IsOpen, true);
        }
        
        private void StopTypeAnimation()
        {

            if (_typingRoutine != null)
                StopCoroutine(TypeDialogText());
            _typingRoutine = null;
        }

        public void ResetCurrentSentence()
        {
            PlayerPrefs.SetInt("sentence", 0);
        }

    }
}
