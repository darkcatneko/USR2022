using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GambleCtrl : MonoBehaviour
{
    public void test(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            print("a");
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
