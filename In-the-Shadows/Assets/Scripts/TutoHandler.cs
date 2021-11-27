using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoHandler : MonoBehaviour
{
    public GameObject tutoPanel;

    public bool displayPanel;

    private void Awake()
    {
        tutoPanel.SetActive(false);
        tutoPanel.GetComponent<CanvasGroup>().alpha = 0;
        displayPanel = !tutoPanel.GetComponentInChildren<Toggle>().isOn;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        displayPanel = !tutoPanel.GetComponentInChildren<Toggle>().isOn;
    }

    public void showTuto()
    {
        if (displayPanel)
        {
            tutoPanel.SetActive(true);
            tutoPanel.GetComponent<CanvasGroup>().alpha = 1;
        }
    }

    public void hideTuto()
    {
        tutoPanel.SetActive(false);
        tutoPanel.GetComponent<CanvasGroup>().alpha = 0;
    }
}
