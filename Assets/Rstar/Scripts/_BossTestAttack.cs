using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BossTestAttack : _BossActionClass
{
    float moveTime = 2f;
    float attackTime = 2;
    [SerializeField] _HpControl hpControl;


    protected override void Action()
    {

        StartCoroutine(Move());
    }

    protected override IEnumerator Move()
    {
        print("attack");
        
        float duration = attackTime;
        float time = 0f;
        Vector3 handOrgPos = hand.transform.localPosition;
        Vector3 orgPos = transform.position;

        //計時+動作(如無動作,可用yield return new WaitForSeconds代替)
        while (time < 0.5f)
        {
            transform.position = Vector3.Lerp(orgPos, new Vector3(orgPos.x, orgPos.y, -3f),time/0.5f);  
            time += Time.deltaTime;
            yield return null;
        }

        parent.TapHint(1);

        //計時+動作(如無動作,可用yield return new WaitForSeconds代替)
        while (time < duration)
        {
            hand.transform.localPosition = handOrgPos + new Vector3(0,0, -Mathf.Abs(Mathf.Sin(360f * (time-0.5f) / (moveTime-0.5f) * Mathf.Deg2Rad)*0.5f));
            time += Time.deltaTime;
            yield return null;
        }
        parent.TapHint(0);

        parent.GiveDamageToPlayer();
        SkillFinish();


    }
}

