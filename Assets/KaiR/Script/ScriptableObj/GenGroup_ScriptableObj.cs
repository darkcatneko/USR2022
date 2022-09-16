using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGenGroup", menuName = "ScriptableObjects/GenGroup", order = 1)]
public class GenGroup_ScriptableObj : ScriptableObject
{
    public List<GameObject> Group = new List<GameObject>();
}
