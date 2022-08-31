using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;
public class CameraAnimationController : MonoBehaviour
{
    public Animator CamAnimator;
    public bool Is_Walking;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Is_Walking)
        {
            CamAnimator.SetBool("IsRunning", true);
        }
        else
        {
            CamAnimator.SetBool("IsRunning", false);
        }

        
    }
    public void Start_Running()
    {
        Is_Walking = true;
    }
    public void End_Running()
    {
        Is_Walking = false;
    }
}
