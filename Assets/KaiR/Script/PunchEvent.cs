using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PunchEvent : MonoBehaviour
{
    public static bool CanHit = false;

    [SerializeField] ObjPool Pool;
    [SerializeField] GameObject HitParticle;
    [SerializeField] CinemachineImpulseSource impulseSource;
    [SerializeField] Vector3 ParticleOffset;

    public void Hit()
    {
        if (CanHit)
        {
            impulseSource.GenerateImpulse();
            Pool.Use(HitParticle, transform.position + ParticleOffset, transform.rotation);
        }
    }
}
