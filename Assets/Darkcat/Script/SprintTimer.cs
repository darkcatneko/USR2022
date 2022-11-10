using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SprintTimer : MonoBehaviour
{
    public float InputTimer = 1;
    public Slider InputTimerSlide;
    [SerializeField] GenAndCtrl LevelController;
    void Start()
    {
        
    }

   
    void Update()
    {     
        if (LevelController.Game_State == SprintGameState.Free)
        {
            InputTimerSlide.value = InputTimer;
            InputTimerUpdater();
        }
    }
   public void InputTimerUpdater()
   {
        InputTimer -= Time.deltaTime;
        if (InputTimer<=0)
        {
            InputTimer = 1;
            Debug.Log("強制輸入動作");
            LevelController.ForwardBtn_Click();
        }
   }
    public void RestartTimer()
    {
        InputTimer = 1;
    }
}
