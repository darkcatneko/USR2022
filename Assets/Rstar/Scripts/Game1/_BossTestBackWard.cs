using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BossTestBackWard : _BossActionClass
{
    float backTime = .5f;

    protected override void Action()
    {
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        parent.animator.SetInteger("bossStage", 2);
        print("back");

        yield return new WaitForSeconds(backTime);

        SkillFinish();
    }
}

