using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class _BossStop : _BossActionClass
{
    protected override void Action()
    {
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        parent.animator.SetInteger("bossStage", 3);
        print("stunned");

        handRender.material.color = Color.gray;

        yield return new WaitForSeconds(parent.canAttackTime);

        parent.isStunned = false;

        SkillFinish();
    }
}
