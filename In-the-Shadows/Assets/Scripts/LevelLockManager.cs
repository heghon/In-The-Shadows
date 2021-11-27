using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLockManager : MonoBehaviour
{
    public GameObject teaPot1StarLock;
    public GameObject teaPot2StarLock;
    public GameObject elephant2StarLock;
    public GameObject logo3StarLock;
    public GameObject globe3StarLock;

    public ElephantOneStarHandler elephantOneStarHandler;
    public ElephantTwoStarHandler elephantTwoStarHandler;
    public TeaPotOneStarHandler teaPotOneStarHandler;
    public TeaPotTwoStarHandler teaPotTwoStarHandler;
    public Logo2Handler logoHandler;
    public GlobeEarthHandler globeHandler;

    [HideInInspector]
    public SaveManager saveManager;

    public bool normalPlayMode;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = FindObjectOfType<SaveManager>();

        normalPlayMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (normalPlayMode)
        {
            if (elephantOneStarHandler.victoryBool)
                saveManager.boolTabToSave[0] = true;
            if (elephantTwoStarHandler.victoryBool)
                saveManager.boolTabToSave[1] = true;
            if (teaPotOneStarHandler.victoryBool)
                saveManager.boolTabToSave[2] = true;
            if (teaPotTwoStarHandler.victoryBool)
                saveManager.boolTabToSave[3] = true;
            if (logoHandler.victoryBool)
                saveManager.boolTabToSave[4] = true;
            if (globeHandler.victoryBool)
                saveManager.boolTabToSave[5] = true;
        }


        if (saveManager.boolTabToSave[0])
        {
            elephant2StarLock.GetComponent<RawImage>().raycastTarget = false;
            elephant2StarLock.GetComponent<CanvasGroup>().alpha = 0;

        }
        if (saveManager.boolTabToSave[1])
        {
            teaPot1StarLock.GetComponent<RawImage>().raycastTarget = false;
            teaPot1StarLock.GetComponent<CanvasGroup>().alpha = 0;
        }
        if (saveManager.boolTabToSave[2])
        {
            teaPot2StarLock.GetComponent<RawImage>().raycastTarget = false;
            teaPot2StarLock.GetComponent<CanvasGroup>().alpha = 0;
        }
        if (saveManager.boolTabToSave[2] && saveManager.boolTabToSave[3])
        {
            logo3StarLock.GetComponent<RawImage>().raycastTarget = false;
            logo3StarLock.GetComponent<CanvasGroup>().alpha = 0;
        }
        if (saveManager.boolTabToSave[4])
        {
            globe3StarLock.GetComponent<RawImage>().raycastTarget = false;
            globe3StarLock.GetComponent<CanvasGroup>().alpha = 0;
        }
    }

    public void ChangePlayMode(bool state)
    {
        normalPlayMode = state;
    }
}
