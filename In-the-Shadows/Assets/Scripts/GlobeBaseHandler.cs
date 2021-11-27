using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeBaseHandler : MonoBehaviour
{
    public Transform otherObject;
    public GlobeEarthHandler globeEarthHandler;

    public bool almostVictoryBool;
    public bool victoryBool;

    DifficultyManager difficultyManager;
    MovementsHandler movementsHandler;

    public float testh;
    public float testv;

    float OriginPositionX;
    float OriginPositionY;
    float OriginPositionZ;

    float OriginRotationX;
    float OriginRotationY;
    float OriginRotationZ;

    private void Awake()
    {
        OriginPositionX = transform.position.x;
        OriginPositionY = transform.position.y;
        OriginPositionZ = transform.position.z;

        OriginRotationX = transform.eulerAngles.x;
        OriginRotationY = transform.eulerAngles.y;
        OriginRotationZ = transform.eulerAngles.z;
    }

    // Start is called before the first frame update
    void Start()
    {
        victoryBool = false;
        almostVictoryBool = false;
        difficultyManager = FindObjectOfType<DifficultyManager>();
        movementsHandler = FindObjectOfType<MovementsHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        movementsHandler.HandleTheMoves(difficultyManager.difficulty, victoryBool);

        if ((transform.eulerAngles.y > 351f && transform.eulerAngles.y < 359f) &&
            (transform.eulerAngles.x > 355f || transform.eulerAngles.x < 5f) &&
            (transform.position.x < otherObject.transform.position.x + .5 && transform.position.x > otherObject.transform.position.x - .5) &&
            (transform.position.y < otherObject.transform.position.y + .5 && transform.position.y > otherObject.transform.position.y - .5) &&
            Input.GetMouseButtonUp(0))
        {
            almostVictoryBool = true;
        }

        if (almostVictoryBool && globeEarthHandler.almostVictoryBool)
            victoryBool = true;

        testh = transform.eulerAngles.y;
        testv = transform.eulerAngles.x;
    }

    public void BackInPosition()
    {
        transform.position = new Vector3(OriginPositionX, OriginPositionY, OriginPositionZ);
        transform.rotation = Quaternion.Euler(OriginRotationX, OriginRotationY, OriginRotationZ);
        victoryBool = false;
        almostVictoryBool = false;
    }
}
