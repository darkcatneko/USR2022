using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class DiceResult : MonoBehaviour
{
    public GambleCtrl gambleCtrl;
    public DiceFaceUp[] diceFaceUps = new DiceFaceUp[4];
    public TextMeshProUGUI[] ResultText = new TextMeshProUGUI[4];
    public DiceThrower diceThrower;
    public DiceWinner diceWinner;
    private int ResultNum = 0;
    private byte StopDiceCount = 0;
    #region 開始遊戲    
    [SerializeField] TextMeshProUGUI EnterText;
    [SerializeField] Image BackGround;
    [SerializeField] GameObject EnterCanvas;

    bool AlreadySkip = false;

    public void ResetResult()
    {
        ResultNum = 0;
        foreach(TextMeshProUGUI txt in ResultText)
        {
            txt.text = "";
        }
    }

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
    }
    public void SkipText()
    {
        if (!AlreadySkip)
        {
            AlreadySkip = true;
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
    //[SerializeField] TextMeshProUGUI LoseCanvasCoinTXT;
    [SerializeField] GameObject LoseCanvas;
    public void LoseGame()
    {
        LoseCanvas.SetActive(true);
        //LoseCanvasCoinTXT.text = player.ThisPlayer.Player_Money.ToString();
        player.Save();
    }
    public void WinGame()
    {
        WinCanvas.SetActive(true);
        WinCanvasCoinTXT.text = player.ThisPlayer.Player_Money.ToString();
        player.Save();
    }
    #endregion
    private void Start()
    {
        EnterGame();
        player.LoadTest();
        CoinText.text = player.ThisPlayer.Player_Money.ToString();
    }
    public void Test()
    {
        
        if (ReadTheResult()!=null)
        {
            Debug.Log(ReadTheResult().resultEnum.ToString() + "   " + ReadTheResult().PointGet.ToString());
            diceWinner.Results[ResultNum] = ReadTheResult();
            ResultNum++;
        }
        for (int i = 0; i < diceThrower.Dices.Length; i++)
        {
            diceThrower.Dices[i].gameObject.transform.position = diceThrower.DicesMoto[i];
            diceThrower.Dices[i].GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public void WaitDiceStop()
    {
        StopDiceCount++;
        if (StopDiceCount == diceFaceUps.Length)
        {
            StopDiceCount = 0;
            for (int i = 0; i < diceFaceUps.Length; i++)
            {
                if (diceFaceUps[i].CanRead == false)
                {
                    print(diceFaceUps[i].name+ "CanNotRead");
                }
            }
            switch (ReadTheResult().resultEnum)
            {
                case ResultEnum.NeedToReThrow:
                    gambleCtrl.InvokeTurnStart();
                    break;
                case ResultEnum.FourSame:
                    diceWinner.Results[ResultNum] = ReadTheResult();
                    ResultText[ResultNum].transform.gameObject.SetActive(true);
                    ResultText[ResultNum].text = "一色 " + diceWinner.Results[ResultNum].PointGet;
                    ResultNum++;
                    gambleCtrl.InvokeTurnEnd();
                    break;
                case ResultEnum.Normal:
                    diceWinner.Results[ResultNum] = ReadTheResult();
                    switch(diceWinner.Results[ResultNum].PointGet)
                    {
                        case 3:
                            ResultText[ResultNum].transform.gameObject.SetActive(true);
                            ResultText[ResultNum].text = "逼機 " + diceWinner.Results[ResultNum].PointGet;
                            break;
                        case 12:
                            ResultText[ResultNum].transform.gameObject.SetActive(true);
                            ResultText[ResultNum].text = "十八 " + diceWinner.Results[ResultNum].PointGet;
                            break;
                        default:
                            ResultText[ResultNum].transform.gameObject.SetActive(true);
                            ResultText[ResultNum].text =  (diceWinner.Results[ResultNum].PointGet+1).ToString();
                            break;
                    }
                    ResultNum++;
                    gambleCtrl.InvokeTurnEnd();
                    break;
            }
        }
    }

    public result ReadTheResult()
    {
        
        int[] resultCab = new int[6];
        ResultEnum RE;
        int Combine = 0;
        int Biggest = 0;
        int FourNotSame = 0;
        for (int i = 0; i < diceFaceUps.Length; i++)
        {
            if (diceFaceUps[i].CanRead == false)
            {
                return null;
            }
        }//確認四顆都靜止
        for (int i = 0; i < diceFaceUps.Length; i++)//統計結果
        {
            resultCab[(int)diceFaceUps[i].DR]++;
        }        
        for (int i = 0; i < resultCab.Length; i++)
        {
            if (resultCab[i]==4)
            {
                return new result(ResultEnum.FourSame, i);
            }
            if (resultCab[i] == 3)
            {
                return new result(ResultEnum.NeedToReThrow, i);
            }
            if (resultCab[i] == 2)
            {
                Combine++;
                Biggest = i;
            }
            if (resultCab[i]==1)
            {
                FourNotSame++;
            }
        }
        if (FourNotSame ==4)
        {
            return new result(ResultEnum.NeedToReThrow, 0);
        }
        if (Combine == 1)
        {
            int Score = 0;
            for (int i = 0; i < resultCab.Length; i++)
            {
                if (resultCab[i]==1)
                {
                    Score += i+1;
                }
            }
            return new result(ResultEnum.Normal, Score);
        }
        if (Combine == 2)
        {
            return new result(ResultEnum.Normal,(Biggest+1)*2 );
        }        
        return new result(ResultEnum.NeedToReThrow, 0);
    }
    
}


[System.Serializable]
public class result
{
    public ResultEnum resultEnum;
    public int PointGet;
    public result(ResultEnum re, int pt)
    {
        resultEnum = re;
        PointGet = pt;
    }
}
public enum ResultEnum
{
    NeedToReThrow,
    FourSame,
    Normal,
}

