using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "ScriptableObject/Data/Player Data")]
public class PlayerDataSO : ScriptableObject
{ 
    public ModelSO modelSO;
    public List<Vector2> ListPosGun;

    public List<GunSO> ListGunType;
}
