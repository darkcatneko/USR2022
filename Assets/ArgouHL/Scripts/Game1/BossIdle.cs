using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : BossActionClass
{

    float idletime = 2;

   

    protected override void action()
    {
        StartCoroutine(move());
    }

    protected override IEnumerator move()
    {
        parent.animator.SetInteger("bossStage", 0);
        print("idle");
        yield return new WaitForSeconds(idletime);
        
        skillfinish();

       
    }
}
