using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class A_BossStop : A_BossActionClass
{

    
    
    float stunTime = 3;
   
    
    protected override void action()
    {
        
        StartCoroutine(move());
    }

    protected override IEnumerator move()
    {
        print("stop");
        float duration = stunTime;
        float time = 0f;

        //計時+動作(如無動作,可用yield return new WaitForSeconds代替)
        while (time < duration)
        {
            
            time += Time.deltaTime;
            yield return null;
            
        }
        
        skillfinish();

       
    }
}
