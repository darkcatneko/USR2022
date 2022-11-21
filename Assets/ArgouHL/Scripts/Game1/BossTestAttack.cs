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
        switch (parent.attackFactor)
        {
            case 0:
                boxerBossParticleControl.Charging();
                break;
            case 1:
                boxerBossParticleControl.ChargingL();
                break;
            //default:
            //    boxerBossParticleControl.Charging();
            //    break;
        }

      

        
        
        yield return new WaitForSeconds(0.5f);

        boxerBossParticleControl.StopCharging();

        yield return new WaitForSeconds(attackReadyTime -0.5f);
        
        float time=0;
        yield return new WaitForSeconds(0.25f);
        parent.TapHint(1, "Tap to Guard");
        switch (parent.attackFactor)
        {
            case 0:
                boxerBossParticleControl.Attacking();
                break;
            case 1:
                boxerBossParticleControl.AttackingL();
                break;
            //default:
            //    boxerBossParticleControl.Attacking();
            //    break;
        }

        
        while (time < (attackTime - 0.25f))
        {
            transform.position = new Vector3(orgpos.x, orgpos.y, Mathf.Lerp(orgpos.z, -3f, time / (attackTime- 0.25f)));
            time += Time.deltaTime;
            yield return null;
        }
        //yield return new WaitForSeconds(attackTime);
        boxerBossParticleControl.Hitted();
        parent.GiveDamageToPlayer();
        
        parent.TapHint(0,"");
        //handRender.material.color = Color.gray;
        boxerBossParticleControl.AttackEnd();
        Destroy(this);
        //SkillFinish();

    }
}

