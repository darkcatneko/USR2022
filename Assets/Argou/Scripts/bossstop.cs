using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bossstop : bossactionclass
{

    
    float movetime = 1f;
    float idletime = 5;
    [SerializeField] hpcontrol hpcontrol;
    
    protected override void action()
    {
        
        StartCoroutine(move());
    }

    IEnumerator move()
    {
        print("stop");
        float duration = idletime;
        float time = 0f;

        //�p��+�ʧ@(�p�L�ʧ@,�i��yield return new WaitForSeconds�N��)
        while (time < duration)
        {
            transform.eulerAngles = new Vector3(0, 360*time/movetime, 0);
            time += Time.deltaTime;
            yield return null;
            
        }
        yield return new WaitForFixedUpdate();

        skillfinish();

       
    }
}
