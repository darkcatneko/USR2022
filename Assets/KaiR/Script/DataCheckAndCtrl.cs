using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DataCheckAndCtrl : MonoBehaviour
{
    [SerializeField] GameObject EndUI;

    [SerializeField] PlayerData player;
    [SerializeField] TextMeshProUGUI CashTxt, GetMoneyTxt, EndMoneyTxt;

    [SerializeField] UnityEvent StartGame, EndGame;

    public void StartOrEnd()
    {
        if (player.ThisPlayer.Player_Money < 100)
        {
            EndGame.Invoke();
        }
        else
        {
            StartGame.Invoke();
        }
    }

    public void Win()
    {
        EndUI.SetActive(true);
        player.ThisPlayer.GetMoney(300);
        player.Save();
        CashTxt.text = player.ThisPlayer.Player_Money.ToString();
        EndMoneyTxt.text = player.ThisPlayer.Player_Money.ToString();
        GetMoneyTxt.text = "300";
    }
    public void Lose()
    {
        EndUI.SetActive(true);
        player.ThisPlayer.GetMoney(-100);
        player.Save();
        CashTxt.text = player.ThisPlayer.Player_Money.ToString();
        EndMoneyTxt.text = player.ThisPlayer.Player_Money.ToString();
        GetMoneyTxt.text = "-100";
    }

    void Start()
    {
        player.LoadTest();
        player.ThisPlayer.GetMoney(1000);
        player.Save();
        CashTxt.text = player.ThisPlayer.Player_Money.ToString();
    }
}
