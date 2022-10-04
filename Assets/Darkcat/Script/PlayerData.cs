using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;

public class PlayerData : MonoBehaviour
{

    public PlayerAccount ThisPlayer;
    //public TextMeshProUGUI PlayerMoneyTest;


    [ContextMenu("Save")]
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();        
        FileStream stream = new FileStream(Application.persistentDataPath + "/Save.ept", FileMode.Create);
        Account account = new Account(ThisPlayer);
        bf.Serialize(stream, account);
        stream.Close();
        Debug.Log("Save Complete"+ Application.dataPath + "/Save.ept");
    }
    [ContextMenu("Load")]
    public Account Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Save.ept"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/Save.ept", FileMode.Open);
            Account account = bf.Deserialize(stream) as Account;
            stream.Close();
            Debug.Log("Load");
            return account;
        }
        else
        {
            return null;
        }
    }
    private void Update()
    {
        //PlayerMoneyTest.text = ThisPlayer.Player_Money.ToString();
    }

    public void SaveTest()
    {
        ThisPlayer.GetMoney(1);
        Save();
    }
    public void LoadTest()
    {
        Debug.Log(Load().Player_Money.ToString());
        ThisPlayer.Reverse(Load());
    }
    
    private void OnApplicationQuit()
    {
        ThisPlayer.Player_Money = 0;
    }
}
