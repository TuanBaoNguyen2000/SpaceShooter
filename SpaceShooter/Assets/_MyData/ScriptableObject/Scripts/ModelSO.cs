using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Model", menuName = "ScriptableObject/Data/Model Ship SO")]
public class ModelSO : ScriptableObject
{
    public string NameModel;

    public Transform Prefab;
    public List<Vector2> PointGunList;
    public float MaxSpeedModel;
    public float LoadCapacity;
    public float HeathPoint;
}
