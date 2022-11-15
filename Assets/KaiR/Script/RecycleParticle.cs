using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleParticle : MonoBehaviour
{
    [SerializeField] ObjPool Pool;

    private void Start()
    {
        Pool = GameObject.FindGameObjectWithTag("ObjectPool").GetComponent<ObjPool>();
    }

    private void OnParticleSystemStopped()
    {
        Pool.Recycle(gameObject);
    }
}
