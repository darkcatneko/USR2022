using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BossTestBackWard : _BossActionClass
{
    float backTime = 1;
    [SerializeField] _HpControl hpControl;

    protected override void Action()
    {
        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        print("back");
        
        float duration = backTime;
        float time = 0f;
        Vector3 orgPos = transform.position;

        //�p��+�ʧ@(�p�L�ʧ@,�i��yield return new WaitForSeconds�N��)
        while (time < 1f)
        {
            transform.position = Vector3.Lerp(orgPos, new Vector3(orgPos.x, orgPos.y, 0), time / 1f);
            time += Time.deltaTime;
            yield return null;
        }

        parent.GiveDamageToPlayer();
        SkillFinish();


    }
}

