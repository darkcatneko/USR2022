using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BossTestAttack : BossActionClass
{


    
    

    protected override void action()
    {

        StartCoroutine(move());
    }

    protected override IEnumerator move()
    {
        Vector3 orgpos = transform.position;    
        parent.TapHint(0, "");
        parent.animator.SetInteger("bossStage", 1);
        print("attack");
        boxerBossParticleControl.charging();

        //handRender.material.color = new Color(255, 255, 0);

        yield return new WaitForSeconds(attackReadyTime);

        //handRender.material.color = new Color(255, 0, 0);
        //handRender.material.color = new Color(255, 255, 0);

        parent.TapHint(1,"Tap to Guard");
        float time=0;
        yield return new WaitForSeconds(0.25f);
        boxerBossParticleControl.attacking();
        while (time < (attackTime - 0.25f))
        {
            transform.position = new Vector3(orgpos.x, orgpos.y, Mathf.Lerp(orgpos.z, -3f, time / (attackTime- 0.25f)));
            time += Time.deltaTime;
            yield return null;
        }
        //yield return new WaitForSeconds(attackTime);

        parent.GiveDamageToPlayer();

        parent.TapHint(0,"");
        //handRender.material.color = Color.gray;
        boxerBossParticleControl.attackEnd();
        Destroy(this);
        //SkillFinish();

    }
}

