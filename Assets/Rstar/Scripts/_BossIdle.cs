using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BossIdle : _BossActionClass
{
    float moveDistance = 0.2f;
    float moveTime = 0.5f;
    float idleTime = 2;
   

    protected override void Action()
    {
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        print("idle");
        float duration = idleTime;
        float time = 0f;
        Vector3 orgPos = transform.position;

        //計時+動作(如無動作,可用yield return new WaitForSeconds代替)
        while (time < duration)
        {
            transform.position = orgPos + new Vector3(Mathf.Sin(360f * time / moveTime * Mathf.Deg2Rad)* moveDistance, 0, 0);
            time += Time.deltaTime;
            yield return null;
        }

        
        SkillFinish();

       
    }
}
