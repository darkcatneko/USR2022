using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//血量控制
public class hpcontrol : MonoBehaviour
{
    [SerializeField] int maxHP;
    [SerializeField] int nowHP;
    [SerializeField] CanvasGroup hpbar;
    


    private void Start()
    {
        nowHP = maxHP;
    }

    //可以給其他UnityEvent呼叫
    public void getdamage(int x)
    {
        nowHP -= x;
    }

    

   
}
