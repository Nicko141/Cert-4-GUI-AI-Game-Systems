using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    
    public AudioMixer masterAudio;
    public AudioSource audioSource;
    public AudioClip[] clicks;
    public GameObject OptionsPanel;
    public Slider music;
    public Slider SFX;
    public Toggle mute;
    
    #region Audio
    public void PlayClick()
    {
        audioSource.clip = clicks[Random.Range(0, clicks.Length)];

        audioSource.Play();
    }
    public void PlayChosen(int clipIndex)
    {
        audioSource.clip = clicks[clipIndex];
        audioSource.Play();
    }
    //volume changer
    public void ChangeVolume(float volume)
    {
        masterAudio.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }
    public void ChangeSFXVolume(float volume)
    {
        masterAudio.SetFloat("SFXvolume", volume);
        PlayerPrefs.SetFloat("SFXvolume", volume);
        PlayerPrefs.Save();
    }
    // mute toggle
    public void ToggleMute(bool isMuted)
    {
        if (isMuted)
        {
            masterAudio.SetFloat("isMutedVolume", -80);
            //mute.isOn;
            PlayerPrefs.SetInt("isMuted", true ? 1 : 0);
            PlayerPrefs.SetFloat("isMutedVolume", -80);
            PlayerPrefs.Save();
        }
        else
        {
            masterAudio.SetFloat("isMutedVolume", 0);
            PlayerPrefs.SetInt("isMuted", false ? 1 : 0);
            PlayerPrefs.SetFloat("isMutedVolume", 0);
            PlayerPrefs.Save();
        }
    }
    #endregion
    #region Main Menu Functions
    //change scene
    public void ChangeScene(int sceneIndex)
    {
        
        SceneManager.LoadScene(sceneIndex);
    }
    public void NewGame(int sceneIndex)
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("Loaded");
        SceneManager.LoadScene(sceneIndex);

    }
    
    
    //exit to desktop/quit
    public void ExitToDesktop()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    #endregion
    #region Screen Functions
    //quality settings
    public void Quality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    //full screen toggle
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    // resolution dropdown
    public Resolution[] resolutions;
    public Dropdown resolution;
    private void ResolutionSetUp()
    {
        resolutions = Screen.resolutions;
        resolution.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolution.AddOptions(options);
        resolution.value = currentResolutionIndex;
        resolution.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
    #endregion
    private void Start()
    {
        masterAudio.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
        masterAudio.SetFloat("SFXvolume", PlayerPrefs.GetFloat("SFXvolume"));
        masterAudio.SetFloat("isMutedVolume", PlayerPrefs.GetFloat("isMutedVolume"));
        music.value = PlayerPrefs.GetFloat("volume");
        SFX.value = PlayerPrefs.GetFloat("SFXvolume");
        mute.isOn = PlayerPrefs.GetInt("isMuted") == 1 ? true : false;
        
        ResolutionSetUp();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
