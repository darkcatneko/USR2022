using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosstebackward :  bossactionclass
{


    
    float backtime = 1;
    [SerializeField] hpcontrol hpcontrol;

    protected override void action()
    {

        StartCoroutine(move());
    }

    protected override IEnumerator move()
    {
        print("back");
        
        float duration = backtime;
        float time = 0f;
        Vector3 orgpos = transform.position;

        //�p��+�ʧ@(�p�L�ʧ@,�i��yield return new WaitForSeconds�N��)
        while (time < 1f)
        {
            transform.position = Vector3.Lerp(orgpos, new Vector3(orgpos.x, orgpos.y, 0), time / 1f);
            time += Time.deltaTime;
            yield return null;
        }

        Parent.givedamagetoplayer();
        skillfinish();


    }
}

