using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class debug : MonoBehaviour
{
    [SerializeField] private TMP_Text debugText;

    void Update()
    {
        debugText.text = "position:" + Camera.main.transform.position.ToString() + "\r\n" +
            "rotation:" + Camera.main.transform.rotation.eulerAngles.ToString();
    }
}
