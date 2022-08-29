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


    //�Ĥ@�Ӱʧ@
    private void Start()
    {
        bossaction = gameObject.AddComponent<bossidle>();
    }

//�U�@�Ӱʧ@
    public void nextmove1()
    {
        print("loadidle");
        bossaction = gameObject.AddComponent<bossidle>();
    }

//�U�@�Ӱʧ@2
    public void nextmove2()
    {
        bossaction = gameObject.AddComponent<bossstop>();
    }


}
