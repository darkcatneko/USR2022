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

        //�p��+�ʧ@(�p�L�ʧ@,�i��yield return new WaitForSeconds�N��)
        while (time < duration)
        {
            
            time += Time.deltaTime;
            yield return null;
            
        }
        
        skillfinish();

       
    }
}
