using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    private bool muted = false;
    [SerializeField] Button voiceMuteButton;

    private Texture Muted;
    private Texture Unmuted;

    private RawImage image;
    
    void Awake()
    {
        image = voiceMuteButton.GetComponent<RawImage>();
        voiceMuteButton.onClick.AddListener(ToggleMute);
        Unmuted = image.texture;
        Muted = Resources.Load<Texture>("UI/sound 1");
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("themeVolume")) {
            PlayerPrefs.SetFloat("themeVolume", 0.5f);
            PlayerPrefs.SetInt("isMuted", 0);
        }
        else {
            load();
        }
    }

    public void ToggleMute() {
        
        if(muted) {
            muted = false;
            AudioListener.pause = false;
            image.texture = Unmuted;
        }
        else {
            muted = true;
            AudioListener.pause = true;
            image.texture = Muted;
        }
    }

    public void changeVolume() {
        AudioListener.volume = volumeSlider.value;
        save();
    }

    private void load() {
        volumeSlider.value = PlayerPrefs.GetFloat("themeVolume");
        muted = PlayerPrefs.GetInt("isMuted") == 1;
    }

    private void save() {
        PlayerPrefs.SetFloat("themeVolume", volumeSlider.value);
        PlayerPrefs.SetInt("isMuted", muted ? 1 : 0);
    }
}
