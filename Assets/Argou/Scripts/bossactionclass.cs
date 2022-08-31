﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//所有boss動作的共用class
public abstract class BossActionClass: MonoBehaviour
{
    //把controller設定為Parent
    public BossActController parent;
    public GameObject hand;
    public Renderer handRender;
    


    //所有action載入(開始)時都會呼叫一次
    protected virtual void Start()
    {

        //把controller設定為Parent
        parent = GetComponent<BossActController>();

        transform.eulerAngles = new Vector3(0, 0, 0);
        hand = GameObject.Find("hand");
        handRender = hand.GetComponent<Renderer>();
        
        action();
    }

    //所有action都要有的function
    protected abstract void action();
    protected abstract IEnumerator move();


    public virtual void skillfinish()
    {
        //把這個script從obj上刪掉
        Destroy(this);

        print("nextaction");


        //叫Controller去下一個動作
        parent.nextmove();
    }


    public virtual void stop()
    {
        StopCoroutine(move());
        Destroy(this);


    }
    

}
