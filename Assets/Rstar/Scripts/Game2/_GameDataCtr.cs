using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class _GameDataCtr : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] TMP_Text PlayerMoneyUI;
    [SerializeField] private int playerMoney = 0;
    // Start is called before the first frame update
    private void Start()
    {
        Load();
        PlayerMoneyUpdate();



    }

    private void PlayerMoneyUpdate()
    {
        PlayerMoneyUI.text = "Money : " + (playerMoney+playerData.ThisPlayer.Player_Money).ToString();
    }

    public void GetMoney(int addedMoney)
    {
        playerMoney += addedMoney;
        PlayerMoneyUpdate();
    }



    public void Save()
    {
        playerData.ThisPlayer.GetMoney(playerMoney);
        playerData.Save();
        playerMoney = 0;
    }

    public void Load()
    {
        playerData.Load();
        print(playerData.ThisPlayer.Player_Money);
    }



}
