using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//��q����
public class hpcontrol : MonoBehaviour
{
    [SerializeField] private int maxHP;
    [SerializeField] protected int nowHP;
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
