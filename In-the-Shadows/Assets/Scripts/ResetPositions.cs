using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositions : MonoBehaviour
{
    public ElephantOneStarHandler elephantOneStarHandler;
    public ElephantTwoStarHandler elephantTwoStarHandler;
    public TeaPotOneStarHandler teaPotOneStarHandler;
    public TeaPotTwoStarHandler teaPotTwoStarHandler;
    public Logo2Handler logo2Handler;
    public Logo4Handler logo4Handler;
    public GlobeEarthHandler globeEarthHandler;
    public GlobeBaseHandler globeBaseHandler;

    public void ResetAllPositions()
    {
        elephantOneStarHandler.BackInPosition();
        elephantTwoStarHandler.BackInPosition();
        teaPotOneStarHandler.BackInPosition();
        teaPotTwoStarHandler.BackInPosition();
        logo2Handler.BackInPosition();
        logo4Handler.BackInPosition();
        globeBaseHandler.BackInPosition();
        globeEarthHandler.BackInPosition();
    }
}
