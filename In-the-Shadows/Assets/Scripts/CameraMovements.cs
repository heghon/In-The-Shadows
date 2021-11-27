using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    private PlaceManager PlaceManager;
    private Animator CameraAnimator;

    // Start is called before the first frame update
    void Start()
    {
        PlaceManager = FindObjectOfType<PlaceManager>();
        CameraAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchAnimation(string AnimationName)
    {
        CameraAnimator.Play(AnimationName);
    }
}
