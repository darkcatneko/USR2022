using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "NewPlayer")]
public class PlayerAccount : ScriptableObject
{
    public int Player_Money;
    public string NowSkin = "Normal";
    public bool[] Skin_Pack = new bool[12];
    public void Reload()
    {
        Player_Money = 0;
        NowSkin = "Normal";
        for (int i = 0; i < Skin_Pack.Length; i++)
        {
            Skin_Pack[i] = false;
        }
    }
    public void GetMoney(int money)
    {
        Player_Money += money;
    }
    public void Reverse(Account ac)
    {
        Player_Money = ac.Player_Money;
        NowSkin = ac.NowSkin;
        for (int i = 0; i < Skin_Pack.Length; i++)
        {
            Skin_Pack[i] = ac.Skin_Pack[i];
        }
    }
}
    [System.Serializable]
public class Account
{
    public int Player_Money;
    public string NowSkin = "Normal";
    public bool[] Skin_Pack = new bool[12];
   public Account (PlayerAccount ac)
    {
        Player_Money = ac.Player_Money;
        NowSkin = ac.NowSkin;
        for (int i = 0; i < Skin_Pack.Length; i++)
        {
            Skin_Pack[i] = ac.Skin_Pack[i];
        }
    }
}
