using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup MyUIGroup;

    private bool fadeIn = false;
    private bool fadeOut = false;

    public float TimeBeforeFadeIn;
    public float TimeBeforeFadeOut;
    private float Timer1 = 0;
    private float Timer2 = 0;

    public void ShowUI()
    {
        fadeIn = true;
        gameObject.SetActive(true);
        Timer1 = 0;
        Timer2 = 0;
    }

    public void HideUI()
    {
        fadeOut = true;
        Timer1 = 0;
        Timer2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeBeforeFadeIn > 0.0f)
        {
            Timer1 += Time.deltaTime;
        }

        if (TimeBeforeFadeOut > 0.0f)
        {
            Timer2 += Time.deltaTime;
        }

        if (fadeIn && Timer1 > TimeBeforeFadeIn)
        {
            if (MyUIGroup.alpha < 1)
            {
                MyUIGroup.alpha += Time.deltaTime;
                fadeIn = MyUIGroup.alpha < 1;
            }
        }
        if (fadeOut && Timer2 > TimeBeforeFadeOut)
        {
            if (MyUIGroup.alpha > 0)
            {
                MyUIGroup.alpha -= Time.deltaTime;
                fadeOut = MyUIGroup.alpha > 0;
                gameObject.SetActive(fadeOut);
            }
        }
    }
}
