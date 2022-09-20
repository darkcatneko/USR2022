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
    [SerializeField] List<DifficultyGroup_ScriptableObj> DifficultyGroups = new List<DifficultyGroup_ScriptableObj>();
    [SerializeField] int SpawnSum;

    List<GameObject> LvObjs = new List<GameObject>();
    Vector3 GapVector = new Vector3(0, 0, 3);
    int SpawnCount = 0;
    float MoveSpeed = 10f;
    public int LvProgress = -1;
    bool CanOpenBox2 = false;

    int Choose(float[] probs)
    {

        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

    void SpawnLvObjs()
    {
        DifficultyGroup_ScriptableObj SelectedDifficultyGroup;
        GenGroup_ScriptableObj SelectedGenGroup;
        float[] DifficultyProbs = new float[DifficultyGroups.Count];
        for (byte i=0; i < DifficultyGroups.Count; i++)
        {
            DifficultyProbs[i] = DifficultyGroups[i].DifficultyCurve.Evaluate((float)SpawnCount / SpawnSum);
        }
        SelectedDifficultyGroup = DifficultyGroups[Choose(DifficultyProbs)];
        SelectedGenGroup = SelectedDifficultyGroup.GenGroups[Random.Range(0, SelectedDifficultyGroup.GenGroups.Count)];
        foreach(GameObject GenObj in SelectedGenGroup.Group)
        {
            if (SpawnCount == 0)
            {
                LvObjs.Add(Instantiate(GenObj, LvStartPoint.transform.position, LvStartPoint.transform.rotation));
            }
            else
            {
                LvObjs.Add(Instantiate(GenObj, LvObjs[LvObjs.Count - 1].transform.position + GapVector,
                                               LvObjs[LvObjs.Count - 1].transform.rotation));
            }
            SpawnCount++;
        }
        if (SpawnCount < SpawnSum)
        {
            SpawnLvObjs();
        }
    }

    void Start()
    {
        SpawnLvObjs();
        LvObjs.Add(LastEnemys[0]);
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
            CanOpenBox2 = false;
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
        if (LvProgress == LvObjs.Count - 1)
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
