using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Cinemachine;

public class GenAndCtrl : MonoBehaviour
{
    [SerializeField] GameObject LvStartPoint, GameCanvas, FastTapCanvas;
    [SerializeField] GameObject[] PrefabLvObjs = new GameObject[4];
    [SerializeField] GameObject[] LastEnemys = new GameObject[3];
    [SerializeField] Button ClearBtn, ForwardBtn;

    GameObject[] LvObjs = new GameObject[11];
    Vector3 Gap = new Vector3(0, 0, 3);
    float MoveSpeed = 10f;
    int LvProgress = 0;
    //bool CanCtrl = false;

    void Start()
    {
        LvObjs[0] = Instantiate(PrefabLvObjs[1], LvStartPoint.transform.position, LvStartPoint.transform.rotation);
        for(byte i = 1; i < LvObjs.Length - 1; i++)
        {
            LvObjs[i] = Instantiate(PrefabLvObjs[Random.Range(0, 4)], LvObjs[i - 1].transform.position + Gap,
                                                                      LvObjs[i - 1].transform.rotation);
        }
        LvObjs[LvObjs.Length - 1] = LastEnemys[0];
        StartCoroutine("Move");
    }

    void Update()
    {
        
    }

    public void ClearBtn_Click()
    {

    }

    public void ForwardBtn_Click()
    {

    }

    IEnumerator Move()
    {
        ClearBtn.interactable = false;
        ForwardBtn.interactable = false;
        while (transform.position.z < LvObjs[LvProgress].transform.position.z - 2)
        {
            transform.position = new Vector3(transform.position.x,
                                             transform.position.y,
                                             Mathf.MoveTowards(transform.position.z,
                                                               LvObjs[LvProgress].transform.position.z - 2,
                                                               MoveSpeed * Time.deltaTime));
            yield return null;
        }
        if (LvProgress == LvObjs.Length - 1)
        {

        }
    }
}
