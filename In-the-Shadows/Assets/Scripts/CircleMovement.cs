using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    float timeCounter = 0;
    float xOrigin;
    float yOrigin;
    float zOrigin;

    private PlaceManager PlaceManager;

    private void Start()
    {
        PlaceManager = FindObjectOfType<PlaceManager>();

        xOrigin = transform.position.x;
        yOrigin = transform.position.y;
        zOrigin = transform.position.z;

    }

    private void Update()
    {
        if (PlaceManager.ActualPlace == "GameMenu")
        {
            gameObject.GetComponent<Light>().intensity = 2;
            timeCounter += Time.deltaTime;
            float x = Mathf.Cos(timeCounter) * 2 + xOrigin;
            float z = Mathf.Sin(timeCounter) * 2 + zOrigin;
            float y = yOrigin;
            transform.position = new Vector3(x, y, z);
        }
        else
            gameObject.GetComponent<Light>().intensity = gameObject.GetComponent<Light>().intensity <= 0 ? 0 : (gameObject.GetComponent<Light>().intensity - 0.02f);
    }
}
