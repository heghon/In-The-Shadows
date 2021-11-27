using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetHandler : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
    }

    public void ResetPanelAppearance()
    {
        animator.Play("ResetPanelAppearance");
    }
}
