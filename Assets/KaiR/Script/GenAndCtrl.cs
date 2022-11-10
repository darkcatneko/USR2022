using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Cinemachine;
using System;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class GenAndCtrl : MonoBehaviour
{
    [SerializeField] SprintTimer sprintTimer;
    [SerializeField] SprintGameController sprintGameController;
    [SerializeField] GameObject LvStartPoint, GameCanvas, FastTapCanvas;
    [SerializeField] Button ClearBtn, ForwardBtn;
    [SerializeField] CameraAnimationController CameraAnimCtrler;
    [SerializeField] GameObject[] PrefabLvObjs = new GameObject[4];
    [SerializeField] GameObject[] LastEnemys = new GameObject[3];
    [SerializeField] List<DifficultyGroup_ScriptableObj> DifficultyGroups = new List<DifficultyGroup_ScriptableObj>();
    [SerializeField] List<GameObject> StreetList = new List<GameObject>();
    [SerializeField] int SpawnSum;
    [SerializeField] Vector3 GapVector;
    [SerializeField] Vector3 StreetGapVector;

    List<GameObject> LvObjs = new List<GameObject>();
    int SpawnCount = 0;
    float MoveSpeed = 10f;
    public int LvProgress = -1;
    bool CanOpenBox2 = false;
    bool CanMove = true;
    Coroutine moveIE;
    #region 開始遊戲
    public SprintGameState Game_State = SprintGameState.Ready;
    [SerializeField] TextMeshProUGUI EnterText;
    [SerializeField] Image BackGround;
    [SerializeField] GameObject EnterCanvas;
    public void EnterGame()
    {
        EnterText.DOFade(1f, 2.5f);
    }
    public IEnumerator EnterGameFade()
    {
        EnterText.DOFade(0f, 2.5f);
        BackGround.DOFade(0f, 2.5f);
        yield return new WaitForSeconds(2.5f);
        EnterCanvas.SetActive(false);
        Game_State = SprintGameState.Free;
        SpawnLvObjs();
        LvObjs.Add(LastEnemys[0]);
        StartCoroutine("Move");
    }
    public void SkipText()
    {
        if (Game_State == SprintGameState.Ready)
        {
            StartCoroutine("EnterGameFade");
        }
    }
    #endregion
    #region 金錢管理
    [SerializeField] PlayerData player;
    [SerializeField] TextMeshProUGUI CoinText;
    #endregion
    #region 結束遊戲
    [SerializeField] GameObject WinCanvas;
    [SerializeField] TextMeshProUGUI WinCanvasCoinTXT;
    [SerializeField] TextMeshProUGUI LoseCanvasCoinTXT;
    [SerializeField] GameObject LoseCanvas;
    public void LoseGame()
    {
        Game_State = SprintGameState.End;
        LoseCanvas.SetActive(true);
        LoseCanvasCoinTXT.text = player.ThisPlayer.Player_Money.ToString();
        player.Save();
    }
    public void WinGame()
    {
        Game_State = SprintGameState.End;
        WinCanvas.SetActive(true);
        WinCanvasCoinTXT.text = player.ThisPlayer.Player_Money.ToString();
        player.Save();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ToMain()
    {
        SceneManager.LoadScene(0);
    }
    #endregion

    int Choose(float[] probs)
    {

        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = UnityEngine.Random.value * total;

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
        Array.Sort(DifficultyProbs);
        Array.Reverse(DifficultyProbs);
        SelectedDifficultyGroup = DifficultyGroups[Choose(DifficultyProbs)];
        SelectedGenGroup = SelectedDifficultyGroup.GenGroups[UnityEngine.Random.Range(0, SelectedDifficultyGroup.GenGroups.Count)];
        foreach(GameObject GenObj in SelectedGenGroup.Group)
        {
            if (SpawnCount == 0)
            {
                GameObject genObj = Instantiate(GenObj, LvStartPoint.transform.position, LvStartPoint.transform.rotation);

                LvObjs.Add(genObj);
            }
            else
            {
                GameObject genObj = Instantiate(GenObj, LvObjs[LvObjs.Count - 1].transform.position + GapVector,
                                                LvObjs[LvObjs.Count - 1].transform.rotation);
                LvObjs.Add(genObj);
            }
            SpawnCount++;
        }
        if (SpawnCount < SpawnSum)
        {
            SpawnLvObjs();
        }
    }

    void LoopStreet()
    {
        GameObject RearStreet = StreetList[0];
        StreetList.RemoveAt(0);
        RearStreet.transform.position = StreetList[StreetList.Count - 1].transform.position + StreetGapVector;
        StreetList.Add(RearStreet);
    }

    void Start()
    {
        EnterGame();
        player.LoadTest();
    }

    void Update()
    {
        CoinText.text = player.ThisPlayer.Player_Money.ToString();
        if (LvProgress == SpawnSum+1)
        {
            WinGame();
        }
    }

    public void ClearBtn_Click()
    {
        if (Game_State == SprintGameState.Free)
        {
            switch (LvObjs[LvProgress].tag)
            {
                case "Enemy":
                    LvObjs[LvProgress].GetComponent<Animator>().SetTrigger("Die");
                    LvObjs[LvProgress].tag = "NoneObj";
                    CanMove = true;
                    break;
                case "Box1":
                    LvObjs[LvProgress].GetComponentInChildren<Animator>().SetTrigger("Open");
                    LvObjs[LvProgress].tag = "NoneObj";
                    player.ThisPlayer.GetMoney(1);
                    break;
                case "Box2":
                    if (CanOpenBox2)
                    {
                        LvObjs[LvProgress].GetComponentInChildren<Animator>().SetTrigger("Open");
                        LvObjs[LvProgress].tag = "NoneObj";
                        player.ThisPlayer.GetMoney(2);
                    }
                    else
                    {
                        CanOpenBox2 = true;
                    }
                    break;
                case "NoneObj":
                    SprintGameController.instance.MinusHealth();
                    break;
            }
        }
        
    }

    public void ForwardBtn_Click()
    {
        if (Game_State == SprintGameState.Free)
        {
            if (CanMove || LvObjs[LvProgress].tag != "Enemy")
            {
                CanOpenBox2 = false;
                if (moveIE == null)
                {
                    moveIE = StartCoroutine("Move");
                }
            }
            else
            {
                SprintGameController.instance.MinusHealth();
            }
        }       
    }

    IEnumerator Move()
    {
        CameraAnimCtrler.Is_Walking = true;
        LvProgress++;
        ClearBtn.interactable = false;
        ForwardBtn.interactable = false;
        if (LvProgress == LvObjs.Count - 1)
        {
            sprintTimer.enabled = false;
            sprintGameController.enabled = false;
            GameCanvas.SetActive(false);
        }
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

        if (LvProgress != 0 && LvProgress % 10 == 0 && (float)LvProgress / SpawnSum < 0.8f)
        {
            LoopStreet();
        }

        if (LvObjs[LvProgress].tag == "Enemy")
        {
            CanMove = false;
        }

        if (LvProgress == LvObjs.Count - 1)
        {
            FastTapCanvas.SetActive(true);
        }
        else
        {
            ClearBtn.interactable = true;
            ForwardBtn.interactable = true;
        }

        moveIE = null;
    }
}

public enum SprintGameState
{
    Ready,
    Free,
    End,
}
