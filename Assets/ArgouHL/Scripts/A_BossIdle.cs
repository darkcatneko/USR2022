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
       

        //�p��+�ʧ@(�p�L�ʧ@,�i��yield return new WaitForSeconds�N��)
        yield return new WaitForSeconds(idletime);

        
        skillfinish();

       
    }
}
