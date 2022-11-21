using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxerBossParticleControl : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] chargingEffects;
    [SerializeField] private ParticleSystem[] chargingEffectsL;
    [SerializeField] private ParticleSystem[] attackEffects;
    [SerializeField] private ParticleSystem[] attackEffectsL;
    [SerializeField] private ParticleSystem[] attackEffects_2;
    [SerializeField] private ParticleSystem[] attackEffects_2L;
    [SerializeField] private ParticleSystem[] hitEffects;
    [SerializeField] private ParticleSystem[] guardEffects;
    [SerializeField] private ParticleSystem[] getHitEffects;
    [SerializeField] private ParticleSystem[] stunEffects;
    private int getHitEffectCount=0;

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

    public void ChargingL()
    {
        for (int i = 0; i < chargingEffectsL.Length; i++)
        {
            chargingEffectsL[i].Play();

        }

        for (int i = 0; i < attackEffects_2L.Length; i++)
        {
            attackEffects_2L[i].Play();
        }
    }

    public void StopCharging()
    {
        for (int i = 0; i < chargingEffects.Length; i++)
        {
            chargingEffects[i].Stop();

        }
        for (int i = 0; i < chargingEffectsL.Length; i++)
        {
            chargingEffectsL[i].Stop();

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
    public void AttackingL()
    {

        for (int i = 0; i < attackEffectsL.Length; i++)
        {
            attackEffectsL[i].Play();
            var main = attackEffectsL[i].main;
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

        for (int i = 0; i < attackEffectsL.Length; i++)
        {
            attackEffectsL[i].Stop();
            var main = attackEffectsL[i].main;
            main.simulationSpace = ParticleSystemSimulationSpace.World;
        }
        for (int i = 0; i < attackEffects_2L.Length; i++)
        {
            attackEffects_2L[i].Stop();

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
        if (getHitEffectCount == 0)
            getHitEffectCount++;
        else
            getHitEffectCount = 0;

        getHitEffects[getHitEffectCount].gameObject.transform.position = new Vector3(Random.Range(-0.35f, 0.35f), Random.Range(0.9f, 1.5f), -2.6f);
        getHitEffects[getHitEffectCount].Play();


    }

    public void Stun()
    {
        foreach(var effect in stunEffects)
        {
            effect.gameObject.SetActive(true);
            effect.Play();
        }
    }

    public void StopStun()
    {
        foreach (var effect in stunEffects)
        {
            effect.gameObject.SetActive(false);
            effect.Stop();
        }
    }
}
