using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data File/Level Data")]
public class LevelData : ScriptableObject
{
    public Vector3 playerPos;
    public Vector3 goalPos;
    public Vector3[] enemyPos;
    public Vector3[] harmfulPos;
}
