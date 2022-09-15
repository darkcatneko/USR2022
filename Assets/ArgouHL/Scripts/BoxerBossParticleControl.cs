using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerBossParticleControl : MonoBehaviour
{
    [SerializeField] public ParticleSystem charging_1;
    [SerializeField] public ParticleSystem charging_2;
    [SerializeField] public ParticleSystem attacking_1;
    [SerializeField] public ParticleSystem attacking_2;
    [SerializeField] public ParticleSystem attacking_3;
    [SerializeField] public ParticleSystem guardEffect;

    public void charging()
    {
        charging_1.Play();
        charging_2.Play();
        attacking_3.Play();
    }

    public void attacking()
    {
        charging_1.Stop();
        charging_2.Stop();
        attacking_1.Play();
        attacking_2.Play();
        
    }


    public void attackEnd()
    {
        attacking_1.Stop();
        attacking_2.Stop();
        attacking_3.Stop();

    }

    public void Guarded()
    {
        guardEffect.Play();
    }

}
