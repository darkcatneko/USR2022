using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BossIdle : _BossActionClass
{
    float idleTime = 2;

    protected override void Action()
    {
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        parent.animator.SetInteger("bossStage", 0);
        print("idle");
        yield return new WaitForSeconds(idleTime);

        SkillFinish();
    }
}
