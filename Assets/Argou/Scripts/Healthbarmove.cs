using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbarmove : MonoBehaviour
{
   
    [SerializeField] Slider slider;
    [SerializeField] HpControl hpControl;


    private void Start()
    {
        slider.maxValue = hpControl.maxHp;
        slider.value = hpControl.nowHp;
    }


    private void Update()
    {
        slider.value = hpControl.nowHp;
    }

}
