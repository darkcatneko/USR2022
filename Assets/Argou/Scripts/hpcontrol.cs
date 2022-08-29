using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//¦å¶q±±¨î
public class hpcontrol : MonoBehaviour
{
    [SerializeField] int maxHP;
    [SerializeField] int nowHP;
    [SerializeField] CanvasGroup hpbar;
    


    private void Start()
    {
        nowHP = maxHP;
    }

    public void getdamage(int x)
    {
        nowHP -= x;
    }

    

   
}
