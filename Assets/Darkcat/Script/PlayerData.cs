using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerData : MonoBehaviour
{
    PlayerAccount Account;


    [ContextMenu("Save")]
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        Stream s = File.Open(Application.dataPath + "/Save.ept", FileMode.Create);
        bf.Serialize(s, Account);
        s.Close();
        Debug.Log("Save Complete");
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(Application.dataPath + "/Save.ept"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            Stream s = File.Open(Application.dataPath + "/Save.ept", FileMode.Open);
            Account = (PlayerAccount)bf.Deserialize(s);
            s.Close();
            Debug.Log("Load");
        }
    }
    private void Update()
    {
        
    }
}
