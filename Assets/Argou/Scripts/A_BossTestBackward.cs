using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_BossTestBackward : A_BossActionClass
{


    
    float backTime = 1;
    

    protected override void action()
    {

        StartCoroutine(move());
    }

    protected override IEnumerator move()
    {
        print("back");
        
        float duration = backTime;
        float time = 0f;
        Vector3 orgpos = transform.position;

        //計時+動作(如無動作,可用yield return new WaitForSeconds代替)
        while (time < 1f)
        {
            transform.position = Vector3.Lerp(orgpos, new Vector3(orgpos.x, orgpos.y, 0), time / 1f);
            time += Time.deltaTime;
            yield return null;
        }

        
        skillfinish();


    }
}

