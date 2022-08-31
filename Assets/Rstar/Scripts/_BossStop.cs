using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class _BossStop : _BossActionClass
{
    float moveTime = 1f;
    float idleTime = 2;

    protected override void Action()
    {
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        print("stop");
        float duration = idleTime;
        float time = 0f;

        //計時+動作(如無動作,可用yield return new WaitForSeconds代替)
        while (time < duration)
        {
            transform.eulerAngles = new Vector3(0, 360*time/moveTime, 0);
            time += Time.deltaTime;
            yield return null;
        }
        
        SkillFinish();

       
    }
}
