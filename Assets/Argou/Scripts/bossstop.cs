using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossStop : BossActionClass
{

    
    
    
   
    
    protected override void action()
    {
        
        StartCoroutine(move());
    }

    protected override IEnumerator move()
    {
        parent.animator.SetInteger("bossStage", 3);
        handRender.material.color = Color.gray;
        print("stop");
        

        yield return new WaitForSeconds(parent.canAttacktime);
        parent.isStunned = false;
        skillfinish();

       
    }
}
