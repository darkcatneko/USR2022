using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCIdleAniControl : MonoBehaviour
{
    private Animator IdleAnimator;



    private void Start()
    {
        IdleAnimator = GetComponent<Animator>();

        float delay = Random.Range(0, 1f);
        Invoke("StartIdle", delay);
    }

    private void StartIdle()
    {
        IdleAnimator.SetTrigger("Idle");
    }
}
