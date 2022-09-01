using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BossTestAttack : BossActionClass
{


    float moveTime = 0.5f;
    float attackTime = 0.5f;
    

    protected override void action()
    {

        StartCoroutine(move());
    }

    protected override IEnumerator move()
    {
        parent.TapHint(0, "");
        parent.animator.SetInteger("bossStage", 1);
        print("attack");

        //handRender.material.color = new Color(255, 255, 0);

        yield return new WaitForSeconds(moveTime);

        //handRender.material.color = new Color(255, 0, 0);
        handRender.material.color = new Color(255, 255, 0);
        parent.TapHint(1,"Tap to Guard");

        yield return new WaitForSeconds(attackTime);

        parent.GiveDamageToPlayer();

        parent.TapHint(0,"");
        handRender.material.color = Color.gray;

        Destroy(this);
        //SkillFinish();

    }
}

