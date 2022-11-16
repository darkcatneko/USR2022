using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] int HashCode, InstanceID;

    void Start()
    {
        HashCode = GetHashCode();
        InstanceID = GetInstanceID();
    }
}
