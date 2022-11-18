using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;


public class GambleCtrl : MonoBehaviour
{
    [SerializeField] GameObject[] Dices = new GameObject[4];

    [SerializeField] DiceResult diceResult;
    [SerializeField] Transform[] ThrowDicePoints = new Transform[4];
    [SerializeField] Transform ThrowPoint;

    [SerializeField] float strength;

    [SerializeField] UnityEvent TurnStart, TurnEnd;
    
    public void InvokeTurnStart()
    {
        print(gameObject.name);
        TurnStart.Invoke();
        diceResult.gambleCtrl = this;
    }
    public void InvokeTurnEnd()
    {
        TurnEnd.Invoke();
    }

    void CatchDice()    //動畫呼叫
    {
        foreach(GameObject dice in Dices)
        {
            dice.GetComponent<Rigidbody>().useGravity = false;
            dice.SetActive(false);
        }
    }
    void ThrowDice()    //動畫呼叫
    {
        for (int i = 0; i < Dices.Length; i++)
        {
            Dices[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            Dices[i].transform.position = ThrowDicePoints[i].position;
            Dices[i].SetActive(true);
            Dices[i].GetComponent<Rigidbody>().useGravity = true;
            Dices[i].transform.Rotate(new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180)));
            Dices[i].GetComponent<Rigidbody>().AddForce((ThrowPoint.position - Dices[i].transform.position) * strength, ForceMode.Impulse);
            Dices[i].GetComponent<DiceFaceUp>().StartWaitSelfStop();
        }
    }
}
