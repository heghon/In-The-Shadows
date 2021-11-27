using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryHandler : MonoBehaviour
{
    public ElephantOneStarHandler elephantOneStarHandler;
    public ElephantTwoStarHandler elephantTwoStarHandler;
    public TeaPotOneStarHandler teaPotOneStarHandler;
    public TeaPotTwoStarHandler teaPotTwoStarHandler;
    public Logo2Handler logoHandler;
    public GlobeEarthHandler globeHandler;

    [HideInInspector]
    public PlaceManager placeManager;

    [HideInInspector]
    public VictoryHandler victoryHandler;
    public GameObject victoryMenu;
    private Animator victoryMenuAnimator;

    private AudioManager audioManager;

    private FadeManager fadeManager;

    public GameObject savePanel;

    public bool victoryLaunched;

    public GameObject videoPanel;

    public float timeLeft;


    // Start is called before the first frame update
    void Start()
    {
        victoryLaunched = false;
        placeManager = GameObject.FindObjectOfType<PlaceManager>();
        victoryHandler = victoryMenu.GetComponent<VictoryHandler>();
        victoryMenuAnimator = victoryMenu.GetComponent<Animator>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        fadeManager = victoryMenu.GetComponent<FadeManager>();
        timeLeft = 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!victoryLaunched && placeManager.ActualPlace == "PlayPlace" && (elephantOneStarHandler.victoryBool || elephantTwoStarHandler.victoryBool || teaPotOneStarHandler.victoryBool || teaPotTwoStarHandler.victoryBool || logoHandler.victoryBool))
        {
            victoryMenu.SetActive(true);
            fadeManager.ShowUI();
            LaunchAnimation("Victory");
            audioManager.Play("VictoryExplosion");
            audioManager.Stop("GameTheme");
            victoryLaunched = true;
        }
        if (!victoryLaunched && globeHandler.victoryBool)
        {
            victoryMenu.SetActive(true);
            fadeManager.ShowUI();
            LaunchAnimation("Victory");
            audioManager.Stop("GameTheme");
            timeLeft -= timeLeft > 0 ? Time.deltaTime : 0;
            videoPanel.SetActive(timeLeft > 0 ? true : false);
            if (timeLeft < 0)
                victoryLaunched = true;
        }
    }

    public void LaunchAnimation(string AnimationName)
    {
        victoryMenuAnimator.Play(AnimationName);
    }

    public void RelaunchVictory()
    {
        victoryLaunched = false;
        timeLeft = 15.0f;
    }
}
