using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bossstop :bossactionstate
{

    float movedistance = 1f;
    float movetime = 1f;
    float idletime = 5;
    [SerializeField] hpcontrol hpcontrol;
    
    protected override void action()
    {
        StartCoroutine(move());
    }

    IEnumerator move()
    {

        float duration = idletime;
        float time = 0f;
       
        while (time < duration)
        {
            transform.eulerAngles = new Vector3(0, 360*time/movetime, 0);
            time += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        skillfinish();
        
        Parent.nextmove1();
    }
}
