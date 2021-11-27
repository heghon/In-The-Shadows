using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsHandler : MonoBehaviour
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

    private void Awake()
    {
        pos.x = 0;
        pos.y = 61;
        pos.z = 0;
        rotByX.x = 1.0f;
        rotByX.y = 0.0f;
        rotByX.z = 0.0f;
        rotByY.x = 0.0f;
        rotByY.y = 1.0f;
        rotByY.z = 0.0f;
        rotationPoint.x = 0;
        rotationPoint.y = 61;
        rotationPoint.z = 0;
    }

    public void HandleTheMoves(int diff, bool victoryBool)
    {
        RaycastHit hit;
        //diff = difficultyManager.difficulty;
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
    }
}
