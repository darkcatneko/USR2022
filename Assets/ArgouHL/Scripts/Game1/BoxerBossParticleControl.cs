using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerBossParticleControl : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] chargingEffects;
    [SerializeField] private ParticleSystem[] attackEffects;
    [SerializeField] private ParticleSystem[] attackEffects_2;
    [SerializeField] private ParticleSystem[] hitEffects;
    [SerializeField] private ParticleSystem[] guardEffects;
    [SerializeField] private GameObject getHitEffect;

    public void Charging()
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

    public void StopCharging()
    {
        for (int i = 0; i < chargingEffects.Length; i++)
        {
            chargingEffects[i].Stop();

        }
    }


    public void Attacking()
    {
        
        for (int i = 0; i < attackEffects.Length; i++)
        {
            attackEffects[i].Play();
            var main = attackEffects[i].main;
            main.simulationSpace = ParticleSystemSimulationSpace.Local;
        }
    }


    public void AttackEnd()
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

    public void Hitted()
    {
        for (int i = 0; i < hitEffects.Length; i++)
        {
            hitEffects[i].Play();
        }
    }

    public void Guarded()
    {
        for (int i = 0; i < guardEffects.Length; i++)
        {
            guardEffects[i].Play();
        }
    }


    public void GetHit()
    {
        print("AAA");
        Instantiate(getHitEffect, new Vector3(Random.Range(-0.35f, 0.35f), Random.Range(0.9f, 1.5f), -2.6f), Quaternion.identity);
        
    }
}
