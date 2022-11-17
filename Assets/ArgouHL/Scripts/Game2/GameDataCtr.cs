using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDataCtr : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private TMP_Text PlayerMoneyUI;
    [SerializeField] public int playerMoney = 0;
    // Start is called before the first frame update
    private void Start()
    {
        playerMoney = 0;
        Load();
        PlayerMoneyUpdate();
    }

    private void PlayerMoneyUpdate()
    {
        //PlayerMoneyUI.text = (playerMoney+playerData.ThisPlayer.Player_Money).ToString();
        PlayerMoneyUI.text = playerMoney.ToString();
    }

    public void GetMoney(int addedMoney)
    {
        playerMoney += addedMoney;
        PlayerMoneyUpdate();
    }

    public void Load()
    {
        playerData.LoadTest();
        print(playerData.ThisPlayer.Player_Money);
    }

    public void Save()
    {
        Debug.Log(playerMoney);
        playerData.ThisPlayer.GetMoney(playerMoney);
        Debug.Log("AC:"+playerData.ThisPlayer.Player_Money);
        playerData.Save();
        
        
    }

   



}
