using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaPotOneStarHandler : MonoBehaviour
{
    public bool victoryBool;

    DifficultyManager difficultyManager;
    MovementsHandler movementsHandler;

    public float testh;

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
        difficultyManager = FindObjectOfType<DifficultyManager>();
        movementsHandler = FindObjectOfType<MovementsHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        movementsHandler.HandleTheMoves(difficultyManager.difficulty, victoryBool);

        if ((transform.eulerAngles.y > 173f && transform.eulerAngles.y < 177f) && Input.GetMouseButtonUp(0))
        {
            victoryBool = true;
        }
        testh = transform.eulerAngles.y;
    }
    public void BackInPosition()
    {
        transform.position = new Vector3(OriginPositionX, OriginPositionY, OriginPositionZ);
        transform.rotation = Quaternion.Euler(OriginRotationX, OriginRotationY, OriginRotationZ);
        victoryBool = false;
    }
}
