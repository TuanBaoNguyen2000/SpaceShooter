using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon SO",menuName = "ScriptableObject/Data/Weapon")]
public class GunSO : ScriptableObject
{
    public IDGun ID;
    public Transform prefab;
}

[Serializable]
public enum IDGun
{
    Null,
    Gun1,
    Gun2,
}

