using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo4Handler : MonoBehaviour
{
    public Transform otherObject;
    public Logo2Handler logo2Handler;

    public bool almostVictoryBool;
    public bool victoryBool;

    DifficultyManager difficultyManager;
    MovementsHandler movementsHandler;

    public float testh;
    public float testv;
    public float posX;
    public float posY;

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

        if ((transform.eulerAngles.y > 355f || transform.eulerAngles.y < 5f) &&
            (transform.eulerAngles.x > 355f || transform.eulerAngles.x < 5f) &&
            (transform.position.x < otherObject.transform.position.x - 3.25 && transform.position.x > otherObject.transform.position.x - 3.45) &&
            (transform.position.y < otherObject.transform.position.y - 0.35 && transform.position.y > otherObject.transform.position.y - 0.55) &&
            Input.GetMouseButtonUp(0))
        {
            almostVictoryBool = true;
        }

        if (almostVictoryBool && logo2Handler.almostVictoryBool)
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
