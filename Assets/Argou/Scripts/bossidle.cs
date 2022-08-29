using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossidle : bossactionstate
{

    float movedistance = 1f;
    float movetime = 0.5f;
    float idletime = 2;

   

    protected override void action()
    {
        StartCoroutine(move());
    }

    IEnumerator move()
    {

        float duration = idletime;
        float time = 0f;
        Vector3 orgpos = transform.position;
        while (time < duration)
        {
            transform.position = orgpos + new Vector3(Mathf.Sin(360f * time / movetime * Mathf.Deg2Rad), 0, 0);
            time += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        skillfinish();
        Parent.nextmove2();
    }
}
