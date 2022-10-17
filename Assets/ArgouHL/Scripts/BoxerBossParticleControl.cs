using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerBossParticleControl : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] chargingEffects;
    [SerializeField] private ParticleSystem[] attackEffects;
    [SerializeField] private ParticleSystem[] attackEffects_2;
    [SerializeField] private ParticleSystem[] guardEffects;

    public void charging()
    {
        for(int i =0; i < chargingEffects.Length; i++)
        {
            chargingEffects[i].Play(); 
        }

        for (int i = 0; i < attackEffects_2.Length; i++)
        {
            attackEffects_2[i].Play();
        }
    }

    public void attacking()
    {
        for (int i = 0; i < chargingEffects.Length; i++)
        {
            chargingEffects[i].Stop();
        }
        for (int i = 0; i < attackEffects.Length; i++)
        {
            attackEffects[i].Play();
            var main = attackEffects[i].main;
            main.simulationSpace = ParticleSystemSimulationSpace.Local;
        }
    }


    public void attackEnd()
    {
        for (int i = 0; i < attackEffects.Length; i++)
        {
            attackEffects[i].Stop();
            var main = attackEffects[i].main;
            main.simulationSpace = ParticleSystemSimulationSpace.World;
        }
        for (int i = 0; i < attackEffects_2.Length; i++)
        {
            attackEffects_2[i].Stop();
            
        }

    }

    public void Guarded()
    {
        for (int i = 0; i < guardEffects.Length; i++)
        {
            guardEffects[i].Play();
        }
    }

}
