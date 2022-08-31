using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//所有boss動作的共用class
public abstract class A_BossActionClass : MonoBehaviour
{
    //把controller設定為Parent
    public A_BossActController parent;
    

    //所有action載入(開始)時都會呼叫一次
    protected virtual void Start()
    {

        //把controller設定為Parent
        
        parent = GetComponent<A_BossActController>();

       
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
        parent.nextmove();
    }


    public virtual void stopattack()
    {
        StopCoroutine(move());
        Destroy(this);


    }
    

}
