using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BossTestAttack : _BossActionClass
{
    float moveTime = .5f;
    float attackTime = .5f;


    protected override void Action()
    {

        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        parent.animator.SetInteger("bossStage", 1);
        print("attack");

        //handRender.material.color = new Color(255, 255, 0);

        yield return new WaitForSeconds(moveTime);

        //handRender.material.color = new Color(255, 0, 0);
        handRender.material.color = new Color(255, 255, 0);
        parent.TapHint(1);

        yield return new WaitForSeconds(attackTime);

        parent.GiveDamageToPlayer();

        parent.TapHint(0);
        handRender.material.color = Color.gray;

        Destroy(this);
        //SkillFinish();
    }
}

