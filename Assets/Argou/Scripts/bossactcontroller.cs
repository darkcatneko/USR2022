using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class bossactcontroller : MonoBehaviour
{
    [SerializeField] bossactionstate bossaction;
    [SerializeField] int bossstage = 0;
    [SerializeField] UnityEvent damagetoplayer;

    public void givedamagetoplayer()
    {
        damagetoplayer.Invoke();
    }


    //第一個動作
    private void Start()
    {
        bossaction = gameObject.AddComponent<bossidle>();
    }

//下一個動作
    public void nextmove1()
    {
        print("loadidle");
        bossaction = gameObject.AddComponent<bossidle>();
    }

//下一個動作2
    public void nextmove2()
    {
        bossaction = gameObject.AddComponent<bossstop>();
    }


}
