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
        Vector3 OrgPos = transform.position;
        Vector3 plyerOrgPos = transform.position;
        float time = 0;
        float duration = 0.1f;
        while (time< duration)
        {
            transform.position = new Vector3(OrgPos.x, OrgPos.y, Mathf.Lerp(OrgPos.z, -2f, time / duration));
            

            time += Time.deltaTime;
            yield return null;
        }
        //handRender.material.color = Color.gray;
        
        print("stop");
        

        yield return new WaitForSeconds(parent.canAttackTime- duration);
        parent.isStunned = false;
        parent.TapHint(0, "");
        skillfinish();


       
    }
}
