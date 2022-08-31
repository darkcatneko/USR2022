using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_BossIdle : A_BossActionClass
{

    
   
    float idletime = 2;

   

    protected override void action()
    {
        StartCoroutine(move());
    }

    protected override IEnumerator move()
    {
        print("idle");
       

        //計時+動作(如無動作,可用yield return new WaitForSeconds代替)
        yield return new WaitForSeconds(idletime);

        
        skillfinish();

       
    }
}
