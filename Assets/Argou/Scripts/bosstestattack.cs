using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTestAttack : BossActionClass
{


    float moveTime = 2f;
    float attackTime = 2;
    

    protected override void action()
    {

        StartCoroutine(move());
    }

    protected override IEnumerator move()
    {
        print("attack");
        
        float duration = attackTime;
        float time = 0f;
        Vector3 handorgpos = hand.transform.localPosition;
        Vector3 orgpos = transform.position;

        //計時+動作(如無動作,可用yield return new WaitForSeconds代替)
        while (time < 0.5f)
        {
            transform.position = Vector3.Lerp(orgpos, new Vector3(orgpos.x, orgpos.y, -3f),time/0.5f);  
            time += Time.deltaTime;
            yield return null;
        }

        parent.taphint(1);

        //計時+動作(如無動作,可用yield return new WaitForSeconds代替)
        while (time < duration)
        {
            hand.transform.localPosition = handorgpos + new Vector3(0,0, -Mathf.Abs(Mathf.Sin(360f * (time-0.5f) / (moveTime-0.5f) * Mathf.Deg2Rad)*0.5f));
            time += Time.deltaTime;
            yield return null;
        }
        parent.taphint(0);

        parent.givedamagetoplayer();
        skillfinish();


    }
}

