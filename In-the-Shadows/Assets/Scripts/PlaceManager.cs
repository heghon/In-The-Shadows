using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{

    public string ActualPlace;

    // Start is called before the first frame update
    void Start()
    {
        ActualPlace = "GameMenu";
    }

    public void ChangePlace(string NewPlace)
    {
        ActualPlace = NewPlace;
    }
}
