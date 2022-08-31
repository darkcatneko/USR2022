using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Cinemachine;

public class GenAndCtrl : MonoBehaviour
{
    [SerializeField] GameObject LvStartPoint, GameCanvas, FastTapCanvas;
    [SerializeField] Button ClearBtn, ForwardBtn;
    [SerializeField] CameraAnimationController CameraAnimCtrler;
    [SerializeField] GameObject[] PrefabLvObjs = new GameObject[4];
    [SerializeField] GameObject[] LastEnemys = new GameObject[3];

    GameObject[] LvObjs = new GameObject[11];
    Vector3 GapVector = new Vector3(0, 0, 3);
    float MoveSpeed = 10f;
    int LvProgress = -1;
    bool CanOpenBox2 = false;

    void Start()
    {
        LvObjs[0] = Instantiate(PrefabLvObjs[1], LvStartPoint.transform.position, LvStartPoint.transform.rotation);
        for(byte i = 1; i < LvObjs.Length - 1; i++)
        {
            LvObjs[i] = Instantiate(PrefabLvObjs[Random.Range(0, 4)], LvObjs[i - 1].transform.position + GapVector,
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
        switch (LvObjs[LvProgress].tag)
        {
            case "Enemy":
                LvObjs[LvProgress].SetActive(false);
                break;
            case "Box1":
                LvObjs[LvProgress].SetActive(false);
                break;
            case "Box2":
                if (CanOpenBox2)
                {
                    CanOpenBox2 = false;
                    LvObjs[LvProgress].SetActive(false);
                }
                else
                {
                    LvObjs[LvProgress].transform.Find("Box").Find("Lock").gameObject.SetActive(false);
                    CanOpenBox2 = true;
                }
                break;
            case "NoneObj":
                break;
        }
    }

    public void ForwardBtn_Click()
    {
        if (!LvObjs[LvProgress].activeSelf || LvObjs[LvProgress].tag != "Enemy")
        {
            StartCoroutine("Move");
        }
    }

    IEnumerator Move()
    {
        CameraAnimCtrler.Is_Walking = true;
        LvProgress++;
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
        CameraAnimCtrler.Is_Walking = false;
        if (LvProgress == LvObjs.Length - 1)
        {
            GameCanvas.SetActive(false);
            FastTapCanvas.SetActive(true);
        }
        else
        {
            ClearBtn.interactable = true;
            ForwardBtn.interactable = true;
        }
    }
}
