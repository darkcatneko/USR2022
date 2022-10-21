using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _HealthBarMove : MonoBehaviour
{
   
    [SerializeField] Slider slider;
    [SerializeField] _HpControl hpControl;


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
