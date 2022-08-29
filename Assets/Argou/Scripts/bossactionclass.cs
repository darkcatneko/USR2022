using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//所有boss動作的共用class
public abstract class bossactionclass: MonoBehaviour
{
    //把controller設定為Parent
    public bossactcontroller Parent;
    
    //所有action載入(開始)時都會呼叫一次
    protected virtual void Start()
    {
        //把controller設定為Parent
        Parent = GetComponent<bossactcontroller>();


        action();
    }

    //所有action都要有的function
    protected abstract void action();



    public virtual void skillfinish()
    {
        //把這個script從obj上刪掉
        Destroy(this);



        //叫Controller去下一個動作
        Parent.nextmove();
    }
}
