using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxerGameControl    : MonoBehaviour
{
    [SerializeField] UnityEvent win;
    [SerializeField] UnityEvent lose;
    public bool gameEnd = false;

   public void Win()
    {
        Debug.Log("You Win!");
        gameEnd = true;
        win.Invoke();
    }

    public void Lose()
    {
        Debug.Log("You Lose!");
        gameEnd = true;
    }

}
