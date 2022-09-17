using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintTimer : MonoBehaviour
{
    public float InputTimer = 1;
    public Slider InputTimerSlide;
    void Start()
    {
        
    }

   
    void Update()
    {
        InputTimerSlide.value = InputTimer;
        InputTimerUpdater();
    }
   public void InputTimerUpdater()
   {
        InputTimer -= Time.deltaTime;
        if (InputTimer<=0)
        {
            InputTimer = 1;
            Debug.Log("強制輸入動作");
        }
   }
    public void RestartTimer()
    {
        InputTimer = 1;
    }
}
