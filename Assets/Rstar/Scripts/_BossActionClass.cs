using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//所有boss動作的共用class
public abstract class _BossActionClass : MonoBehaviour
{
    //把controller設定為parent
    public _BossActController parent;
    public GameObject hand;
    //所有Action載入(開始)時都會呼叫一次
    protected virtual void Start()
    {
        //把controller設定為parent
        hand = GameObject.FindGameObjectWithTag("hand");
        parent = GetComponent<_BossActController>();


        Action();
    }

    //所有Action都要有的function
    protected abstract void Action();
    protected abstract IEnumerator Move();


    public virtual void SkillFinish()
    {
        //把這個script從obj上刪掉
        Destroy(this);



        //叫Controller去下一個動作
        parent.NextMove();
    }


    public virtual void StopAttack()
    {
        StopCoroutine(Move());
        Destroy(this);


    }
    

}
