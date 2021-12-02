using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyModeManager : MonoBehaviour
{
    public bool easyMode;

    // Start is called before the first frame update
    void Start()
    {
        easyMode = GameObject.Find("EasyModeToggle").GetComponent<Toggle>().isOn;
    }

    public void ChangeEasyMode()
    {
        easyMode = easyMode ? false : true;
    }
}
