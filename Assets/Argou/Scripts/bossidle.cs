using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossidle : bossactionclass
{

    float movedistance = 0.2f;
    float movetime = 0.5f;
    float idletime = 2;

   

    protected override void action()
    {
        StartCoroutine(move());
    }

    IEnumerator move()
    {
        print("idle");
        float duration = idletime;
        float time = 0f;
        Vector3 orgpos = transform.position;

        //計時+動作(如無動作,可用yield return new WaitForSeconds代替)
        while (time < duration)
        {
            transform.position = orgpos + new Vector3(Mathf.Sin(360f * time / movetime * Mathf.Deg2Rad)* movedistance, 0, 0);
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForFixedUpdate();
        skillfinish();

       
    }
}
