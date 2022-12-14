using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//所有boss動作的共用class
public abstract class BossActionClass: MonoBehaviour
{
    public float attackReadyTime = 0.5f;
    public float attackTime = 0.5f;
    public BoxerBossParticleControl boxerBossParticleControl;
    //把controller設定為Parent
    public BossActController parent;
    public Renderer handRender;
    public GameObject player;

    //所有action載入(開始)時都會呼叫一次
    protected virtual void Start()
    {

        //把controller設定為Parent
        player = GameObject.FindGameObjectWithTag("Player");
        parent = GetComponent<BossActController>();
        boxerBossParticleControl = parent.GetComponent<BoxerBossParticleControl>();
        //handRender = GameObject.Find("hand").GetComponent<Renderer>();
        action();
    }

    //所有action都要有的function
    protected abstract void action();
    protected abstract IEnumerator move();


    public virtual void skillfinish()
    {
        //把這個script從obj上刪掉
        Destroy(this);



        //叫Controller去下一個動作
        parent.NextMove();
    }


    public virtual void StopAttack()
    {
        StopCoroutine(move());
        Destroy(this);


    }
    

}
