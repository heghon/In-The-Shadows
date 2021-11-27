using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightHandler : MonoBehaviour
{
    private PlaceManager PlaceManager;
    private float BaseIntensity;
    public string lightPlace;

    private void Start()
    {
        PlaceManager = FindObjectOfType<PlaceManager>();
        BaseIntensity = gameObject.GetComponent<Light>().intensity;
    }

    private void Update()
    {
        if (PlaceManager.ActualPlace == lightPlace)
        {
            gameObject.GetComponent<Light>().intensity = gameObject.GetComponent<Light>().intensity >= BaseIntensity ? BaseIntensity : (gameObject.GetComponent<Light>().intensity + 0.01f);
        }
        else
            gameObject.GetComponent<Light>().intensity = gameObject.GetComponent<Light>().intensity <= 0 ? 0 : (gameObject.GetComponent<Light>().intensity - 0.005f);
    }
}
