using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    public GameObject teaPot1StarLock;
    public GameObject teaPot2StarLock;
    public GameObject elephant2StarLock;
    public GameObject logo3StarLock;
    public GameObject globe3StarLock;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ResetLocks()
    {
        teaPot1StarLock.GetComponent<RawImage>().raycastTarget = true;
        teaPot1StarLock.GetComponent<CanvasGroup>().alpha = 1;
        teaPot2StarLock.GetComponent<RawImage>().raycastTarget = true;
        teaPot2StarLock.GetComponent<CanvasGroup>().alpha = 1;
        elephant2StarLock.GetComponent<RawImage>().raycastTarget = true;
        elephant2StarLock.GetComponent<CanvasGroup>().alpha = 1;
        logo3StarLock.GetComponent<RawImage>().raycastTarget = true;
        logo3StarLock.GetComponent<CanvasGroup>().alpha = 1;
        globe3StarLock.GetComponent<RawImage>().raycastTarget = true;
        globe3StarLock.GetComponent<CanvasGroup>().alpha = 1;
    }
}
