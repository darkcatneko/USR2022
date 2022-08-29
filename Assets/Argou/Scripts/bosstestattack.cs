using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosstestattack :  bossactionclass
{


    float movetime = 2f;
    float attacktime = 2;
    [SerializeField] hpcontrol hpcontrol;

    protected override void action()
    {

        StartCoroutine(move());
    }

    protected override IEnumerator move()
    {
        print("attack");
        
        float duration = attacktime;
        float time = 0f;
        Vector3 handorgpos = hand.transform.localPosition;
        Vector3 orgpos = transform.position;

        //計時+動作(如無動作,可用yield return new WaitForSeconds代替)
        while (time < 1f)
        {
            transform.position = Vector3.Lerp(orgpos, new Vector3(orgpos.x, orgpos.y, -1.5f),time/1f);
            time += Time.deltaTime;
            yield return null;
        }

        //計時+動作(如無動作,可用yield return new WaitForSeconds代替)
        while (time < duration)
        {
            hand.transform.localPosition = handorgpos + new Vector3(0,0, Mathf.Abs(Mathf.Sin(360f * (time-1) / (movetime-1) * Mathf.Deg2Rad)*0.5f));
            time += Time.deltaTime;
            yield return null;
        }

        Parent.givedamagetoplayer();
        skillfinish();


    }
}

