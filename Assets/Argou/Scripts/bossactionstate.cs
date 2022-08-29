using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//
public abstract class bossactionstate : MonoBehaviour
{
    
    public bossactcontroller Parent;
    

    protected virtual void Start()
    {
        Parent = GetComponent<bossactcontroller>();
        action();
    }

    protected abstract void action();



    public virtual void skillfinish()
    {
         Destroy(this);
        Parent.givedamagetoplayer();
    }
}
