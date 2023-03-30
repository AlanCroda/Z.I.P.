using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data File/Level Catalog")]
public class LevelCatalog : ScriptableObject
{
    [SerializeField]
    LevelData[] levels;
}
