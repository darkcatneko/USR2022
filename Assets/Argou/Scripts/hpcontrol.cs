using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//��q����
public class hpcontrol : MonoBehaviour
{
    [SerializeField] int maxHP;
    [SerializeField] int nowHP;
    [SerializeField] CanvasGroup hpbar;
    


    private void Start()
    {
        nowHP = maxHP;
    }

    //�i�H����LUnityEvent�I�s
    public void getdamage(int x)
    {
        nowHP -= x;
    }

    

   
}
