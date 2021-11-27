using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo2Handler : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosDelta = Vector3.zero;
    Vector3 temp;
    Vector3 pos;
    Vector3 rotByX;
    Vector3 rotByY;
    Vector3 rotationPoint;
    public Quaternion rotTemp;
    Quaternion prevRot;

    bool isSelected;

    public Transform otherObject;
    public Logo4Handler logo4Handler;

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
        RaycastHit hit;
        int diff = difficultyManager.difficulty;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (((Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) && hit.transform == gameObject.transform) || isSelected == true) && !victoryBool && !PauseMenu.GameIsPaused)
        {
            if ((Input.GetMouseButton(0) && (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))) && diff >= 3)
            {
                mPosDelta = Input.mousePosition - mPrevPos;
                transform.Translate(mPosDelta.x / 100, mPosDelta.y / 100, 0, Space.World);
                temp = transform.position;

                if (transform.position.x > 4f)
                    temp.x = 4f;
                if (transform.position.x < -4f)
                    temp.x = -4f;
                if (transform.position.y > 64f)
                    temp.y = 64f;
                if (transform.position.y < 56f)
                    temp.y = 56f;
                transform.position = temp;

            }
            else if (Input.GetMouseButton(0) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && !(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && diff >= 2)
            {
                mPosDelta = Input.mousePosition - mPrevPos;
                //transform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosDelta / 10, Camera.main.transform.up), Space.World);
                transform.Rotate((mPosDelta.y / 10), 0.0f, 0.0f, Space.World);
                //transform.RotateAround(rotationPoint, rotByX, mPosDelta.y / 10);
            }

            else if (Input.GetMouseButton(0) && !(Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && diff >= 1)
            {
                mPosDelta = Input.mousePosition - mPrevPos;
                //transform.Rotate(Camera.main.transform.up, -Vector3.Dot(mPosDelta / 10, Camera.main.transform.right), Space.World);
                transform.Rotate(0.0f, (-mPosDelta.x / 10), 0.0f, Space.World);
                //transform.RotateAround(rotationPoint, rotByY, mPosDelta.x / 10);
            }
            isSelected = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isSelected = false;
        }

        mPrevPos = Input.mousePosition;
        if ((transform.eulerAngles.y > 0f && transform.eulerAngles.y < 10f) &&
            (transform.eulerAngles.x > 355f || transform.eulerAngles.x < 5f) &&
            (transform.position.x > otherObject.transform.position.x  + 3.1 && transform.position.x < otherObject.transform.position.x + 3.6) && 
            (transform.position.y > otherObject.transform.position.y + 0.4 && transform.position.y < otherObject.transform.position.y + 0.6) &&
            Input.GetMouseButtonUp(0))
        {
            almostVictoryBool = true;
        }

        if (almostVictoryBool && logo4Handler.almostVictoryBool)
            victoryBool = true;

        testh = transform.eulerAngles.y;
        testv = transform.eulerAngles.x;
        posX = transform.position.x - otherObject.transform.position.x;
        posY = transform.position.y - otherObject.transform.position.y;
    }
    public void BackInPosition()
    {
        transform.position = new Vector3(OriginPositionX, OriginPositionY, OriginPositionZ);
        transform.rotation = Quaternion.Euler(OriginRotationX, OriginRotationY, OriginRotationZ);
        victoryBool = false;
        almostVictoryBool = false;
    }
}
