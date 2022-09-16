using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDifficultyGroup", menuName = "ScriptableObjects/DifficultyGroup", order = 0)]
public class DifficultyGroup_ScriptableObj : ScriptableObject
{
    public AnimationCurve DifficultyCurve;

    public List<GenGroup_ScriptableObj> GenGroups = new List<GenGroup_ScriptableObj>();
}
