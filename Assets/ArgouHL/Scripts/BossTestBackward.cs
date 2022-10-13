using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTestBackward : BossActionClass
{
   

    float backTime = 1f;
    

    protected override void action()
    {

        StartCoroutine(move());
    }

    protected override IEnumerator move()
    {
        Vector3 orgpos = transform.position;
        parent.animator.SetInteger("bossStage", 2);
        
        print("back");
        float time = 0;
        while (time < backTime)
        {
            transform.position = new Vector3(orgpos.x, orgpos.y, Mathf.Lerp(orgpos.z, 0f, time / backTime));
            time += Time.deltaTime;
            yield return null;
        }
        

        
        skillfinish();


    }
}

