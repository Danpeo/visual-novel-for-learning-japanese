using System.Runtime.InteropServices;
using UnityEngine;

public class Ads : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAds();
    
    [DllImport("__Internal")]
    private static extern void ShowCoreGamePixelVersion();
    
    [DllImport("__Internal")]
    private static extern void ShowSkinShop();
    
    [DllImport("__Internal")]
    private static extern void SetSkinGirl();
    
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private bool _pauseSfxAtStart = false;
    
    private void Start()
    {
        ShowAdvertisement();
        
        if (_sfxSource != null && _pauseSfxAtStart)
            _sfxSource.mute = true;  
    }

    
    public void ShowAdvertisement()
    {
        PauseGameAndAudio();
        ShowAds();

    }

    public void PauseGameAndAudio()
    {
        Time.timeScale = 0.0f;

        if (_sfxSource != null)
            _sfxSource.mute = true;    
    }
    
    public void ShowCoreGamePixelVersionAds()
    {
        ShowCoreGamePixelVersion();
    }

    public void ShowSkinShopAds()
    {

        ShowSkinShop();

    }

    public void SetSkinAds()
    {

        SetSkinGirl();

    }

    public void OnCloseAdvertisemnt()
    {
        Time.timeScale = 1.0f;
        if (_sfxSource != null)
            _sfxSource.mute = false;
    }

}
