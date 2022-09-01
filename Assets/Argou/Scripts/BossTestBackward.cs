using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTestBackward : BossActionClass
{


    
    float backTime = 0.5f;
    

    protected override void action()
    {

        StartCoroutine(move());
    }

    protected override IEnumerator move()
    {
        
        parent.animator.SetInteger("bossStage", 2);
        
        print("back");

        yield return new WaitForSeconds(backTime);

        
        skillfinish();


    }
}

