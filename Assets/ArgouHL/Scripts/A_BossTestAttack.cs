using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_BossTestAttack : A_BossActionClass
{


    float moveTime = 2f;
    float attackTime = 3f;
    

    protected override void action()
    {

        StartCoroutine(move());
    }

    protected override IEnumerator move()
    {
        print("attack");
        
        float duration = attackTime;
        float time = 0f;
       
        Vector3 orgpos = transform.position;

        //計時+動作(如無動作,可用yield return new WaitForSeconds代替)
        while (time < moveTime)
        {
            transform.position = Vector3.Lerp(orgpos, new Vector3(orgpos.x, orgpos.y, -3f),time/ moveTime);  
            time += Time.deltaTime;
            yield return null;
        }
        parent.bossAnimator.SetInteger("bossStage", 4);

        parent.taphint(1);

        time = 0;
        //計時+動作(如無動作,可用yield return new WaitForSeconds代替)
        while (time < attackTime)
        {
          
            time += Time.deltaTime;
            yield return null;
        }
        parent.taphint(0);

        parent.givedamagetoplayer();
        skillfinish();


    }
}

